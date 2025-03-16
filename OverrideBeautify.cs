using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using static Beautify.Universal.Beautify;

[ExecuteAlways]
public class OverrideBeautify : MonoBehaviour
{
	//disabled : UnityEngine.Rendering.BoolParameter
	//compareMode : UnityEngine.Rendering.BoolParameter
	//compareStyle : Beautify.Universal.Beautify+BeautifyCompareStyleParameter
	//comparePanning : UnityEngine.Rendering.ClampedFloatParameter
	//compareLineAngle : UnityEngine.Rendering.FloatParameter
	//compareLineWidth : UnityEngine.Rendering.FloatParameter
	//flipY : UnityEngine.Rendering.BoolParameter
	//hideInSceneView : UnityEngine.Rendering.BoolParameter
	//debugOutput : Beautify.Universal.Beautify+BeautifyDebugOutputParameter
	//turboMode : UnityEngine.Rendering.BoolParameter
	//directWrite : UnityEngine.Rendering.BoolParameter
	//ignoreDepthTexture : UnityEngine.Rendering.BoolParameter
	//downsampling : UnityEngine.Rendering.BoolParameter
	//downsamplingMode : Beautify.Universal.Beautify+BeautifyDownsamplingModeParameter
	//downsamplingMultiplier : UnityEngine.Rendering.ClampedFloatParameter
	//downsamplingBilinear : UnityEngine.Rendering.BoolParameter
	//optimizeBuildBeautifyAuto : UnityEngine.Rendering.BoolParameter
	//stripBeautifyTonemapping : UnityEngine.Rendering.BoolParameter
	//stripBeautifyTonemappingACESFitted : UnityEngine.Rendering.BoolParameter
	//stripBeautifyTonemappingAGX : UnityEngine.Rendering.BoolParameter
	//stripBeautifySharpen : UnityEngine.Rendering.BoolParameter
	//stripBeautifyDithering : UnityEngine.Rendering.BoolParameter
	//stripBeautifyEdgeAA : UnityEngine.Rendering.BoolParameter
	//stripBeautifyLUT : UnityEngine.Rendering.BoolParameter
	//stripBeautifyLUT3D : UnityEngine.Rendering.BoolParameter
	//stripBeautifyColorTweaks : UnityEngine.Rendering.BoolParameter
	//stripBeautifyBloom : UnityEngine.Rendering.BoolParameter
	//stripBeautifyLensDirt : UnityEngine.Rendering.BoolParameter
	//stripBeautifyChromaticAberration : UnityEngine.Rendering.BoolParameter
	//stripBeautifyDoF : UnityEngine.Rendering.BoolParameter
	//stripBeautifyDoFTransparentSupport : UnityEngine.Rendering.BoolParameter
	//stripBeautifyEyeAdaptation : UnityEngine.Rendering.BoolParameter
	//stripBeautifyPurkinje : UnityEngine.Rendering.BoolParameter
	//stripBeautifyVignetting : UnityEngine.Rendering.BoolParameter
	//stripBeautifyOutline : UnityEngine.Rendering.BoolParameter
	//stripBeautifyNightVision : UnityEngine.Rendering.BoolParameter
	//stripBeautifyThermalVision : UnityEngine.Rendering.BoolParameter
	//stripBeautifyFrame : UnityEngine.Rendering.BoolParameter
	//optimizeBuildUnityPPSAuto : UnityEngine.Rendering.BoolParameter
	//stripUnityFilmGrain : UnityEngine.Rendering.BoolParameter
	//stripUnityDithering : UnityEngine.Rendering.BoolParameter
	//stripUnityTonemapping : UnityEngine.Rendering.BoolParameter
	//stripUnityBloom : UnityEngine.Rendering.BoolParameter
	//stripUnityChromaticAberration : UnityEngine.Rendering.BoolParameter
	//stripUnityDistortion : UnityEngine.Rendering.BoolParameter
	//stripUnityDebugVariants : UnityEngine.Rendering.BoolParameter
	//sharpenIntensity : UnityEngine.Rendering.ClampedFloatParameter
	//sharpenDepthThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//sharpenMinMaxDepth : Beautify.Universal.Beautify+MinMaxFloatParameter
	//sharpenMinMaxDepthFallOff : UnityEngine.Rendering.ClampedFloatParameter
	//sharpenRelaxation : UnityEngine.Rendering.ClampedFloatParameter
	//sharpenClamp : UnityEngine.Rendering.ClampedFloatParameter
	//sharpenMotionSensibility : UnityEngine.Rendering.ClampedFloatParameter
	//sharpenMotionRestoreSpeed : UnityEngine.Rendering.ClampedFloatParameter
	//antialiasStrength : UnityEngine.Rendering.ClampedFloatParameter
	//antialiasDepthThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//antialiasSpread : UnityEngine.Rendering.ClampedFloatParameter
	//antialiasDepthAttenuation : UnityEngine.Rendering.FloatParameter
	//tonemap : Beautify.Universal.Beautify+BeautifyTonemapOperatorParameter
	//tonemapAGXGamma : UnityEngine.Rendering.FloatParameter
	//tonemapMaxInputBrightness : UnityEngine.Rendering.FloatParameter
	//tonemapExposurePre : UnityEngine.Rendering.FloatParameter
	//tonemapBrightnessPost : UnityEngine.Rendering.FloatParameter
	//saturate : UnityEngine.Rendering.ClampedFloatParameter
	//brightness : UnityEngine.Rendering.ClampedFloatParameter
	//contrast : UnityEngine.Rendering.ClampedFloatParameter
	//daltonize : UnityEngine.Rendering.ClampedFloatParameter
	//sepia : UnityEngine.Rendering.ClampedFloatParameter
	//tintColor : UnityEngine.Rendering.ColorParameter
	//colorTemp : UnityEngine.Rendering.ClampedFloatParameter
	//colorTempBlend : UnityEngine.Rendering.ClampedFloatParameter
	//lut : UnityEngine.Rendering.BoolParameter
	//lutIntensity : UnityEngine.Rendering.ClampedFloatParameter
	//lutTexture : UnityEngine.Rendering.TextureParameter
	//bloomIntensity : UnityEngine.Rendering.FloatParameter
	//bloomThreshold : UnityEngine.Rendering.FloatParameter
	//bloomConservativeThreshold : UnityEngine.Rendering.BoolParameter
	//bloomSpread : UnityEngine.Rendering.ClampedFloatParameter
	//bloomMaxBrightness : UnityEngine.Rendering.FloatParameter
	//bloomTint : UnityEngine.Rendering.ColorParameter
	//bloomDepthAtten : UnityEngine.Rendering.FloatParameter
	//bloomNearAtten : UnityEngine.Rendering.FloatParameter
	//bloomExcludeLayers : UnityEngine.Rendering.BoolParameter
	//bloomLayersFilterMethod : Beautify.Universal.Beautify+BeautifyBloomLayersFilterMethodParameter
	//bloomExclusionLayerMask : Beautify.Universal.Beautify+BeautifyLayerMaskParameter
	//bloomAntiflicker : UnityEngine.Rendering.BoolParameter
	//bloomResolution : UnityEngine.Rendering.ClampedIntParameter
	//bloomQuickerBlur : UnityEngine.Rendering.BoolParameter
	//bloomCustomize : UnityEngine.Rendering.BoolParameter
	//bloomWeight0 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomBoost0 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomTint0 : UnityEngine.Rendering.ColorParameter
	//bloomWeight1 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomBoost1 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomTint1 : UnityEngine.Rendering.ColorParameter
	//bloomWeight2 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomBoost2 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomTint2 : UnityEngine.Rendering.ColorParameter
	//bloomWeight3 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomBoost3 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomTint3 : UnityEngine.Rendering.ColorParameter
	//bloomWeight4 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomBoost4 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomTint4 : UnityEngine.Rendering.ColorParameter
	//bloomWeight5 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomBoost5 : UnityEngine.Rendering.ClampedFloatParameter
	//bloomTint5 : UnityEngine.Rendering.ColorParameter
	//anamorphicFlaresIntensity : UnityEngine.Rendering.FloatParameter
	//anamorphicFlaresThreshold : UnityEngine.Rendering.FloatParameter
	//anamorphicFlaresConservativeThreshold : UnityEngine.Rendering.BoolParameter
	//anamorphicFlaresTint : UnityEngine.Rendering.ColorParameter
	//anamorphicFlaresVertical : UnityEngine.Rendering.BoolParameter
	//anamorphicFlaresSpread : UnityEngine.Rendering.ClampedFloatParameter
	//anamorphicFlaresMaxBrightness : UnityEngine.Rendering.FloatParameter
	//anamorphicFlaresDepthAtten : UnityEngine.Rendering.FloatParameter
	//anamorphicFlaresNearAtten : UnityEngine.Rendering.FloatParameter
	//anamorphicFlaresExcludeLayers : UnityEngine.Rendering.BoolParameter
	//anamorphicFlaresLayersFilterMethod : Beautify.Universal.Beautify+BeautifyBloomLayersFilterMethodParameter
	//anamorphicFlaresExclusionLayerMask : Beautify.Universal.Beautify+BeautifyLayerMaskParameter
	//anamorphicFlaresAntiflicker : UnityEngine.Rendering.BoolParameter
	//anamorphicFlaresResolution : UnityEngine.Rendering.ClampedIntParameter
	//anamorphicFlaresQuickerBlur : UnityEngine.Rendering.BoolParameter
	//sunFlaresIntensity : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresTint : UnityEngine.Rendering.ColorParameter
	//sunFlaresSolarWindSpeed : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresRotationDeadZone : UnityEngine.Rendering.BoolParameter
	//sunFlaresDownsampling : UnityEngine.Rendering.ClampedIntParameter
	//sunFlaresDepthOcclusionMode : Beautify.Universal.Beautify+BeautifySunFlaresDepthOcclusionMode
	//sunFlaresDepthOcclusionThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresUseLayerMask : UnityEngine.Rendering.BoolParameter
	//sunFlaresLayerMask : Beautify.Universal.Beautify+BeautifyLayerMaskParameter
	//sunFlaresAttenSpeed : UnityEngine.Rendering.FloatParameter
	//sunFlaresSunIntensity : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresSunDiskSize : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresSunRayDiffractionIntensity : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresSunRayDiffractionThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresCoronaRays1Length : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresCoronaRays1Streaks : UnityEngine.Rendering.ClampedIntParameter
	//sunFlaresCoronaRays1Spread : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresCoronaRays1AngleOffset : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresCoronaRays2Length : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresCoronaRays2Streaks : UnityEngine.Rendering.ClampedIntParameter
	//sunFlaresCoronaRays2Spread : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresCoronaRays2AngleOffset : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts1Size : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts1Offset : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts1Brightness : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts2Size : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts2Offset : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts2Brightness : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts3Size : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts3Offset : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts3Brightness : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts4Size : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts4Offset : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresGhosts4Brightness : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresHaloOffset : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresHaloAmplitude : UnityEngine.Rendering.ClampedFloatParameter
	//sunFlaresHaloIntensity : UnityEngine.Rendering.ClampedFloatParameter
	//lensDirtIntensity : UnityEngine.Rendering.FloatParameter
	//lensDirtThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//lensDirtTexture : UnityEngine.Rendering.TextureParameter
	//lensDirtSpread : UnityEngine.Rendering.ClampedIntParameter
	//chromaticAberrationIntensity : UnityEngine.Rendering.FloatParameter
	//chromaticAberrationShift : UnityEngine.Rendering.ClampedFloatParameter
	//chromaticAberrationSmoothing : UnityEngine.Rendering.FloatParameter
	//chromaticAberrationSeparatePass : UnityEngine.Rendering.BoolParameter
	//depthOfField : UnityEngine.Rendering.BoolParameter
	//depthOfFieldFocusMode : Beautify.Universal.Beautify+BeautifyDoFFocusModeParameter
	//depthOfFieldAutofocusMinDistance : UnityEngine.Rendering.FloatParameter
	//depthOfFieldAutofocusMaxDistance : UnityEngine.Rendering.FloatParameter
	//depthOfFieldTargetFallback : Beautify.Universal.Beautify+DoFTargetFallbackParameter
	//depthOfFieldTargetFallbackFixedDistance : UnityEngine.Rendering.FloatParameter
	//depthOfFieldAutofocusViewportPoint : UnityEngine.Rendering.Vector2Parameter
	//depthOfFieldAutofocusDistanceShift : UnityEngine.Rendering.FloatParameter
	//depthOfFieldAutofocusLayerMask : Beautify.Universal.Beautify+BeautifyLayerMaskParameter
	//depthOfFieldDistance : UnityEngine.Rendering.FloatParameter
	//depthOfFieldCameraSettings : Beautify.Universal.Beautify+BeautifyDoFCameraSettingsParameter
	//depthOfFieldFocalLength : UnityEngine.Rendering.ClampedFloatParameter
	//depthOfFieldAperture : UnityEngine.Rendering.FloatParameter
	//depthOfFieldFocalLengthReal : UnityEngine.Rendering.ClampedFloatParameter
	//depthOfFieldFStop : UnityEngine.Rendering.ClampedFloatParameter
	//depthOfFieldImageSensorHeight : UnityEngine.Rendering.ClampedFloatParameter
	//depthOfFieldFocusSpeed : UnityEngine.Rendering.ClampedFloatParameter
	//depthOfFieldTransparentSupport : UnityEngine.Rendering.BoolParameter
	//depthOfFieldTransparentLayerMask : Beautify.Universal.Beautify+BeautifyLayerMaskParameter
	//depthOfFieldTransparentDoubleSided : UnityEngine.Rendering.BoolParameter
	//depthOfFieldAlphaTestSupport : UnityEngine.Rendering.BoolParameter
	//depthOfFieldAlphaTestLayerMask : Beautify.Universal.Beautify+BeautifyLayerMaskParameter
	//depthOfFieldAlphaTestDoubleSided : UnityEngine.Rendering.BoolParameter
	//depthOfFieldForegroundBlur : UnityEngine.Rendering.BoolParameter
	//depthOfFieldForegroundBlurHQ : UnityEngine.Rendering.BoolParameter
	//depthOfFieldForegroundBlurHQSpread : UnityEngine.Rendering.ClampedFloatParameter
	//depthOfFieldForegroundDistance : UnityEngine.Rendering.FloatParameter
	//depthOfFieldBokeh : UnityEngine.Rendering.BoolParameter
	//depthOfFieldBokehComposition : Beautify.Universal.Beautify+BeautifyDoFBokehCompositionParameter
	//depthOfFieldBokehThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//depthOfFieldBokehIntensity : UnityEngine.Rendering.ClampedFloatParameter
	//depthOfFieldDownsampling : UnityEngine.Rendering.ClampedIntParameter
	//depthOfFieldMaxSamples : UnityEngine.Rendering.ClampedIntParameter
	//depthOfFieldMaxBrightness : UnityEngine.Rendering.FloatParameter
	//depthOfFieldMaxBlurRadius : UnityEngine.Rendering.FloatParameter
	//depthOfFieldMaxDistance : UnityEngine.Rendering.ClampedFloatParameter
	//depthOfFieldFilterMode : Beautify.Universal.Beautify+BeautifyDoFFilterModeParameter
	//eyeAdaptation : UnityEngine.Rendering.BoolParameter
	//eyeAdaptationMinExposure : UnityEngine.Rendering.ClampedFloatParameter
	//eyeAdaptationMaxExposure : UnityEngine.Rendering.ClampedFloatParameter
	//eyeAdaptationSpeedToLight : UnityEngine.Rendering.ClampedFloatParameter
	//eyeAdaptationSpeedToDark : UnityEngine.Rendering.ClampedFloatParameter
	//purkinje : UnityEngine.Rendering.BoolParameter
	//purkinjeAmount : UnityEngine.Rendering.ClampedFloatParameter
	//purkinjeLuminanceThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//vignettingOuterRing : UnityEngine.Rendering.ClampedFloatParameter
	//vignettingInnerRing : UnityEngine.Rendering.ClampedFloatParameter
	//vignettingFade : UnityEngine.Rendering.ClampedFloatParameter
	//vignettingCircularShape : UnityEngine.Rendering.BoolParameter
	//vignettingCircularShapeFitMode : Beautify.Universal.Beautify+BeautifyVignetteFitMode
	//vignettingAspectRatio : UnityEngine.Rendering.ClampedFloatParameter
	//vignettingBlink : UnityEngine.Rendering.ClampedFloatParameter
	//vignettingBlinkStyle : Beautify.Universal.Beautify+BeautifyBlinkStyleParameter
	//vignettingCenter : UnityEngine.Rendering.Vector2Parameter
	//vignettingColor : UnityEngine.Rendering.ColorParameter
	//vignettingMask : UnityEngine.Rendering.TextureParameter
	//outline : UnityEngine.Rendering.BoolParameter
	//outlineColor : UnityEngine.Rendering.ColorParameter
	//outlineThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//outlineMinDepthThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//outlineSaturationDiffThreshold : UnityEngine.Rendering.ClampedFloatParameter
	//outlineCustomize : UnityEngine.Rendering.BoolParameter
	//outlineLayerMask : UnityEngine.Rendering.LayerMaskParameter
	//outlineStageParameter : Beautify.Universal.Beautify+BeautifyOutlineStageParameter
	//outlineSpread : UnityEngine.Rendering.ClampedFloatParameter
	//outlineBlurPassCount : UnityEngine.Rendering.ClampedIntParameter
	//outlineBlurDownscale : UnityEngine.Rendering.BoolParameter
	//outlineIntensityMultiplier : UnityEngine.Rendering.ClampedFloatParameter
	//outlineDistanceFade : UnityEngine.Rendering.FloatParameter
	//outlineUsesOptimizedShader : UnityEngine.Rendering.BoolParameter
	//outlineLayerCutOff : UnityEngine.Rendering.ClampedFloatParameter
	//nightVision : UnityEngine.Rendering.BoolParameter
	//nightVisionColor : UnityEngine.Rendering.ColorParameter
	//nightVisionDepth : UnityEngine.Rendering.FloatParameter
	//nightVisionDepthFallOff : UnityEngine.Rendering.ClampedFloatParameter
	//thermalVision : UnityEngine.Rendering.BoolParameter
	//thermalVisionScanLines : UnityEngine.Rendering.BoolParameter
	//thermalVisionDistortionAmount : UnityEngine.Rendering.ClampedFloatParameter
	//ditherIntensity : UnityEngine.Rendering.ClampedFloatParameter
	//frame : UnityEngine.Rendering.BoolParameter
	//frameStyle : Beautify.Universal.Beautify+BeautifyFrameStyleParameter
	//frameBandHorizontalSize : UnityEngine.Rendering.ClampedFloatParameter
	//frameBandHorizontalSmoothness : UnityEngine.Rendering.ClampedFloatParameter
	//frameBandVerticalSize : UnityEngine.Rendering.ClampedFloatParameter
	//frameBandVerticalSmoothness : UnityEngine.Rendering.ClampedFloatParameter
	//frameColor : UnityEngine.Rendering.ColorParameter
	//frameMask : UnityEngine.Rendering.TextureParameter
	//blurIntensity : UnityEngine.Rendering.ClampedFloatParameter
	//blurMask : UnityEngine.Rendering.TextureParameter
	//blurKeepSourceOnTop : UnityEngine.Rendering.BoolParameter
	//blurSourceRect : UnityEngine.Rendering.Vector4Parameter
	//blurSourceEdgeBlendWidth : UnityEngine.Rendering.ClampedFloatParameter
	//blurSourceEdgeBlendStrength : UnityEngine.Rendering.FloatParameter
	//downsamplingUsed : System.Int32
	//active : System.Boolean
	//parameterList : System.Collections.Generic.List`1[UnityEngine.Rendering.VolumeParameter]


