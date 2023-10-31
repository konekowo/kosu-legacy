using UnityEngine;

namespace GameScripts.Curves
{
    public abstract class CurveType
    {
        /** Points along the curve of the Bezier curve. */
        private Vector2[] curve;

        /** Distances between a point of the curve and the last point. */
        private float[] curveDis;

        /** The number of points along the curve. */
        private int ncurve;

        /** The total distances of this Bezier. */
        private float _totalDistance;
        
        public abstract Vector2 pointAt(float t);
        
        /**
     * Initialize the curve points and distance.
     * Must be called by inherited classes.
     * @param approxlength an approximate length of the curve
     */
        public void init(float approxlength) {
            // subdivide the curve
            this.ncurve = (int) (approxlength / 4) + 2;
            this.curve = new Vector2[ncurve];
            for (int i = 0; i < ncurve; i++)
                curve[i] = pointAt(i / (float) (ncurve - 1));

            // find the distance of each point from the previous point
            this.curveDis = new float[ncurve];
            this._totalDistance = 0;
            for (int i = 0; i < ncurve; i++) {
                curveDis[i] = (i == 0) ? 0 : len(curve[i] - (curve[i - 1]));
                _totalDistance += curveDis[i];
            }
        }

        /**
         * Returns the length of a vector.
         */
        public float len(Vector2 vector)
        {
            return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
        }
        
        /**
         * Returns the points along the curve of the Bezier curve.
         */
        public Vector2[] getCurvePoint() { return curve; }

        /**
         * Returns the distances between a point of the curve and the last point.
         */
        public float[] getCurveDistances() { return curveDis; }

        /**
         * Returns the number of points along the curve.
         */
        public int getCurvesCount() { return ncurve; }

        /**
         * Returns the total distances of this Bezier curve.
         */
        public float totalDistance() { return _totalDistance; }
        
    }
}