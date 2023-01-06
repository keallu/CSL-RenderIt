using System;
using System.Collections.Generic;
using UnityEngine;

namespace RenderIt.Managers
{
    public class DefaultManager
    {
        private readonly Dictionary<string, object> _defaults = new Dictionary<string, object>();

        private static DefaultManager instance;

        public static DefaultManager Instance
        {
            get
            {
                return instance ?? (instance = new DefaultManager());
            }
        }

        public void Initialize()
        {
            try
            {
                _defaults.Clear();

                _defaults.Add("SunIntensity", DayNightProperties.instance.m_SunIntensity);
                _defaults.Add("SunShadowStrength", DayNightProperties.instance.sunLightSource.shadowStrength);
                _defaults.Add("MoonIntensity", DayNightProperties.instance.m_MoonIntensity);
                _defaults.Add("MoonShadowStrength", DayNightProperties.instance.moonLightSource.shadowStrength);
                _defaults.Add("SkyRayleighScattering", DayNightProperties.instance.m_RayleighScattering);
                _defaults.Add("SkyMieScattering", DayNightProperties.instance.m_MieScattering);
                _defaults.Add("SkyExposure", DayNightProperties.instance.m_Exposure);
                _defaults.Add("LightColors", (GradientColorKey[])DayNightProperties.instance.m_LightColor.colorKeys.Clone());
                _defaults.Add("SkyColors", (GradientColorKey[])DayNightProperties.instance.m_AmbientColor.skyColor.colorKeys.Clone());
                _defaults.Add("EquatorColors", (GradientColorKey[])DayNightProperties.instance.m_AmbientColor.equatorColor.colorKeys.Clone());
                _defaults.Add("GroundColors", (GradientColorKey[])DayNightProperties.instance.m_AmbientColor.groundColor.colorKeys.Clone());
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] DefaultManager:Initialize -> Exception: " + e.Message);
            }
        }

        public object Get(string name)
        {
            object obj = null;

            try
            {
                if (_defaults == null || _defaults.Count < 1)
                {
                    Initialize();
                }

                _defaults.TryGetValue(name, out object value);

                if (value != null)
                {
                    obj = value;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] DefaultManager:Get -> Exception: " + e.Message);
            }

            return obj;
        }
    }
}
