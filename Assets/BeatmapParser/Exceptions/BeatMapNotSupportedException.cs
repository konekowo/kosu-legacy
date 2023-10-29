using System;

namespace BeatmapParser.Exceptions
{
    public class BeatMapNotSupportedException : Exception
    {
        public BeatMapNotSupportedException()
        {
        }

        public BeatMapNotSupportedException(string message)
            : base(message)
        {
        }

        public BeatMapNotSupportedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}