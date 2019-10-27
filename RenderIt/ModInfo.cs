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

            ModUtils.PatchOptionsGraphicsPanel(true);
        }

        public void OnDisabled()
        {
            var harmony = HarmonyInstance.Create("com.github.keallu.csl.renderit");
            harmony.UnpatchAll();

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