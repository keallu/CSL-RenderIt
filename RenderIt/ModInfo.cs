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
        }

        private int GetSelectedOptionIndex(int[] option, int value)
        {
            int index = Array.IndexOf(option, value);
            if (index < 0) index = 0;

            return index;
        }
    }
}