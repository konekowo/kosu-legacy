using System.Collections;
using UnityEngine;

namespace BeatmapParser.HitObjData
{
    public class HitObjData
    {
        public Vector2 position;
        public int hitSound;
        public ArrayList hitSample = new ArrayList();
        public int type;
    }
}