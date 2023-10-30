using System;
using System.Collections.Generic;
using System.IO;
using BeatmapParser.Exceptions;
using BeatmapParser.HitObjData;
using Unity.VisualScripting;
using UnityEngine;


namespace BeatmapParser
{
    public class BeatmapParser
    {
        private BeatmapData parsedData = new BeatmapData();
        
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
            
            string[] rawMapData = File.ReadAllLines(mapLocation);
            // throw error if map file is in wrong format version
            if (!rawMapData[0].StartsWith("osu file format v14") && !rawMapData[0].StartsWith("osu file format v13") 
                                                                 && !rawMapData[0].StartsWith("osu file format v12"))
            {
                throw new BeatMapNotSupportedException("This BeatMap's format ("+rawMapData[0]+") is not supported. ");
            }

            int generalIteration = 0;
            int editorIteration = 0;
            int difficultyIteration = 0;
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
                    case "[Difficulty]":
                        difficultyIteration = i + 1;
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
                    if (rawMapData[i].StartsWith("["))
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
                    if (rawMapData[i].StartsWith("["))
                    {
                        break;
                    }

                    if (rawMapData[i].StartsWith("Bookmarks:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.Bookmarks = split[1].Split(',');
                    }
                    if (rawMapData[i].StartsWith("DistanceSpacing:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.DistanceSpacing = float.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("BeatDivisor:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.BeatDivisor = int.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("GridSize:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.GridSize = int.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("TimelineZoom:"))
                    {
                        string[] split = rawMapData[i].Split(": ");
                        parsedData.TimelineZoom = float.Parse(split[1]);
                    }
                    
                }
            #endregion
            #region [Metadata]
                for (int i = metadataIteration; i < rawMapData.Length; i++)
                {
                    if (rawMapData[i].StartsWith("["))
                    {
                        break;
                    }
                    
                    if (rawMapData[i].StartsWith("Title:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.Title = split[1];
                    }
                    if (rawMapData[i].StartsWith("TitleUnicode:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.TitleUnicode = split[1];
                    }
                    if (rawMapData[i].StartsWith("Artist:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.Artist = split[1];
                    }
                    if (rawMapData[i].StartsWith("ArtistUnicode:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.ArtistUnicode = split[1];
                    }
                    if (rawMapData[i].StartsWith("Creator:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.Creator = split[1];
                    }
                    if (rawMapData[i].StartsWith("Version:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.Version = split[1];
                    }
                    if (rawMapData[i].StartsWith("Source:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.Source = split[1];
                    }
                    if (rawMapData[i].StartsWith("Tags:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.Tags = split[1].Split(" ");
                    }
                    if (rawMapData[i].StartsWith("BeatmapID:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.BeatmapID = int.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("BeatmapSetID:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.BeatmapSetID = int.Parse(split[1]);
                    }
                }
            #endregion
            #region [Difficulty]
                for (int i = difficultyIteration; i < rawMapData.Length; i++)
                {
                    if (rawMapData[i].StartsWith("["))
                    {
                        break;
                    }
                    if (rawMapData[i].StartsWith("HPDrainRate:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.HPDrainRate = float.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("CircleSize:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.CircleSize = float.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("OverallDifficulty:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.OverallDifficulty = float.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("ApproachRate:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.ApproachRate = float.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("SliderMultiplier:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.SliderMultiplier = float.Parse(split[1]);
                    }
                    if (rawMapData[i].StartsWith("SliderTickRate:"))
                    {
                        string[] split = rawMapData[i].Split(":");
                        parsedData.SliderTickRate = float.Parse(split[1]);
                    }
                }
            #endregion
            #region [Events]
                for (int i = eventIteration; i < rawMapData.Length; i++)
                {
                    if (rawMapData[i].StartsWith("["))
                    {
                        break;
                    }

                    if (rawMapData[i].StartsWith("//Background and Video events"))
                    {
                        bool weird = rawMapData[i+1].StartsWith("Video");
                        if (weird)
                        {
                            string[] split0 = rawMapData[i+1].Split(",");
                            parsedData.BackgroundVideoName = split0[2].Split('"')[1];
                            parsedData.BackgroundVideoStartTime = split0[1];
                            string[] split1 = rawMapData[i+2].Split(",");
                            parsedData.BackgroundImageName = split1[2].Split('"')[1];
                        }
                        else
                        {
                            if (rawMapData[i + 2].StartsWith("Video"))
                            {
                                string[] split0 = rawMapData[i+2].Split(",");
                                parsedData.BackgroundVideoName = split0[2].Split('"')[1];
                                parsedData.BackgroundVideoStartTime = split0[1];
                            }
                            string[] split1 = rawMapData[i+1].Split(",");
                            parsedData.BackgroundImageName = split1[2].Split('"')[1];




                        }
                    }
                }
            #endregion
            #region [TimingPoints]
                for (int i = timingPointsIteration; i < rawMapData.Length; i++)
                {
                    if (rawMapData[i].StartsWith("["))
                    {
                        break;
                    }
                    if (rawMapData[i] == "")
                    {
                        continue;
                    }
                    string[] split = rawMapData[i].Split(",");
                    TimingPoint timingPoint = new TimingPoint(int.Parse(split[0]), float.Parse(split[1]), int.Parse(split[2]), 
                        int.Parse(split[3]), int.Parse(split[4]),
                        int.Parse(split[5]), split[6] == "1"? true : false, int.Parse(split[7]));
                    parsedData.TimingPoints.Add(timingPoint);
                }
            #endregion
            #region [Colours]
                for (int i = colorsIteration; i < rawMapData.Length; i++)
                {
                    if (rawMapData[i].StartsWith("["))
                    {
                        break;
                    }

                    if (rawMapData[i].StartsWith("Combo"))
                    {
                        ComboColor comboColor = new ComboColor();
                        comboColor.ComboNumber = rawMapData[i][5];
                        string[] split = rawMapData[i].Split(": ");
                        string[] color = split[1].Split(",");
                        comboColor.color = new Color(int.Parse(color[0]), int.Parse(color[1]), 
                            int.Parse(color[2]));
                        parsedData.ComboColors.Add(comboColor);
                    }
                    // Skipping SliderTrackOverride and SliderBorder because I can't find a BeatMap that uses these.
                }
            #endregion
            #region [HitObjects]
                for (int i = hitObjectsIteration; i < rawMapData.Length; i++)
                {
                    if (rawMapData[i] == "")
                    {
                        break;
                    }

                    string[] split = rawMapData[i].Split(",");
                    // Hit Circle
                    if (split.Length == 6)
                    {
                        HitCircleData hitCircleData = new HitCircleData();
                        hitCircleData.position = new Vector2(
                            int.Parse(split[0]), 
                            int.Parse(split[1]));
                        hitCircleData.time = int.Parse(split[2]);
                        hitCircleData.hitSound = int.Parse(split[4]);
                        string[] hitSampleRaw = split[5].Split(":");
                        List<int> hitSample = new List<int>();
                        for (int x = 0; x < hitSampleRaw.Length; x++)
                        {
                            if (hitSampleRaw[x] != "")
                            {
                                hitSample.Add(int.Parse(hitSampleRaw[x]));
                            }
                        }
                        hitCircleData.hitSample = hitSample;
                        hitCircleData.newCombo = split[3] == "2";
                        if (split[3] == "4" || split[3] == "5" || split[3] == "6")
                        {
                            hitCircleData.colorHaxBitIndex = int.Parse(split[3]);
                            hitCircleData.newCombo = true;
                        }
                        
                        parsedData.HitCircles.Add(hitCircleData);
                    }
                    // Slider
                    if (split.Length == 11)
                    {
                        SliderData hitSliderData = new SliderData();
                        hitSliderData.position = new Vector2(
                            int.Parse(split[0]), 
                            int.Parse(split[1]));
                        hitSliderData.time = int.Parse(split[2]);
                        hitSliderData.hitSound = int.Parse(split[4]);
                        string[] hitSampleRaw = split[10].Split(":");
                        List<int> hitSample = new List<int>();
                        for (int x = 0; x < hitSampleRaw.Length; x++)
                        {
                            if (hitSampleRaw[x] != "")
                            {
                                hitSample.Add(int.Parse(hitSampleRaw[x]));
                            }
                        }
                        hitSliderData.hitSample = hitSample;

                        string[] curveData = split[5].Split("|");
                        switch (curveData[0])
                        {
                            case "L":
                                hitSliderData.CurveType = CurveType.Linear;
                                break;
                            case "B":
                                hitSliderData.CurveType = CurveType.Bezier;
                                break;
                            case "C":
                                hitSliderData.CurveType = CurveType.CentripetalCatmull_Rom;
                                break;
                            case "P":
                                hitSliderData.CurveType = CurveType.PerfectCircle;
                                break;
                        }

                        for (int x = 1; x < curveData.Length; x++)
                        {
                            string[] split1 = curveData[x].Split(":");
                            hitSliderData.CurvePoints.Add(new Vector2(int.Parse(split1[0]), 
                                int.Parse(split1[1])));
                        }

                        hitSliderData.slides = int.Parse(split[6]);
                        hitSliderData.length = float.Parse(split[7]);
                        string[] edgeSounds = split[8].Split("|");
                        for (int x = 0; x < edgeSounds.Length; x++)
                        {
                            hitSliderData.edgeSounds.Add(int.Parse(edgeSounds[x]));
                        }
                        string[] edgeSets = split[9].Split("|");
                        hitSliderData.edgeSets = edgeSets;
                        hitSliderData.newCombo = split[3] == "2";
                        if (split[3] == "4" || split[3] == "5" || split[3] == "6")
                        {
                            hitSliderData.colorHaxBitIndex = int.Parse(split[3]);
                            hitSliderData.newCombo = true;
                        }
                        parsedData.Sliders.Add(hitSliderData);
                    }
                    // Spinner
                    if (split.Length == 7)
                    {
                        SpinnerData spinnerData = new SpinnerData();
                        spinnerData.position = new Vector2(
                            int.Parse(split[0]), 
                            int.Parse(split[1]));
                        spinnerData.time = int.Parse(split[2]);
                        spinnerData.hitSound = int.Parse(split[4]);
                        string[] hitSampleRaw = split[6].Split(":");
                        List<int> hitSample = new List<int>();
                        for (int x = 0; x < hitSampleRaw.Length; x++)
                        {
                            if (hitSampleRaw[x] != "")
                            {
                                hitSample.Add(int.Parse(hitSampleRaw[x]));
                            }
                        }
                        spinnerData.hitSample = hitSample;
                        spinnerData.newCombo = split[3] == "2";
                        if (split[3] == "4" || split[3] == "5" || split[3] == "6")
                        {
                            spinnerData.colorHaxBitIndex = int.Parse(split[3]);
                            spinnerData.newCombo = true;
                        }

                        spinnerData.endTime = int.Parse(split[5]);
                        
                        parsedData.Spinners.Add(spinnerData);
                    }
                }
            #endregion
            
            
            
        }

        public BeatmapData GetParsedData()
        {
            return parsedData;
        }
        
    }
}