using System;
using UnityEngine;
using ColossalFramework.UI;
using System.Reflection;

namespace RenderIt.Helpers
{
    public static class GameOptionsHelper
    {
        public static int GetColorCorrectionOverrideInOptionsGraphicsPanel()
        {
            try
            {
                OptionsGraphicsPanel _optionsGraphicsPanel = GameObject.Find("Graphics")?.GetComponent<OptionsGraphicsPanel>();

                if (_optionsGraphicsPanel != null)
                {
                    UIDropDown colorCorrectionDropdown = _optionsGraphicsPanel.GetType().GetField("m_ColorCorrectionDropdown", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_optionsGraphicsPanel) as UIDropDown;

                    return colorCorrectionDropdown.selectedIndex;
                }

                return -1;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] GameOptionsHelper:GetColorCorrectionOverrideInOptionsGraphicsPanel -> Exception: " + e.Message);
                return -1;
            }
        }

        public static void SetColorCorrectionOverrideInOptionsGraphicsPanel(int index)
        {
            try
            {
                OptionsGraphicsPanel _optionsGraphicsPanel = GameObject.Find("Graphics")?.GetComponent<OptionsGraphicsPanel>();

                if (_optionsGraphicsPanel != null)
                {
                    UIDropDown colorCorrectionDropdown = _optionsGraphicsPanel.GetType().GetField("m_ColorCorrectionDropdown", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_optionsGraphicsPanel) as UIDropDown;

                    colorCorrectionDropdown.selectedIndex = index;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] GameOptionsHelper:SetColorCorrectionOverrideInOptionsGraphicsPanel -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] GameOptionsHelper:GetDepthOfFieldInOptionsGraphicsPanel -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] GameOptionsHelper:SetDepthOfFieldInOptionsGraphicsPanel -> Exception: " + e.Message);
            }
        }

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
                Debug.Log("[Render It!] GameOptionsHelper:GetAntialiasingInOptionsGraphicsPanel -> Exception: " + e.Message);
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
                Debug.Log("[Render It!] GameOptionsHelper:SetAntialiasingInOptionsGraphicsPanel -> Exception: " + e.Message);
            }
        }
    }
}
