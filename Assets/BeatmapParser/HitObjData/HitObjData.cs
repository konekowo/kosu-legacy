using System.Collections.Generic;
using UnityEngine;

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
        
        
        public float getScaledX()
        {
            return position.x / SongLoader.divideAmount - 5.2f;
        }
        
        public float getScaledY()
        {
            return 0 - (position.y / SongLoader.divideAmount - 4f);
        }
        
    }
}