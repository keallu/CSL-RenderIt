using System.Collections.Generic;
using System.Linq;

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
                foreach (Profile profile in AllProfiles)
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
            IsActiveProfileUpdated = true;
        }

        public void Reset()
        {
            _allProfiles = ModConfig.Instance.Profiles.Select(x => x.Clone()).ToList();

            _activeProfile = null;

            IsActiveProfileUpdated = true;
        }

        public void Save()
        {
            ModConfig.Instance.Profiles = _allProfiles.Select(x => x.Clone()).ToList();

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
