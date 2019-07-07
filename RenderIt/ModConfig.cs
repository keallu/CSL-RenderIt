namespace RenderIt
{
    [ConfigurationPath("RenderItConfig.xml")]
    public class ModConfig
    {
        public bool ConfigUpdated { get; set; }
        public int AntialiasingTechnique { get; set; } = 1;
        public bool AmbientOcclusionEnabled { get; set; } = false;
        public bool BloomEnabled { get; set; } = false;
        public int FXAAQuality { get; set; } = 2;
        public float TAAJitterSpread { get; set; } = 0.75f;
        public float TAASharpen { get; set; } = 0.3f;
        public float TAAStationaryBlending { get; set; } = 0.95f;
        public float TAAMotionBlending { get; set; } = 0.85f;
        public float AOIntensity { get; set; } = 2f;
        public float AORadius { get; set; } = 2f;
        public int AOSampleCount { get; set; } = 10;
        public bool AODownsampling { get; set; } = true;
        public bool AOForceForwardCompatibility { get; set; } = false;
        public bool AOAmbientOnly { get; set; } = false;
        public bool AOHighPrecision { get; set; } = false;
        public float BloomIntensity { get; set; } = 0.5f;
        public float BloomThreshold { get; set; } = 1.1f;
        public float BloomSoftKnee { get; set; } = 0.5f;
        public float BloomRadius { get; set; } = 4f;
        public bool BloomAntiFlicker { get; set; } = false;

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