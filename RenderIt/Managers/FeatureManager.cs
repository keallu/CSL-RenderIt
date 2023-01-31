using RenderIt.Helpers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RenderIt.Managers
{
    public class FeatureManager
    {
        public enum Feature
        {
            LightColors,
            Sky,
            Fog
        }

        private readonly Dictionary<Feature, bool> _features = new Dictionary<Feature, bool>();

        private static FeatureManager instance;

        public static FeatureManager Instance
        {
            get
            {
                return instance ?? (instance = new FeatureManager());
            }
        }

        public void Initialize()
        {
            try
            {
                _features.Clear();

                _features.Add(Feature.LightColors, !CompatibilityHelper.IsAnyLightColorsManipulatingModsEnabled());
                _features.Add(Feature.Sky, !CompatibilityHelper.IsAnySkyManipulatingModsEnabled());
                _features.Add(Feature.Fog, !CompatibilityHelper.IsAnyFogManipulatingModsEnabled());
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] FeatureManager:Initialize -> Exception: " + e.Message);
            }
        }

        public bool IsAvailable(Feature feature)
        {
            bool available = false;

            try
            {
                if (_features == null || _features.Count < 1)
                {
                    Initialize();
                }                

                _features.TryGetValue(feature, out available);
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] FeatureManager:IsAvailable -> Exception: " + e.Message);                
            }

            return available;
        }
    }
}
