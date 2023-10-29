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

            for (int i = 0; i < rawMapData.Length; i++)
            {
                switch (rawMapData[i])
                {
                    case "[General]":
                        break;
                }
            }
                        
        }
    }
}