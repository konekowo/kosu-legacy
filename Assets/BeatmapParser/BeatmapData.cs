using System;

namespace BeatmapParser
{
    public enum OsuMode
    {
        Standard = 0,
        Taiko = 1,
        Catch = 2,
        Mania = 3
    }
    public class BeatmapData
    {
        #region [General]
            /// <summary>
            /// Location of the audio file relative to the current folder.
            /// </summary>
            public string AudioFileName;
            /// <summary>
            /// Milliseconds of silence before the audio starts playing.
            /// </summary>
            public int AudioLeadIn = 0;
            [Obsolete("Deprecated according to https://osu.ppy.sh/wiki/en/Client/File_formats/osu_%28file_format%29")]
            public string AudioHash;
            /// <summary>
            /// Time in milliseconds when the audio preview should start.
            /// </summary>
            public int PreviewTime = -1;
            /// <summary>
            /// Speed of the countdown before the first hit object (0 = no countdown, 1 = normal, 2 = half, 3 = double).
            /// </summary>
            public int Countdown = 1;
            /// <summary>
            /// Sample set that will be used if timing points do not override it (Normal, Soft, Drum).
            /// </summary>
            public string SampleSet = "Normal";
            /// <summary>
            /// Multiplier (https://osu.ppy.sh/wiki/en/Beatmap/Stack_leniency) for the threshold in time where hit objects placed close together stack (0–1).
            /// </summary>
            public float StackLeniency = 0.7f;
            /// <summary>
            /// Game mode (0 = osu!, 1 = osu!taiko, 2 = osu!catch, 3 = osu!mania)
            /// </summary>
            public OsuMode Mode = OsuMode.Standard;
            /// <summary>
            /// Whether or not breaks have a letterboxing effect.
            /// </summary>
            public bool LetterboxInBreaks = false;
            [Obsolete("Deprecated according to https://osu.ppy.sh/wiki/en/Client/File_formats/osu_%28file_format%29")]
            public bool StoryFireInFront = false;

            #endregion




    }
}