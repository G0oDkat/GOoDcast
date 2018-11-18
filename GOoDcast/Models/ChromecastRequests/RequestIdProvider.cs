namespace GOoDcast.Models.ChromecastRequests
{
    using System;
    using System.Threading;

    public static class RequestIdProvider
    {
        public static int GetNext()
        {
            return Interlocked.Add(ref currentId, 1);
        }

        private static int currentId = new Random((int)DateTime.Now.Ticks).Next();
    }
}


