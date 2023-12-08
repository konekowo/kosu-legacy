using System.Collections.Generic;
using UnityEngine;
using BeatmapParser.util;

namespace BeatmapParser.HitObjData
{
    public class HitObjData
    {
        public Vector2 position;
        public int hitSound;
        public List<int> hitSample;
        public int type;
        public int time;
        public bool newCombo;
        public int colorHaxBitIndex;
        public int hitObjNum;
        public int hitObjNumReverse;
        
        public float getScaledX()
        {
            return position.x / SongLoader.divideAmount - 5.2f;
        }

        public Vector2 GetGamePosition()
        {
            return OsuPixelsToGameVector.ConvertToGameVector(position, Camera.main);
        }
        
        public float getScaledY()
        {
            return 0 - (position.y / SongLoader.divideAmount - 4f);
        }
        
    }
}