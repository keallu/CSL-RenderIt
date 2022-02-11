using System.Collections.Generic;

namespace RenderIt
{
    [ConfigurationPath("RenderItConfig.xml")]
    public class ModConfig
    {
        public bool ConfigUpdated { get; set; }
        public bool ShowButton { get; set; } = true;
        public float ButtonPositionX { get; set; } = 0f;
        public float ButtonPositionY { get; set; } = 0f;
        public bool ShowPanel { get; set; } = true;
        public float PanelPositionX { get; set; } = 0f;
        public float PanelPositionY { get; set; } = 0f;
        public List<Profile> Profiles { get; set; } = new List<Profile> { };

    private static ModConfig instance;

        public static ModConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Configuration<ModConfig>.Load();
                }

                return instance;
            }
        }

        public void Save()
        {            
            Configuration<ModConfig>.Save();
            ConfigUpdated = true;
        }
    }
}