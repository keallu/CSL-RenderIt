using System;
using UnityEngine;
using System.Collections.Generic;

namespace RenderIt.Helpers
{
    public static class ColorsHelper
    {
        public static List<Profile.TimedColor> ConvertToTimedColorList(GradientColorKey[] gradientColorKeys)
        {
            try
            {
                List<Profile.TimedColor> colors = new List<Profile.TimedColor>();

                Color32 color;

                foreach (GradientColorKey gradientColorKey in gradientColorKeys)
                {
                    color = new Color(gradientColorKey.color.r, gradientColorKey.color.g, gradientColorKey.color.b, gradientColorKey.color.a);

                    colors.Add(new Profile.TimedColor(color.r, color.g, color.b, color.a, Mathf.Round(gradientColorKey.time * 1000f) / 1000f));
                }

                return colors;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorsHelper:ConvertToTimedColorList -> Exception: " + e.Message);
                return null;
            }
        }

        public static GradientColorKey[] ConvertToGradientColorKeyArray(List<Profile.TimedColor> timedColors)
        {
            try
            {
                List<GradientColorKey> colors = new List<GradientColorKey>();

                foreach (Profile.TimedColor timedColor in timedColors)
                {
                    colors.Add(new GradientColorKey(new Color32(timedColor.Red, timedColor.Green, timedColor.Blue, timedColor.Alpha), timedColor.Time));
                }

                return colors.ToArray();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ColorsHelper:ConvertToGradientColorKeyArray -> Exception: " + e.Message);
                return null;
            }
        }
    }
}
