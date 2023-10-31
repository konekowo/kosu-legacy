using System;
using UnityEngine;

namespace GameScripts.Curves
{
    public class Bezier : CurveType
    {
        private Vector2[] points;

        public Bezier(Vector2[] points)
        {
            this.points = points;
        }

        public override Vector2 pointAt(float t)
        {
            Vector2 c = new Vector2();
            int n = points.Length - 1;
            for (int i = 0; i <= n; i++) {
                double b = bernstein(i, n, t);
                c.x += Convert.ToSingle(points[i].x * b);
                c.y += Convert.ToSingle(points[i].y * b);
            }
            return c;
        }
        
        /**
         * Calculates the binomial coefficient.
         * http://en.wikipedia.org/wiki/Binomial_coefficient#Binomial_coefficient_in_programming_languages
         */
        private static long binomialCoefficient(int n, int k) {
            if (k < 0 || k > n)
                return 0;
            if (k == 0 || k == n)
                return 1;
            k = Mathf.Min(k, n - k);  // take advantage of symmetry
            long c = 1;
            for (int i = 0; i < k; i++)
                c = c * (n - i) / (i + 1);
            return c;
        }

        /**
         * Calculates the Bernstein polynomial.
         * @param i the index
         * @param n the degree of the polynomial (i.e. number of points)
         * @param t the t value [0, 1]
         */
        private static double bernstein(int i, int n, float t) {
            return binomialCoefficient(n, i) * Mathf.Pow(t, i) * Mathf.Pow(1 - t, n - i);
        }
        
    }
}