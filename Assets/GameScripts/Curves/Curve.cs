using System.Collections.Generic;
using BeatmapParser.HitObjData;
using UnityEngine;

namespace GameScripts.Curves
{
    public abstract class Curve
    {
        /** Points generated along the curve should be spaced this far apart. */
        protected static float CURVE_POINTS_SEPERATION = 5;

        /** The curve border color. */
        protected static Color borderColor;

        /** Whether mmsliders are supported. */
        private static bool mmsliderSupported = false;

        /** The associated HitObject. */
        protected SliderData hitObject;

        /** The scaled starting x, y coordinates. */
        protected float x, y;

        /** The scaled slider x, y coordinate lists. */
        protected float[] sliderX, sliderY;

        /** Points along the curve (set by inherited classes). */
        protected Vector2[] curve;
        
        protected Curve(SliderData hitObject, bool scaled) {
            this.hitObject = hitObject;
            if (scaled) {
                this.x = hitObject.getScaledX();
                this.y = hitObject.getScaledY();
                this.sliderX = hitObject.getScaledCurvePointsX();
                this.sliderY = hitObject.getScaledCurvePointsY();
            } else {
                this.x = hitObject.position.x;
                this.y = hitObject.position.y;

                List<float> curveX = new List<float>();
                List<float> curveY = new List<float>();
                
                foreach (Vector2 vector in this.hitObject.CurvePoints)
                {
                    curveX.Add(vector.x);
                    curveY.Add(vector.y);
                }
                
                this.sliderX = curveX.ToArray();
                this.sliderY = curveY.ToArray();
            }
        }
        
        
		

		/**
		 * Returns the points along the curve.
		 */
		public Vector2[] getCurvePoints() { return curve; }

		/**
		 * Returns the point on the curve at a value t.
		 * @param t the t value [0, 1]
		 * @return the position vector
		 */
		public abstract Vector2 pointAt(float t);

		

		/**
		 * Returns the angle of the first control point.
		 */
		public abstract float getEndAngle();

		/**
		 * Returns the angle of the last control point.
		 */
		public abstract float getStartAngle();

		/**
		 * Returns the scaled x coordinate of the control point at index i.
		 * @param i the control point index
		 */
		public float getX(int i) { return (i == 0) ? x : sliderX[i - 1]; }

		/**
		 * Returns the scaled y coordinate of the control point at index i.
		 * @param i the control point index
		 */
		public float getY(int i) { return (i == 0) ? y : sliderY[i - 1]; }

	
	        
        
    }
}