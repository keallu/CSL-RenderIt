using RenderIt.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RenderIt.Managers
{
    public class ProfileManager
    {
        public bool IsActiveProfileUpdated { get; set; }

        private List<Profile> _allProfiles;

        public List<Profile> AllProfiles
        {
            get
            {
                if (_allProfiles == null)
                {
                    _allProfiles = ModConfig.Instance.Profiles.Select(x => x.Clone()).ToList();
                }

                _allProfiles.Sort();

                return _allProfiles;
            }
        }

        private Profile _activeProfile;

        public Profile ActiveProfile
        {
            get
            {
                if (_activeProfile == null)
                {
                    if (AllProfiles.Count == 0)
                    {
                        _activeProfile = new Profile
                        {
                            Name = "Default",
                            Active = true
                        };
                        AllProfiles.Add(_activeProfile);
                    }
                    else if (AllProfiles.Count == 1)
                    {
                        _activeProfile = AllProfiles[0];
                        _activeProfile.Active = true;
                    }
                    else
                    {
                        _activeProfile = AllProfiles.Find(x => x.Active == true);

                        if (_activeProfile == null)
                        {
                            _activeProfile = AllProfiles[0];
                            _activeProfile.Active = true;
                        }
                    }
                }

                ReplaceUnspecifiedValues();

                return _activeProfile;
            }
            set
            {
                if (value != null)
                {
                    foreach (Profile profile in AllProfiles)
                    {
                        profile.Active = false;
                    }

                    _activeProfile = value;
                    _activeProfile.Active = true;

                    Apply();
                }
                else
                {
                    _activeProfile = value;
                }
            }
        }

        private static ProfileManager instance;

        public static ProfileManager Instance
        {
            get
            {
                return instance ?? (instance = new ProfileManager());
            }
        }

        public void Apply()
        {
            IsActiveProfileUpdated = true;
        }

        public void Reset()
        {
            try
            {
                _allProfiles = ModConfig.Instance.Profiles.Select(x => x.Clone()).ToList();

                _activeProfile = null;

                IsActiveProfileUpdated = true;
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ProfileManager:Reset -> Exception: " + e.Message);
            }
        }

        public void Save()
        {
            try
            {
                ModConfig.Instance.Profiles = _allProfiles.Select(x => x.Clone()).ToList();

                ModConfig.Instance.Save();
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ProfileManager:Save -> Exception: " + e.Message);
            }
        }

        private void ReplaceUnspecifiedValues()
        {
            try
            {
                if (float.IsNaN(_activeProfile.SunIntensity))
                {
                    _activeProfile.SunIntensity = (float)DefaultManager.Instance.Get("SunIntensity");
                }

                if (float.IsNaN(_activeProfile.SunShadowStrength))
                {
                    _activeProfile.SunShadowStrength = (float)DefaultManager.Instance.Get("SunShadowStrength");
                }

                if (float.IsNaN(_activeProfile.MoonIntensity))
                {
                    _activeProfile.MoonIntensity = (float)DefaultManager.Instance.Get("MoonIntensity");
                }

                if (float.IsNaN(_activeProfile.MoonShadowStrength))
                {
                    _activeProfile.MoonShadowStrength = (float)DefaultManager.Instance.Get("MoonShadowStrength");
                }

                if (float.IsNaN(_activeProfile.SkyRayleighScattering))
                {
                    _activeProfile.SkyRayleighScattering = (float)DefaultManager.Instance.Get("SkyRayleighScattering");
                }

                if (float.IsNaN(_activeProfile.SkyMieScattering))
                {
                    _activeProfile.SkyMieScattering = (float)DefaultManager.Instance.Get("SkyMieScattering");
                }

                if (float.IsNaN(_activeProfile.SkyExposure))
                {
                    _activeProfile.SkyExposure = (float)DefaultManager.Instance.Get("SkyExposure");
                }

                if (float.IsNaN(_activeProfile.SkyRedWaveLength))
                {
                    _activeProfile.SkyRedWaveLength = (float)DefaultManager.Instance.Get("SkyRedWaveLength");
                }

                if (float.IsNaN(_activeProfile.SkyGreenWaveLength))
                {
                    _activeProfile.SkyGreenWaveLength = (float)DefaultManager.Instance.Get("SkyGreenWaveLength");
                }

                if (float.IsNaN(_activeProfile.SkyBlueWaveLength))
                {
                    _activeProfile.SkyBlueWaveLength = (float)DefaultManager.Instance.Get("SkyBlueWaveLength");
                }

                if (_activeProfile.LightColors.Count < 1)
                {
                    _activeProfile.LightColors = ColorsHelper.ConvertToTimedColorList((GradientColorKey[])DefaultManager.Instance.Get("LightColors"));
                }

                if (_activeProfile.SkyColors.Count < 1)
                {
                    _activeProfile.SkyColors = ColorsHelper.ConvertToTimedColorList((GradientColorKey[])DefaultManager.Instance.Get("SkyColors"));
                }

                if (_activeProfile.EquatorColors.Count < 1)
                {
                    _activeProfile.EquatorColors = ColorsHelper.ConvertToTimedColorList((GradientColorKey[])DefaultManager.Instance.Get("EquatorColors"));
                }

                if (_activeProfile.GroundColors.Count < 1)
                {
                    _activeProfile.GroundColors = ColorsHelper.ConvertToTimedColorList((GradientColorKey[])DefaultManager.Instance.Get("GroundColors"));
                }

                if (float.IsNaN(_activeProfile.FogHeight))
                {
                    _activeProfile.FogHeight = (float)DefaultManager.Instance.Get("FogHeight");
                }

                if (float.IsNaN(_activeProfile.FogHorizonHeight))
                {
                    _activeProfile.FogHorizonHeight = (float)DefaultManager.Instance.Get("FogHorizonHeight");
                }

                if (float.IsNaN(_activeProfile.FogDensity))
                {
                    _activeProfile.FogDensity = (float)DefaultManager.Instance.Get("FogDensity");
                }

                if (float.IsNaN(_activeProfile.FogStart))
                {
                    _activeProfile.FogStart = (float)DefaultManager.Instance.Get("FogStart");
                }

                if (float.IsNaN(_activeProfile.FogDistance))
                {
                    _activeProfile.FogDistance = (float)DefaultManager.Instance.Get("FogDistance");
                }

                if (float.IsNaN(_activeProfile.FogEdgeDistance))
                {
                    _activeProfile.FogEdgeDistance = (float)DefaultManager.Instance.Get("FogEdgeDistance");
                }

                if (float.IsNaN(_activeProfile.FogNoiseContribution))
                {
                    _activeProfile.FogNoiseContribution = (float)DefaultManager.Instance.Get("FogNoiseContribution");
                }

                if (float.IsNaN(_activeProfile.FogPollutionAmount))
                {
                    _activeProfile.FogPollutionAmount = (float)DefaultManager.Instance.Get("FogPollutionAmount");
                }

                if (float.IsNaN(_activeProfile.FogColorDecay))
                {
                    _activeProfile.FogColorDecay = (float)DefaultManager.Instance.Get("FogColorDecay");
                }

                if (float.IsNaN(_activeProfile.FogScattering))
                {
                    _activeProfile.FogScattering = (float)DefaultManager.Instance.Get("FogScattering");
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Render It!] ProfileManager:ReplaceUnspecifiedValues -> Exception: " + e.Message);
            }
        }
    }
}
