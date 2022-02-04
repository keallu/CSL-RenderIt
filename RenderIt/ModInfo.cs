using CitiesHarmony.API;
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
            HarmonyHelper.DoOnHarmonyReady(() => Patcher.PatchAll());
        }

        public void OnDisabled()
        {
            if (HarmonyHelper.IsHarmonyInstalled)
            {
                Patcher.UnpatchAll();
            }
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            bool selected;

            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();

            group = helper.AddGroup(Name + " - " + assemblyName.Version.Major + "." + assemblyName.Version.Minor);

            selected = ModConfig.Instance.ShowButton;
            group.AddCheckbox("Show Button", selected, sel =>
            {
                ModConfig.Instance.ShowButton = sel;
                ModConfig.Instance.Save();
            });

            group.AddSpace(10);

            group.AddButton("Reset Positioning of Panel", () =>
            {
                ModProperties.Instance.ResetPanelPosition();
            });

            group.AddSpace(10);

            group.AddButton("Reset Positioning of Button", () =>
            {
                ModProperties.Instance.ResetButtonPosition();
            });
        }
    }
}