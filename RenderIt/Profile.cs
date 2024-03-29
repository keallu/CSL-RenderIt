﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RenderIt
{
    public class Profile : IComparable<Profile>
    {
        public string Name { get; set; } = "Unnamed";
        public bool Active { get; set; } = false;
        public int ShadowType { get; set; } = -1;
        public int ShadowResolution { get; set; } = -1;
        public int ShadowProjection { get; set; } = -1;
        public float SunIntensity { get; set; } = float.NaN;
        public float SunShadowStrength { get; set; } = float.NaN;
        public bool SunShadowBiasEnabled { get; set; } = false;
        public float SunShadowBias { get; set; } = float.NaN;
        public float MoonIntensity { get; set; } = float.NaN;
        public float MoonShadowStrength { get; set; } = float.NaN;
        public bool MoonShadowBiasEnabled { get; set; } = false;
        public float MoonShadowBias { get; set; } = float.NaN;
        public float SkyRayleighScattering { get; set; } = float.NaN;
        public float SkyMieScattering { get; set; } = float.NaN;
        public float SkyExposure { get; set; } = float.NaN;
        public float SkyRedWaveLength { get; set; } = float.NaN;
        public float SkyGreenWaveLength { get; set; } = float.NaN;
        public float SkyBlueWaveLength { get; set; } = float.NaN;
        public bool LightColorsEnabled { get; set; } = false;
        public List<TimedColor> LightColors { get; set; } = new List<TimedColor> { };
        public bool SkyColorsEnabled { get; set; } = false;
        public List<TimedColor> SkyColors { get; set; } = new List<TimedColor> { };
        public bool EquatorColorsEnabled { get; set; } = false;
        public List<TimedColor> EquatorColors { get; set; } = new List<TimedColor> { };
        public bool GroundColorsEnabled { get; set; } = false;
        public List<TimedColor> GroundColors { get; set; } = new List<TimedColor> { };
        public int GeneralAnisoLevel { get; set; } = 0;
        public int GeneralMipMapBias { get; set; } = 5;
        public bool GeneralLODIncluded { get; set; } = false;
        public int BuildingsAnisoLevel { get; set; } = 3;
        public int BuildingsMipMapBias { get; set; } = 5;
        public bool BuildingsLODIncluded { get; set; } = false;
        public int NetworksAnisoLevel { get; set; } = 4;
        public int NetworksMipMapBias { get; set; } = 5;
        public bool NetworksLODIncluded { get; set; } = false;
        public int PropsAnisoLevel { get; set; } = 3;
        public int PropsMipMapBias { get; set; } = 5;
        public bool PropsLODIncluded { get; set; } = false;
        public int CitizensAnisoLevel { get; set; } = 3;
        public int CitizensMipMapBias { get; set; } = 5;
        public bool CitizensLODIncluded { get; set; } = false;
        public int VehiclesAnisoLevel { get; set; } = 3;
        public int VehiclesMipMapBias { get; set; } = 5;
        public bool VehiclesLODIncluded { get; set; } = false;
        public int TreesAnisoLevel { get; set; } = 3;
        public int TreesMipMapBias { get; set; } = 5;
        public bool TreesLODIncluded { get; set; } = false;
        public bool FogEnabled { get; set; } = false;
        public bool FogDayNightEnabled { get; set; } = true;
        public float FogHeight { get; set; } = float.NaN;
        public float FogHorizonHeight { get; set; } = float.NaN;
        public float FogDensity { get; set; } = float.NaN;
        public float FogStart { get; set; } = float.NaN;
        public float FogDistance { get; set; } = float.NaN;
        public float FogEdgeDistance { get; set; } = float.NaN;
        public float FogNoiseContribution { get; set; } = float.NaN;
        public float FogPollutionAmount { get; set; } = float.NaN;
        public float FogColorDecay { get; set; } = float.NaN;
        public float FogScattering { get; set; } = float.NaN;
        public int AntialiasingTechnique { get; set; } = 0;
        public bool VanillaBloomEnabled { get; set; } = true;
        public bool VanillaTonemappingEnabled { get; set; } = true;
        public bool VanillaColorCorrectionLutEnabled { get; set; } = true;
        public string VanillaColorCorrectionLutName { get; set; } = "None";
        public bool AmbientOcclusionEnabled { get; set; } = false;
        public bool BloomEnabled { get; set; } = false;
        public bool ColorGradingEnabled { get; set; } = false;
        public int FXAAQuality { get; set; } = 2;
        public float TAAJitterSpread { get; set; } = 0.75f;
        public float TAAStationaryBlending { get; set; } = 0.95f;
        public float TAAMotionBlending { get; set; } = 0.85f;
        public float TAASharpen { get; set; } = 0.3f;
        public float AOIntensity { get; set; } = 1f;
        public float AORadius { get; set; } = 0.3f;
        public int AOSampleCount { get; set; } = 10;
        public bool AODownsampling { get; set; } = true;
        public bool AOForceForwardCompatibility { get; set; } = false;
        public bool AOHighPrecision { get; set; } = false;
        public bool AOAmbientOnly { get; set; } = false;
        public float BloomIntensity { get; set; } = 0.5f;
        public float BloomThreshold { get; set; } = 1.1f;
        public float BloomSoftKnee { get; set; } = 0.5f;
        public float BloomRadius { get; set; } = 4f;
        public bool BloomAntiFlicker { get; set; } = false;
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
        public float CGChannelMixerRedRed { get; set; } = 1f;
        public float CGChannelMixerRedGreen { get; set; } = 0f;
        public float CGChannelMixerRedBlue { get; set; } = 0f;
        public float CGChannelMixerGreenRed { get; set; } = 0f;
        public float CGChannelMixerGreenGreen { get; set; } = 1f;
        public float CGChannelMixerGreenBlue { get; set; } = 0f;
        public float CGChannelMixerBlueRed { get; set; } = 0f;
        public float CGChannelMixerBlueGreen { get; set; } = 0f;
        public float CGChannelMixerBlueBlue { get; set; } = 1f;

        public Profile()
        {

        }

        public Profile Clone()
        {
            Profile other = (Profile)MemberwiseClone();
            other.Name = string.Copy(Name);
            other.LightColors = LightColors.Select(x => x.Clone()).ToList();
            other.SkyColors = SkyColors.Select(x => x.Clone()).ToList();
            other.EquatorColors = EquatorColors.Select(x => x.Clone()).ToList();
            other.GroundColors = GroundColors.Select(x => x.Clone()).ToList();
            other.VanillaColorCorrectionLutName = string.Copy(VanillaColorCorrectionLutName);
            return other;
        }

        public int CompareTo(Profile other)
        {
            return other == null ? 1 : Name.CompareTo(other.Name);
        }

        public class TimedColor
        {
            public byte Red { get; set; }
            public byte Green { get; set; }
            public byte Blue { get; set; }
            public byte Alpha { get; set; }
            public float Time { get; set; }

            public TimedColor()
            {
                Red = 0;
                Green = 0;
                Blue = 0;
                Alpha = 0;
                Time = 0f;
            }

            public TimedColor(byte red, byte green, byte blue, byte alpha, float time)
            {
                Red = red;
                Green = green;
                Blue = blue;
                Alpha = alpha;
                Time = time;
            }

            public TimedColor Clone()
            {
                TimedColor other = (TimedColor)MemberwiseClone();
                return other;
            }
        }
    }
}
