using System;
using UnityEngine;

namespace RenderIt
{
    public class ModProperties
    {
        public float ButtonDefaultPositionX { get; set; }
        public float ButtonDefaultPositionY { get; set; }
        public float PanelDefaultPositionX { get; set; }
        public float PanelDefaultPositionY { get; set; }
        public AssetBundle AssetBundle { get; set; }
        public Profile ActiveProfile { get; set; }

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
                ModConfig.Instance.ButtonPositionX = ButtonDefaultPositionX;
                ModConfig.Instance.ButtonPositionY = ButtonDefaultPositionY;
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
                ModConfig.Instance.PanelPositionX = PanelDefaultPositionX;
                ModConfig.Instance.PanelPositionY = PanelDefaultPositionY;
                ModConfig.Instance.Save();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ModProperties:ResetPanelPosition -> Exception: " + e.Message);
            }
        }
    }
}