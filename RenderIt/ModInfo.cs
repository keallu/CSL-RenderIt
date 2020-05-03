using Harmony;
using ICities;
using System;
using System.Reflection;

namespace RenderIt
{
    public class ModInfo : IUserMod
    {
        private readonly string _harmonyId = "com.github.keallu.csl.renderit";
        private HarmonyInstance _harmony;

        public string Name => "Render It!";
        public string Description => "Allows to change render processing.";

    public void OnEnabled()
        {
            _harmony = HarmonyInstance.Create(_harmonyId);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());

            ModUtils.PatchOptionsGraphicsPanel(true);
        }

        public void OnDisabled()
        {
            _harmony.UnpatchAll(_harmonyId);
            _harmony = null;

            ModUtils.PatchOptionsGraphicsPanel(false);
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            bool selected;

            group = helper.AddGroup(Name);

            selected = ModConfig.Instance.ShowButton;
            group.AddCheckbox("Show Button", selected, sel =>
            {
                ModConfig.Instance.ShowButton = sel;
                ModConfig.Instance.Save();
            });
        }
    }
}