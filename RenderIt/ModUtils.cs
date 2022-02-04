using ColossalFramework.UI;
using System;
using System.Reflection;
using UnityEngine;

namespace RenderIt
{
    public static class ModUtils
    {
        public static int GetAntialiasingInOptionsGraphicsPanel()
        {
            try
            {
                OptionsGraphicsPanel _optionsGraphicsPanel = GameObject.Find("Graphics")?.GetComponent<OptionsGraphicsPanel>();

                if (_optionsGraphicsPanel != null)
                {
                    UIDropDown antialiasingDropdown = _optionsGraphicsPanel.GetType().GetField("m_AntialiasingDropdown", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_optionsGraphicsPanel) as UIDropDown;

                    return antialiasingDropdown.selectedIndex;
                }

                return -1;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModUtils:GetAntialiasingInOptionsGraphicsPanel -> Exception: " + e.Message);
                return -1;
            }
        }

        public static void SetAntialiasingInOptionsGraphicsPanel(bool enabled)
        {
            try
            {
                OptionsGraphicsPanel _optionsGraphicsPanel = GameObject.Find("Graphics")?.GetComponent<OptionsGraphicsPanel>();

                if (_optionsGraphicsPanel != null)
                {
                    UIDropDown antialiasingDropdown = _optionsGraphicsPanel.GetType().GetField("m_AntialiasingDropdown", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_optionsGraphicsPanel) as UIDropDown;

                    antialiasingDropdown.selectedIndex = enabled ? 1 : 0;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModUtils:SetAntialiasingInOptionsGraphicsPanel -> Exception: " + e.Message);
            }
        }

        public static int GetDepthOfFieldInOptionsGraphicsPanel()
        {
            try
            {
                OptionsGraphicsPanel _optionsGraphicsPanel = GameObject.Find("Graphics")?.GetComponent<OptionsGraphicsPanel>();

                if (_optionsGraphicsPanel != null)
                {
                    UIDropDown dofTypeDropdown = _optionsGraphicsPanel.GetType().GetField("m_DOFTypeDropdown", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_optionsGraphicsPanel) as UIDropDown;

                    return dofTypeDropdown.selectedIndex;
                }

                return -1;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModUtils:GetDepthOfFieldInOptionsGraphicsPanel -> Exception: " + e.Message);
                return -1;
            }
        }

        public static void SetDepthOfFieldInOptionsGraphicsPanel(bool enabled)
        {
            try
            {
                OptionsGraphicsPanel _optionsGraphicsPanel = GameObject.Find("Graphics")?.GetComponent<OptionsGraphicsPanel>();

                if (_optionsGraphicsPanel != null)
                {
                    UIDropDown dofTypeDropdown = _optionsGraphicsPanel.GetType().GetField("m_DOFTypeDropdown", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_optionsGraphicsPanel) as UIDropDown;

                    dofTypeDropdown.selectedIndex = enabled ? 2 : 0;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModUtils:SetDepthOfFieldInOptionsGraphicsPanel -> Exception: " + e.Message);
            }
        }
    }
}
