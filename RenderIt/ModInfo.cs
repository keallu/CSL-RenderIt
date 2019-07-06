using Harmony;
using ICities;
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

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            int selectedInt;
            float selectedFloat;

            group = helper.AddGroup(Name);

            selectedInt = ModConfig.Instance.AntialiasingTechnique;
            group.AddDropdown("Anti-aliasing Technique", AntialiasingTechniqueLabels, selectedInt, sel =>
            {
                ModConfig.Instance.AntialiasingTechnique = AntialiasingTechniqueValues[sel];
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
        }
    }
}