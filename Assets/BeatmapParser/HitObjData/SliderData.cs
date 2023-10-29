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
        public List<string> edgeSets;
    }
}