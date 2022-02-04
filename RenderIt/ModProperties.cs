using ColossalFramework.UI;
using System;
using UnityEngine;

namespace RenderIt
{
    public class ModProperties
    {
        private static ModProperties instance;

        public static ModProperties Instance
        {
            get
            {
                return instance ?? (instance = new ModProperties());
            }
        }

        public void ResetButtonPosition()
        {
            try
            {
                int modCollectionButtonPosition = 2;

                ModConfig.Instance.ButtonPositionX = 10f;
                ModConfig.Instance.ButtonPositionY = UIView.GetAView().GetScreenResolution().y * 0.875f - (modCollectionButtonPosition * 36f) - 5f;
                ModConfig.Instance.Save();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModProperties:ResetButtonPosition -> Exception: " + e.Message);
            }
        }

        public void ResetPanelPosition()
        {
            try
            {
                ModConfig.Instance.PanelPositionX = 10f;
                ModConfig.Instance.PanelPositionY = 10f;
                ModConfig.Instance.Save();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModProperties:ResetPanelPosition -> Exception: " + e.Message);
            }
        }
    }
}