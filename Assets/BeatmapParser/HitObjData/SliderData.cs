using System.Collections.Generic;
using UnityEngine;

namespace BeatmapParser.HitObjData
{
    public enum CurveType
    {
        Linear,
        Bezier,
        CentripetalCatmull_Rom,
        PerfectCircle
    }
    public class SliderData : HitObjData
    {
        public int type = 1;
        public CurveType CurveType;
        public List<Vector2> CurvePoints = new List<Vector2>();
        public int slides;
        public float length;
        public List<int> edgeSounds = new List<int>();
        public string[] edgeSets;
        
        
        
        public float[] getScaledCurvePointsX()
        {
            List<float> scaledX = new List<float>();
            foreach (Vector2 vector in CurvePoints)
            {
                float pointX = vector.x / SongLoader.divideAmount - 5.2f;
                scaledX.Add(pointX);
            }

            return scaledX.ToArray();
        }
        
        public float[] getScaledCurvePointsY()
        {
            List<float> scaledY = new List<float>();
            foreach (Vector2 vector in CurvePoints)
            {
                float pointY = 0 - (vector.y / SongLoader.divideAmount - 4f);
                scaledY.Add(pointY);
            }

            return scaledY.ToArray();
        }
    }
}