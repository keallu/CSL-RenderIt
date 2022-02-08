namespace RenderIt
{
    public static class ModInvariables
    {
        public static readonly string[] SharpnessAssetType =
        {
            "General",
            "Buildings",
            "Networks",
            "Props",
            "Citizens",
            "Vehicles",
            "Trees"
        };

        public static readonly string[] AnisoLevels =
        {
            "1 (no filtering)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9 (full filtering)"
        };

        public static readonly int[] AnisoLevelsValues =
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9
        };

        public static readonly string[] MipMapBias =
        {
            "-0.5 (sharpen)",
            "-0.4",
            "-0.3",
            "-0.2",
            "-0.1",
            "0.0",
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5 (blur)"
        };

        public static readonly float[] MipMapBiasValues =
        {
            -0.5f,
            -0.4f,
            -0.3f,
            -0.2f,
            -0.1f,
            0.0f,
            0.1f,
            0.2f,
            0.3f,
            0.4f,
            0.5f
        };

        public static readonly string[] AntialiasingTechnique =
        {
            "None",
            "Default",
            "FXAA",
            "TAA"
        };

        public static readonly string[] FXAAQuality =
        {
            "Extreme Performance",
            "Performance",
            "Default",
            "Quality",
            "Extreme Quality"
        };

        public static readonly string[] AOSampleCount =
        {
            "Lowest",
            "Low",
            "Medium",
            "High"
        };

        public static readonly string[] CGTonemapper =
        {
            "None",
            "ACES",
            "Neutral"
        };

        public static readonly string[] CGChannel =
        {
            "Red",
            "Green",
            "Blue"
        };
    }
}
