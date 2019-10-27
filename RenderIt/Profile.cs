namespace RenderIt
{
    public class Profile
    {
        public string Name { get; set; } = "Unnamed";
        public bool Active { get; set; } = false;
        public int AntialiasingTechnique { get; set; } = 0;
        public bool AmbientOcclusionEnabled { get; set; } = false;
        public bool BloomEnabled { get; set; } = false;
        public bool ColorGradingEnabled { get; set; } = false;
        public int FXAAQuality { get; set; } = 2;
        public float TAAJitterSpread { get; set; } = 0.75f;
        public float TAASharpen { get; set; } = 0.3f;
        public float TAAStationaryBlending { get; set; } = 0.95f;
        public float TAAMotionBlending { get; set; } = 0.85f;
        public float AOIntensity { get; set; } = 1f;
        public float AORadius { get; set; } = 0.3f;
        public int AOSampleCount { get; set; } = 10;
        public bool AODownsampling { get; set; } = true;
        public bool AOForceForwardCompatibility { get; set; } = false;
        public bool AOAmbientOnly { get; set; } = false;
        public bool AOHighPrecision { get; set; } = false;
        public bool BloomVanillaBloomEnabled { get; set; } = false;
        public float BloomIntensity { get; set; } = 0.5f;
        public float BloomThreshold { get; set; } = 1.1f;
        public float BloomSoftKnee { get; set; } = 0.5f;
        public float BloomRadius { get; set; } = 4f;
        public bool BloomAntiFlicker { get; set; } = false;
        public bool CGVanillaTonemappingEnabled { get; set; } = false;
        public bool CGVanillaColorCorrectionLUTEnabled { get; set; } = false;
        public float CGPostExposure { get; set; } = 0f;
        public float CGTemperature { get; set; } = 0f;
        public float CGTint { get; set; } = 0f;
        public float CGHueShift { get; set; } = 0f;
        public float CGSaturation { get; set; } = 1f;
        public float CGContrast { get; set; } = 1f;
        public int CGTonemapper { get; set; } = 2;
        public float CGNeutralBlackIn { get; set; } = 0.02f;
        public float CGNeutralWhiteIn { get; set; } = 10f;
        public float CGNeutralBlackOut { get; set; } = 0f;
        public float CGNeutralWhiteOut { get; set; } = 10f;
        public float CGNeutralWhiteLevel { get; set; } = 5.3f;
        public float CGNeutralWhiteClip { get; set; } = 10f;

        public Profile()
        {

        }
    }
}
