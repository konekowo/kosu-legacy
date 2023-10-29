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
            
            
            for (int i = 0; i < rawMapData.Length; i++)
            {
                switch (rawMapData[i])
                {
                    case "[General]":
                        generalIteration = i + 1;
                        break;
                    case "[Editor]":
                        generalIteration = i + 1;
                        break;
                    case "[Metadata]":
                        generalIteration = i + 1;
                        break;
                    case "[Events]":
                        generalIteration = i + 1;
                        break;
                    case "[TimingPoints]":
                        generalIteration = i + 1;
                        break;
                    case "[Colours]":
                        generalIteration = i + 1;
                        break;
                    case "[HitObjects]":
                        generalIteration = i + 1;
                        break;
                    
                }
            }
            
            
        }

        
    }
}