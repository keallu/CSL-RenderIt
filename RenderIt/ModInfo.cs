using Harmony;
using ICities;
using System;
using System.Reflection;

namespace RenderIt
{
    public class ModInfo : IUserMod
    {
        public string Name => "Render It!";
        public string Description => "Allows to change render processing.";

        public void OnEnabled()
        {
            var harmony = HarmonyInstance.Create("com.github.keallu.csl.renderit");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void OnDisabled()
        {
            var harmony = HarmonyInstance.Create("com.github.keallu.csl.renderit");
            harmony.UnpatchAll();
        }

        public static readonly string[] AntialiasingTechniqueLabels =
        {
            "Default",
            "FXAA",
            "TAA"
        };

        public static readonly int[] AntialiasingTechniqueValues =
        {
            0,
            1,
            2
        };

        public static readonly string[] FXAAQualityLabels =
        {
            "Extreme Performance",
            "Performance",
            "Default",
            "Quality",
            "Extreme Quality"
        };

        public static readonly int[] FXAAQualityValues =
        {
            0,
            1,
            2,
            3,
            4
        };

        public static readonly string[] AOSampleCountLabels =
        {
            "Lowest",
            "Low",
            "Medium",
            "High"
        };

        public static readonly int[] AOSampleCountValues =
        {
            3,
            6,
            10,
            16
        };

        public static readonly string[] CGTonemapperLabels =
        {
            "None",
            "ACES",
            "Neutral"
        };

        public static readonly int[] CGTonemapperValues =
        {
            0,
            1,
            2
        };

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            bool selected;
            int selectedInt;
            float selectedFloat;


            group = helper.AddGroup(Name);

            selectedInt = ModConfig.Instance.AntialiasingTechnique;
            group.AddDropdown("Anti-aliasing Technique", AntialiasingTechniqueLabels, selectedInt, sel =>
            {
                ModConfig.Instance.AntialiasingTechnique = AntialiasingTechniqueValues[sel];
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientOcclusionEnabled;
            group.AddCheckbox("Ambient Occlusion Enabled", selected, sel =>
            {
                ModConfig.Instance.AmbientOcclusionEnabled = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.BloomEnabled;
            group.AddCheckbox("Bloom Enabled", selected, sel =>
            {
                ModConfig.Instance.BloomEnabled = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ColorGradingEnabled;
            group.AddCheckbox("Color Grading Enabled", selected, sel =>
            {
                ModConfig.Instance.ColorGradingEnabled = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Fast Approximate Anti-aliasing (FXAA)");

            selectedInt = ModConfig.Instance.FXAAQuality;
            group.AddDropdown("Quality", FXAAQualityLabels, selectedInt, sel =>
            {
                ModConfig.Instance.FXAAQuality = FXAAQualityValues[sel];
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Temporal Anti-aliasing (TAA)");

            selectedFloat = ModConfig.Instance.TAAJitterSpread;
            group.AddSlider("Jitter Spread", 0.1f, 1f, 0.01f, selectedFloat, sel =>
            {
                ModConfig.Instance.TAAJitterSpread = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.TAASharpen;
            group.AddSlider("Sharpen", 0f, 3f, 0.03f, selectedFloat, sel =>
            {
                ModConfig.Instance.TAASharpen = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.TAAStationaryBlending;
            group.AddSlider("Stationary Blending", 0f, 0.99f, 0.01f, selectedFloat, sel =>
            {
                ModConfig.Instance.TAAStationaryBlending = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.TAAMotionBlending;
            group.AddSlider("Motion Blending", 0f, 0.99f, 0.01f, selectedFloat, sel =>
            {
                ModConfig.Instance.TAAMotionBlending = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Ambient Occlusion");

            selectedFloat = ModConfig.Instance.AOIntensity;
            group.AddSlider("Intensity", 0f, 4f, 0.1f, selectedFloat, sel =>
            {
                ModConfig.Instance.AOIntensity = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.AORadius;
            group.AddSlider("Radius", 0f, 4f, 0.1f, selectedFloat, sel =>
            {
                ModConfig.Instance.AORadius = sel;
                ModConfig.Instance.Save();
            });

            selectedInt = GetSelectedOptionIndex(AOSampleCountValues, ModConfig.Instance.AOSampleCount);
            group.AddDropdown("Sample Count", AOSampleCountLabels, selectedInt, sel =>
            {
                ModConfig.Instance.AOSampleCount = AOSampleCountValues[sel];
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AODownsampling;
            group.AddCheckbox("Downsampling", selected, sel =>
            {
                ModConfig.Instance.AODownsampling = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AOForceForwardCompatibility;
            group.AddCheckbox("Force Forward Compatibility", selected, sel =>
            {
                ModConfig.Instance.AOForceForwardCompatibility = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AOAmbientOnly;
            group.AddCheckbox("Ambient Only", selected, sel =>
            {
                ModConfig.Instance.AOAmbientOnly = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AOHighPrecision;
            group.AddCheckbox("High Precision", selected, sel =>
            {
                ModConfig.Instance.AOHighPrecision = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Bloom");

            selectedFloat = ModConfig.Instance.BloomIntensity;
            group.AddSlider("Intensity", 0f, 1f, 0.1f, selectedFloat, sel =>
            {
                ModConfig.Instance.BloomIntensity = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.BloomThreshold;
            group.AddSlider("Threshold", 0f, 2.2f, 0.1f, selectedFloat, sel =>
            {
                ModConfig.Instance.BloomThreshold = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.BloomSoftKnee;
            group.AddSlider("Soft Knee", 0f, 1f, 0.1f, selectedFloat, sel =>
            {
                ModConfig.Instance.BloomSoftKnee = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.BloomRadius;
            group.AddSlider("Radius", 1f, 7f, 0.1f, selectedFloat, sel =>
            {
                ModConfig.Instance.BloomRadius = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.BloomAntiFlicker;
            group.AddCheckbox("Anti Flicker", selected, sel =>
            {
                ModConfig.Instance.BloomAntiFlicker = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Color Grading");

            selectedFloat = ModConfig.Instance.CGPostExposure;
            group.AddSlider("Post Exposure", -2f, 2f, 0.1f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGPostExposure = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGTemperature;
            group.AddSlider("Temperature", -100f, 100f, 1f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGTemperature = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGTint;
            group.AddSlider("Tint", -100f, 100f, 1f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGTint = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGHueShift;
            group.AddSlider("Hue Shift", -180f, 180f, 1f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGHueShift = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGSaturation;
            group.AddSlider("Saturation", 0f, 2f, 0.1f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGSaturation = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGContrast;
            group.AddSlider("Contrast", 0f, 2f, 0.1f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGContrast = sel;
                ModConfig.Instance.Save();
            });

            selectedInt = ModConfig.Instance.CGTonemapper;
            group.AddDropdown("Tonemapper", CGTonemapperLabels, selectedInt, sel =>
            {
                ModConfig.Instance.CGTonemapper = CGTonemapperValues[sel];
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGNeutralBlackIn;
            group.AddSlider("Neutral Black In", -0.1f, 0.1f, 0.01f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGNeutralBlackIn = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGNeutralWhiteIn;
            group.AddSlider("Neutral White In", 1f, 20f, 1f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGNeutralWhiteIn = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGNeutralBlackOut;
            group.AddSlider("Neutral Black Out", -0.09f, 0.1f, 0.01f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGNeutralBlackOut = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGNeutralWhiteOut;
            group.AddSlider("Neutral White Out", 1f, 19f, 1f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGNeutralWhiteOut = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGNeutralWhiteLevel;
            group.AddSlider("Neutral White Level", 0.1f, 20f, 1f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGNeutralWhiteLevel = sel;
                ModConfig.Instance.Save();
            });

            selectedFloat = ModConfig.Instance.CGNeutralWhiteClip;
            group.AddSlider("Neutral White Clip", 1f, 10f, 0.5f, selectedFloat, sel =>
            {
                ModConfig.Instance.CGNeutralWhiteClip = sel;
                ModConfig.Instance.Save();
            });
        }

        private int GetSelectedOptionIndex(int[] option, int value)
        {
            int index = Array.IndexOf(option, value);
            if (index < 0) index = 0;

            return index;
        }
    }
}