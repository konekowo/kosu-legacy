using System;

namespace BeatmapParser.Exceptions
{
    public class BeatMapIsWrongMode : Exception
    {
        public BeatMapIsWrongMode()
        {
        }

        public BeatMapIsWrongMode(string message)
            : base(message)
        {
        }

        public BeatMapIsWrongMode(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}