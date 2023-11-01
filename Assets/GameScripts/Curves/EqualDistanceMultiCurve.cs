using BeatmapParser.HitObjData;

namespace GameScripts.Curves
{
    public abstract class EqualDistanceMultiCurve : Curve
    {
        /** The angles of the first and last control points for drawing. */
        private float startAngle, endAngle;
    
        /** The number of points along the curve. */
        private int ncurve;
    
        /**
         * Constructor.
         * @param hitObject the associated HitObject
         * @param scaled whether to use scaled coordinates
         */
        public EqualDistanceMultiCurve(SliderData hitObject, bool scaled) 
            :base(hitObject, scaled)
        {
        }
    }
}