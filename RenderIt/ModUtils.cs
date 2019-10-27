using ColossalFramework.UI;
using System;
using System.Reflection;
using UnityEngine;

namespace RenderIt
{
    public static class ModUtils
    {
        public static void PatchOptionsGraphicsPanel(bool patch)
        {
            try
            {
                OptionsGraphicsPanel _optionsGraphicsPanel = GameObject.Find("Graphics").GetComponent<OptionsGraphicsPanel>();

                if (_optionsGraphicsPanel != null)
                {
                    UIDropDown antialiasingDropdown = _optionsGraphicsPanel.GetType().GetField("m_AntialiasingDropdown", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_optionsGraphicsPanel) as UIDropDown;

                    if (patch)
                    {
                        antialiasingDropdown.isInteractive = false;
                        antialiasingDropdown.opacity = 0.3f;
                    }
                    else
                    {
                        antialiasingDropdown.isInteractive = true;
                        antialiasingDropdown.opacity = 1f;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModUtils:PatchOptionsGraphicsPanel -> Exception: " + e.Message);
            }
        }

        public static void UpdateOptionsGraphicsPanel()
        {
            try
            {
                OptionsGraphicsPanel _optionsGraphicsPanel = GameObject.Find("Graphics").GetComponent<OptionsGraphicsPanel>();

                if (_optionsGraphicsPanel != null)
                {
                    UIDropDown antialiasingDropdown = _optionsGraphicsPanel.GetType().GetField("m_AntialiasingDropdown", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_optionsGraphicsPanel) as UIDropDown;

                    antialiasingDropdown.selectedIndex = ModProperties.Instance.ActiveProfile.AntialiasingTechnique == 1 ? 1 : 0;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModManager:UpdateOptionsGraphicsPanel -> Exception: " + e.Message);
            }
        }
    }
}
