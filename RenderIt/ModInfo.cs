using CitiesHarmony.API;
using ICities;

namespace RenderIt
{
    public class ModInfo : IUserMod
    {
        public string Name => "Render It!";
        public string Description => "Allows to change render processing.";

    public void OnEnabled()
        {
            HarmonyHelper.DoOnHarmonyReady(() => Patcher.PatchAll());

            ModUtils.PatchOptionsGraphicsPanel(true);
        }

        public void OnDisabled()
        {
            ModUtils.PatchOptionsGraphicsPanel(false);

            if (HarmonyHelper.IsHarmonyInstalled)
            {
                Patcher.UnpatchAll();
            }
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