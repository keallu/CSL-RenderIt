using System.Collections.Generic;
using UnityEngine;

namespace RenderIt.Managers
{
    public class ProfileManager
    {
        public List<Profile> AllProfiles
        {
            get
            {
                return ModConfig.Instance.Profiles;
            }
        }

        private Profile _activeProfile;

        public Profile ActiveProfile
        {
            get
            {
                if (_activeProfile == null)
                {
                    if (ModConfig.Instance.Profiles.Count == 0)
                    {
                        _activeProfile = new Profile
                        {
                            Name = "Default",
                            Active = true
                        };
                        ModConfig.Instance.Profiles.Add(_activeProfile);
                    }
                    else if (ModConfig.Instance.Profiles.Count == 1)
                    {
                        _activeProfile = ModConfig.Instance.Profiles[0];
                        _activeProfile.Active = true;
                    }
                    else
                    {
                        _activeProfile = ModConfig.Instance.Profiles.Find(x => x.Active == true);

                        if (_activeProfile == null)
                        {
                            _activeProfile = ModConfig.Instance.Profiles[0];
                            _activeProfile.Active = true;
                        }
                    }
                }

                ReplaceUnspecifiedValues();

                return _activeProfile;
            }
            set
            {
                foreach (Profile profile in ModConfig.Instance.Profiles)
                {
                    profile.Active = false;
                }

                _activeProfile = value;
                _activeProfile.Active = true;

                Apply();
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
            ModConfig.Instance.Apply();
        }

        public void Save()
        { 
            ModConfig.Instance.Save();
        }

        private void ReplaceUnspecifiedValues()
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
        }
    }
}
