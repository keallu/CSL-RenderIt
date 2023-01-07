namespace RenderIt.Helpers
{
    public static class CompatibilityHelper
    {
        public static readonly string[] LIGHT_COLORS_MANIPULATING_MODS = { "lightingrebalance", "daylightclassic", "softershadows" };

        public static readonly string[] SKY_MANIPULATING_MODS = { "thememixer" };

        public static bool IsAnyLightColorsManipulatingModsEnabled()
        {
            if (ModUtils.IsAnyModsEnabled(LIGHT_COLORS_MANIPULATING_MODS))
            {
                return true;
            }

            return false;
        }

        public static bool IsAnySkyManipulatingModsEnabled()
        {
            if (ModUtils.IsAnyModsEnabled(SKY_MANIPULATING_MODS))
            {
                return true;
            }

            return false;
        }
    }
}
