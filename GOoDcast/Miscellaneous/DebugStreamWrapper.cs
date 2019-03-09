using System;

namespace GOoDcast.Miscellaneous
{
    using System.Diagnostics;
    using System.IO;

    internal class DebugStreamWrapper : Stream
    {
        private readonly Stream stream;

        public DebugStreamWrapper(Stream stream)
        {
            this.stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        public override void Flush()
        {
            stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            Debug.WriteLine(BitConverter.ToString(buffer, offset, count));
            return stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Debug.WriteLine(BitConverter.ToString(buffer, offset, count));
            stream.Write(buffer,offset,count);
        }

        public override bool CanRead => stream.CanRead;
        public override bool CanSeek => stream.CanSeek;
        public override bool CanWrite => stream.CanWrite;
        public override long Length => stream.Length;
        public override long Position
        {
            get => stream.Position;
            set => stream.Position = value;
        }
    }
}
