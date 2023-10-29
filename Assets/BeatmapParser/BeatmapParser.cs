using System;
using System.IO;
using BeatmapParser.Exceptions;


namespace BeatmapParser
{
    public class BeatmapParser
    {
        
        
        public BeatmapParser(string mapLocation)
        {
            // check if beatmap file exists
            if (File.Exists(mapLocation))
            {
                parse(mapLocation);
            }
            else
            {
                throw new FileNotFoundException("The BeatMap "+mapLocation+" was not found.");
            }
        }

        private void parse(string mapLocation)
        {
            BeatmapData parsedData = new BeatmapData();
            
            string[] rawMapData = File.ReadAllLines(mapLocation);
            // throw error if map file is in wrong format version
            if (!rawMapData[0].StartsWith("osu file format v14"))
            {
                throw new BeatMapNotSupportedException("This BeatMap's format ("+rawMapData[0]+") is not supported. ");
            }

            int generalIteration = 0;
            int editorIteration = 0;
            int metadataIteration = 0;
            int eventIteration = 0;
            int timingPointsIteration = 0;
            int colorsIteration = 0;
            int hitObjectsIteration = 0;
            
            // get where all regions of the map file are
            for (int i = 0; i < rawMapData.Length; i++)
            {
                switch (rawMapData[i])
                {
                    case "[General]":
                        generalIteration = i + 1;
                        break;
                    case "[Editor]":
                        editorIteration = i + 1;
                        break;
                    case "[Metadata]":
                        metadataIteration = i + 1;
                        break;
                    case "[Events]":
                        eventIteration = i + 1;
                        break;
                    case "[TimingPoints]":
                        timingPointsIteration = i + 1;
                        break;
                    case "[Colours]":
                        colorsIteration = i + 1;
                        break;
                    case "[HitObjects]":
                        hitObjectsIteration = i + 1;
                        break;
                }
            }
            #region [General]
                for (int i = generalIteration; i < rawMapData.Length; i++)
                {
                    if (rawMapData[i] == "")
                    {
                        break;
                    }

                    if (rawMapData[i].StartsWith("AudioFilename:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.AudioFilename = split[1];
                    }
                    if (rawMapData[i].StartsWith("AudioLeadIn:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.AudioLeadIn = int.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("AudioHash:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.AudioHash = split[1];
                    }
                    if (rawMapData[i].StartsWith("Countdown:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.Countdown = int.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("SampleSet:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.SampleSet = split[1];
                    }
                    if (rawMapData[i].StartsWith("StackLeniency:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.StackLeniency = float.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("Mode:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "0":
                                parsedData.Mode = OsuMode.Standard;
                                break;
                            default:
                                throw new BeatMapIsWrongMode(
                                    "BeatMap is in the wrong mode. The only mode supported by kosu! is Standard. Mode on beatmap " +
                                    "(0 = Standard, 1 = osu!taiko, 2 = osu!catch, 3 = osu!mania): " +
                                    split[1]);
                        }
                    }
                    if (rawMapData[i].StartsWith("LetterboxInBreaks:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "0" :
                                parsedData.LetterboxInBreaks = false;
                                break;
                            case "1":
                                parsedData.LetterboxInBreaks = true;
                                break;
                        }
                    }
                    if (rawMapData[i].StartsWith("StoryFireInFront:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "0" :
                                parsedData.StoryFireInFront = false;
                                break;
                            case "1":
                                parsedData.StoryFireInFront = true;
                                break;
                        }
                    }
                    if (rawMapData[i].StartsWith("UseSkinSprites:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "0" :
                                parsedData.UseSkinSprites = false;
                                break;
                            case "1":
                                parsedData.UseSkinSprites = true;
                                break;
                        }
                    }
                    if (rawMapData[i].StartsWith("AlwaysShowPlayfield:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "0" :
                                parsedData.AlwaysShowPlayfield = false;
                                break;
                            case "1":
                                parsedData.AlwaysShowPlayfield = true;
                                break;
                        }
                    }
                    if (rawMapData[i].StartsWith("OverlayPosition:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "NoChange":
                                parsedData.OverlayPosition = OverlayPos.NoChange;
                                break;
                            case "Below":
                                parsedData.OverlayPosition = OverlayPos.Below;
                                break;
                            case "Above":
                                parsedData.OverlayPosition = OverlayPos.Above;
                                break;
                        }
                    }
                    if (rawMapData[i].StartsWith("SkinPreference:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.SkinPreference = split[1];
                    }
                    if (rawMapData[i].StartsWith("EpilepsyWarning:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "0" :
                                parsedData.EpilepsyWarning = false;
                                break;
                            case "1":
                                parsedData.EpilepsyWarning = true;
                                break;
                        }
                    }
                    if (rawMapData[i].StartsWith("CountdownOffset:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.CountdownOffset = int.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("SpecialStyle:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "0" :
                                parsedData.SpecialStyle = false;
                                break;
                            case "1":
                                parsedData.SpecialStyle = true;
                                break;
                        }
                    }
                    if (rawMapData[i].StartsWith("WidescreenStoryboard:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "0" :
                                parsedData.WidescreenStoryboard = false;
                                break;
                            case "1":
                                parsedData.WidescreenStoryboard = true;
                                break;
                        }
                    }
                    if (rawMapData[i].StartsWith("SamplesMatchPlaybackRate:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        switch (split[1])
                        {
                            case "0" :
                                parsedData.SamplesMatchPlaybackRate = false;
                                break;
                            case "1":
                                parsedData.SamplesMatchPlaybackRate = true;
                                break;
                        }
                    }
                }
            #endregion
            #region [Editor]
                for (int i = editorIteration; i < rawMapData.Length; i++)
                {
                    if (rawMapData[i] == "")
                    {
                        break;
                    }

                    if (rawMapData[i].StartsWith("Bookmarks:"))
                    {
                        
                    }
                }
            #endregion
            
            
            
            
            
        }

        
    }
}