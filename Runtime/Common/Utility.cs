using System.Runtime.InteropServices;
using UnityEngine;

namespace Common
{
    public static class Utility
    {
        /// <summary>
        /// Creates a vector which X,Y Components individually are clamped between their min/max counterparts
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static Vector2 Clamp(this Vector2 value, Vector2? min, Vector2? max)
        {
            return new Vector2(Mathf.Clamp(value.x, min?.x ?? value.x, max?.x ?? value.x), Mathf.Clamp(value.y, min?.y ?? value.y, max?.y ?? value.y));
        }

        /// <summary>
        /// Creates a vector which X,Y Components individually are clamped between their min/max counterparts
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minX">Minimum value for x or null for no minimum</param>
        /// <param name="minY">Minimum value for y or null for no minimum</param>
        /// <param name="maxX">Maximum value for x or null for no maximum</param>
        /// <param name="maxY">Maximum value for y or null for no maximum</param>
        /// <returns></returns>
        public static Vector2 Clamp(this Vector2 value, float? minX, float? minY, float? maxX, float? maxY)
        {
            return new Vector2(Mathf.Clamp(value.x, minX ?? value.x, maxX ?? value.x), Mathf.Clamp(value.y, minY ?? value.y, maxY ?? value.y));
        }

        /// <summary>
        /// Returns whether the given vector is inside the given coordinates, use null values for limitless bounds
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public static bool IsInside(this Vector2 value, float? minX, float? minY, float? maxX, float? maxY)
        {
            minX ??= value.x;
            minY ??= value.y;
            maxX ??= value.x;
            maxY ??= value.y;

            return !(value.x > maxX || value.x < minX || value.y > maxY || value.y < minY);
        }

        /// <summary>
        /// Returns the vector2 with the x,y values of the vector3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2 V2(this Vector3 value)
        {
            return new Vector2(value.x, value.y);
        }

        /// <summary>
        /// Returns the vector3 with the x,y values of the vector2 and a new value for z, default is 0
        /// </summary>
        /// <param name="value"></param>
        /// <param name="zValue"></param>
        /// <returns></returns>
        public static Vector3 V3(this Vector2 value, float zValue = 0)
        {
            return new Vector3(value.x, value.y, zValue);
        }

        /// <summary>
        /// Rotates a 2d Vector clockwise
        /// </summary>
        /// <param name="v"></param>
        /// <param name="degrees"></param>
        /// <param name="useRad">Set to true if degrees is a radiant value</param>
        /// <returns></returns>
        public static Vector2 Rotate(this Vector2 v, float degrees, bool useRad = false)
        {
            var rad = degrees * (useRad ? 1 : Mathf.Deg2Rad);
            
            float sin = Mathf.Sin(rad);
            float cos = Mathf.Cos(rad);

            float tx = v.x;
            float ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }

        [DllImport("__Internal")]
        private static extern bool IsMobile();

        public static bool IsRunningOnMobile()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
                                     return IsMobile();
#endif
            return false;
        }
    }
}


