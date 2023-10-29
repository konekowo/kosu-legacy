using System;
using System.Collections;

namespace BeatmapParser
{
    public enum OsuMode
    {
        Standard,
        Taiko,
        Catch,
        Mania
    }

    public enum OverlayPos
    {
        NoChange,
        Below,
        Above
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
            public bool StoryFireInFront = true;
            /// <summary>
            /// Whether or not the storyboard can use the user's skin images.
            /// </summary>
            public bool UseSkinSprites = false;
            [Obsolete("Deprecated according to https://osu.ppy.sh/wiki/en/Client/File_formats/osu_%28file_format%29")]
            public bool AlwaysShowPlayfield = false;
            /// <summary>
            /// Draw order of hit circle overlays compared to hit numbers (NoChange = use skin setting, Below = draw overlays under numbers, Above = draw overlays on top of numbers)
            /// </summary>
            public OverlayPos OverlayPosition = OverlayPos.NoChange;
            /// <summary>
            /// Preferred skin to use during gameplay
            /// </summary>
            public string SkinPreference;
            /// <summary>
            /// Whether or not a warning about flashing colours should be shown at the beginning of the map
            /// </summary>
            public bool EpilepsyWarning = false;
            /// <summary>
            /// Time in beats that the countdown starts before the first hit object
            /// </summary>
            public int CountDownOffset = 0;
            /// <summary>
            /// Whether or not the "N+1" style key layout is used for osu!mania
            /// </summary>
            public bool SpecialStyle = false;
            /// <summary>
            /// Whether or not the storyboard allows widescreen viewing
            /// </summary>
            public bool WidescreenStoryboard = false;
            /// <summary>
            /// Whether or not sound samples will change rate when playing with speed-changing mods
            /// </summary>
            public bool SamplesMatchPlaybackRate = false;

        #endregion

        #region [Editor]
            /// <summary>
            /// Time in milliseconds of bookmarks
            /// </summary>
            public ArrayList Bookmarks = new ArrayList();
            /// <summary>
            /// Distance snap multiplier
            /// </summary>
            public float DistanceSpacing;
            /// <summary>
            /// Beat snap divisor
            /// </summary>
            public int BeatDivisor;
            /// <summary>
            /// Grid size
            /// </summary>
            public int GridSize;
            /// <summary>
            /// Scale factor for the object timeline
            /// </summary>
            public float TimelineZoom;

        #endregion




    }
}