	[Header("Global Volume")]
	public Volume globalVolume;

	[Space(10), Header("Anamorphic Override")]
	[Range(0f, 10f)] public float anamorphicThreshold;
	[Range(0f, 10f)] public float anamorphicIntensity;
	private float lastAnamorphicThreshold;
	private float lastAnamorphicIntensity;

	private VolumeComponent targetComponent;

	private void Start()
	{
		if (globalVolume == null) return;

		VolumeProfile profile = globalVolume.profile;

		if (profile == null) return;

		foreach (VolumeComponent component in profile.components)
		{
			if (component.name.StartsWith("Beautify"))
			{
				targetComponent = component;
				UpdateVariable(targetComponent);
			}
		}
	}

	private void LateUpdate()
	{
		float currentAnamorphicThreshold = anamorphicThreshold;
		float currentAnamorphicIntensity = anamorphicIntensity;

		if (currentAnamorphicThreshold != lastAnamorphicThreshold ||
			currentAnamorphicIntensity != lastAnamorphicIntensity)
		{
			if (targetComponent != null) UpdateVariable(targetComponent);

			lastAnamorphicThreshold = currentAnamorphicThreshold;
			lastAnamorphicIntensity = currentAnamorphicIntensity;
		}
	}

	private void UpdateVariable(VolumeComponent component)
	{
		FieldInfo[] fields = component.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo field in fields)
		{
			if (field.FieldType.IsSubclassOf(typeof(VolumeParameter)))
			{
				var parameter = field.GetValue(component) as VolumeParameter;

				if (field.Name == "anamorphicFlaresThreshold" && parameter is VolumeParameter<float> AnamorphicThreshold)
				{
					AnamorphicThreshold.value = anamorphicThreshold;
				}
				else if (field.Name == "anamorphicFlaresIntensity" && parameter is VolumeParameter<float> AnamorphicIntensity)
				{
					AnamorphicIntensity.value = anamorphicIntensity;
				}
			}
		}
	}
}
