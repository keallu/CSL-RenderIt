namespace RenderIt
{
    [ConfigurationPath("RenderItConfig.xml")]
    public class ModConfig
    {
        public bool ConfigUpdated { get; set; }
        public int AntialiasingTechnique { get; set; } = 1;
        public int FXAAQuality { get; set; } = 2;
        public float TAAJitterSpread { get; set; } = 0.75f;
        public float TAASharpen { get; set; } = 0.3f;
        public float TAAStationaryBlending { get; set; } = 0.95f;
        public float TAAMotionBlending { get; set; } = 0.85f;


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