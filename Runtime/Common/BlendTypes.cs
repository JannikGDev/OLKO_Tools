using UnityEngine;

namespace Common
{
    public static class BlendTypes
    {

        public enum BlendType
        {
            Simple,
            Multiply
        }

        public static Color Blend(this BlendType blendType, Color baseColor, Color foreColor, float blendVal)
        {
            switch(blendType)
            {
                case BlendType.Simple:
                    return BlendSimple(baseColor, foreColor, blendVal);
                case BlendType.Multiply:
                    return BlendMultiplicative(baseColor, foreColor, blendVal);
                default:
                    return Color.black;
            }
        }

        public static Color BlendSimple(this Color baseColor, Color foreColor, float blendVal)
        {
            float r = foreColor.r * blendVal + baseColor.r * (1 - blendVal);
            float g = foreColor.g * blendVal + baseColor.g * (1 - blendVal);
            float b = foreColor.b * blendVal + baseColor.b * (1 - blendVal);
            return new Color(r, g, b);
        }

        public static Color BlendMultiplicative(this Color baseColor, Color foreColor, float blendVal)
        {
            float r = baseColor.r * (1+(-1 + foreColor.r)*blendVal);
            float g = baseColor.g * (1 + (-1 + foreColor.g) * blendVal);
            float b = baseColor.b * (1 + (-1 + foreColor.b) * blendVal);
            return new Color(r, g, b);
        }

    }
}
