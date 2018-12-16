namespace GOoDcast.ProtoBuf
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using global::ProtoBuf;

    internal static class ProtoBufSerializer
    {
        public static async Task SerializeWithLengthPrefixAsync<T>(Stream stream, T instance, PrefixStyle prefix,
                                                                   CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                Serializer.SerializeWithLengthPrefix(memoryStream, instance, prefix);
                memoryStream.Position = 0;
                await memoryStream.CopyToAsync(stream, 81920, cancellationToken);
            }
        }

        public static async Task<T> DeserializeWithLengthPrefixAsync<T>(Stream stream, PrefixStyle prefix,
                                                                        CancellationToken cancellationToken)
        {
            int length;
            switch (prefix)
            {
                case PrefixStyle.None:
                    throw new NotSupportedException();
                case PrefixStyle.Base128:
                    length = await ReadBase128LengthAsync(stream, cancellationToken);
                    break;
                case PrefixStyle.Fixed32:
                    length = await ReadFixed32LittleEndianLengthAsync(stream, cancellationToken);
                    break;

                case PrefixStyle.Fixed32BigEndian:
                    length = await ReadFixed32BigEndianLengthAsync(stream, cancellationToken);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(prefix), prefix, null);
            }

            byte[] buffer = await stream.ReadFixedAsync(length, cancellationToken);

            return Serializer.Deserialize<T>(new MemoryStream(buffer));
        }

        private static async Task<int> ReadBase128LengthAsync(Stream stream, CancellationToken cancellationToken)
        {
            var lengthBufffer = new byte[1];
            int length = 0, shift = 0;

            do
            {
                if (shift >= 28)
                    throw new OverflowException();

                await stream.ReadFixedAsync(lengthBufffer, cancellationToken);
                length |= (lengthBufffer[0] & 0x7f) << shift;
                shift += 7;
            } while ((lengthBufffer[0] & 0x80) != 0);

            return length;
        }

        private static async Task<int> ReadFixed32LittleEndianLengthAsync(
            Stream stream, CancellationToken cancellationToken)
        {
            byte[] sizeBuffer = await stream.ReadFixedAsync(4, cancellationToken);

            if (!BitConverter.IsLittleEndian) Array.Reverse(sizeBuffer);

            return BitConverter.ToInt32(sizeBuffer, 0);
        }

        private static async Task<int> ReadFixed32BigEndianLengthAsync(Stream stream,
                                                                       CancellationToken cancellationToken)
        {
            byte[] sizeBuffer = await stream.ReadFixedAsync(4, cancellationToken);

            if (BitConverter.IsLittleEndian) Array.Reverse(sizeBuffer);

            return BitConverter.ToInt32(sizeBuffer, 0);
        }
    }
}