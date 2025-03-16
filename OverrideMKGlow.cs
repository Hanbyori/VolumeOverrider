using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using static MK.Glow.URP.MKGlow;

[ExecuteAlways]
public class OverrideMKGlow : MonoBehaviour
{
	//showEditorMainBehavior : UnityEngine.Rendering.BoolParameter
	//showEditorBloomBehavior : UnityEngine.Rendering.BoolParameter
	//showEditorLensSurfaceBehavior : UnityEngine.Rendering.BoolParameter
	//showEditorLensFlareBehavior : UnityEngine.Rendering.BoolParameter
	//showEditorGlareBehavior : UnityEngine.Rendering.BoolParameter
	//isInitialized : UnityEngine.Rendering.BoolParameter
	//allowGeometryShaders : UnityEngine.Rendering.BoolParameter
	//allowComputeShaders : UnityEngine.Rendering.BoolParameter
	//renderPriority : MK.Glow.URP.MKGlow+RenderPriorityParameter
	//debugView : MK.Glow.URP.MKGlow+DebugViewParameter
	//quality : MK.Glow.URP.MKGlow+QualityParameter
	//antiFlickerMode : MK.Glow.URP.MKGlow+AntiFlickerModeParameter
	//workflow : MK.Glow.URP.MKGlow+WorkflowParameter
	//selectiveRenderLayerMask : MK.Glow.URP.MKGlow+LayerMaskParameter
	//anamorphicRatio : UnityEngine.Rendering.ClampedFloatParameter
	//lumaScale : UnityEngine.Rendering.ClampedFloatParameter
	//blooming : UnityEngine.Rendering.ClampedFloatParameter
	//bloomThreshold : MK.Glow.URP.MKGlow+MinMaxRangeParameter
	//bloomScattering : UnityEngine.Rendering.ClampedFloatParameter
	//bloomIntensity : UnityEngine.Rendering.FloatParameter
	//allowLensSurface : UnityEngine.Rendering.BoolParameter
	//lensSurfaceDirtTexture : MK.Glow.URP.MKGlow+Texture2DParameter
	//lensSurfaceDirtIntensity : UnityEngine.Rendering.FloatParameter
	//lensSurfaceDiffractionTexture : MK.Glow.URP.MKGlow+Texture2DParameter
	//lensSurfaceDiffractionIntensity : UnityEngine.Rendering.FloatParameter
	//allowLensFlare : UnityEngine.Rendering.BoolParameter
	//lensFlareStyle : MK.Glow.URP.MKGlow+LensFlareStyleParameter
	//lensFlareGhostFade : UnityEngine.Rendering.ClampedFloatParameter
	//lensFlareGhostIntensity : UnityEngine.Rendering.FloatParameter
	//lensFlareThreshold : MK.Glow.URP.MKGlow+MinMaxRangeParameter
	//lensFlareScattering : UnityEngine.Rendering.ClampedFloatParameter
	//lensFlareColorRamp : MK.Glow.URP.MKGlow+Texture2DParameter
	//lensFlareChromaticAberration : UnityEngine.Rendering.ClampedFloatParameter
	//lensFlareGhostCount : UnityEngine.Rendering.ClampedIntParameter
	//lensFlareGhostDispersal : UnityEngine.Rendering.ClampedFloatParameter
	//lensFlareHaloFade : UnityEngine.Rendering.ClampedFloatParameter
	//lensFlareHaloIntensity : UnityEngine.Rendering.FloatParameter
	//lensFlareHaloSize : UnityEngine.Rendering.ClampedFloatParameter
	//allowGlare : UnityEngine.Rendering.BoolParameter
	//glareBlend : UnityEngine.Rendering.ClampedFloatParameter
	//glareIntensity : UnityEngine.Rendering.FloatParameter
	//glareAngle : UnityEngine.Rendering.ClampedFloatParameter
	//glareThreshold : MK.Glow.URP.MKGlow+MinMaxRangeParameter
	//glareStreaks : UnityEngine.Rendering.ClampedIntParameter
	//glareScattering : UnityEngine.Rendering.ClampedFloatParameter
	//glareStyle : MK.Glow.URP.MKGlow+GlareStyleParameter
	//glareSample0Scattering : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample0Angle : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample0Intensity : UnityEngine.Rendering.FloatParameter
	//glareSample0Offset : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample1Scattering : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample1Angle : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample1Intensity : UnityEngine.Rendering.FloatParameter
	//glareSample1Offset : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample2Scattering : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample2Angle : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample2Intensity : UnityEngine.Rendering.FloatParameter
	//glareSample2Offset : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample3Scattering : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample3Angle : UnityEngine.Rendering.ClampedFloatParameter
	//glareSample3Intensity : UnityEngine.Rendering.FloatParameter
	//glareSample3Offset : UnityEngine.Rendering.ClampedFloatParameter
	//active : System.Boolean
	//parameterList : System.Collections.Generic.List`1[UnityEngine.Rendering.VolumeParameter]

	public enum DebugView
	{
		None = 0,
		Bloom = 4,
		LensFlare = 5,
		Glare = 6,
		Composite = 7,
	}


	[Header("Global Volume")]
	public Volume globalVolume;
	[Header("Debug")]
	public DebugView debugView;
	private DebugView lastDebugView;
	// 				MK.Glow.DebugView

	[Space(10), Header("Bloom Override")]
	[Range(0f, 10f)] public float bloomThreshold;
	[Range(0f, 10f)] public float bloomIntensity;
	private float lastBloomThreshold;
	private float lastBloomIntensity;

	[Space(10), Header("Lens Flare Override")]
	[Range(0f, 10f)] public float lensFlareIntensity;
	private float lastLensFlareIntensity;

	[Space(10), Header("Lens Surface Override")]
	[Range(0f, 10f)] public float lensSurfaceIntensity;
	private float lastLensSurfaceIntensity;

	[Space(10), Header("Glare Override")]
	[Range(0f, 10f)] public float glareThreshold;
	[Range(0f, 10f)] public float glareIntensity;
	private float lastGlareThreshold;
	private float lastGlareIntensity;

	private VolumeComponent targetComponent;

	private void Start()
	{
		if (globalVolume == null) return;

		VolumeProfile profile = globalVolume.profile;

		if (profile == null) return;

		foreach (VolumeComponent component in profile.components)
		{
			if (component.name.StartsWith("MKGlow"))
			{
				targetComponent = component;
				UpdateVariable(targetComponent);
			}
		}
	}

	private void OnValidate()
	{
		if (debugView != lastDebugView)
		{
			UpdateDebug(targetComponent);
			lastDebugView = debugView;
		}
	}

	private void LateUpdate()
	{
		float currentBloomThreshold = bloomThreshold;
		float currentBloomIntensity = bloomIntensity;
		float currentLensFlareIntensity = lensFlareIntensity;
		float currentLensSurfaceIntensity = lensSurfaceIntensity;
		float currentGlareThreshold = glareThreshold;
		float currentGlareIntensity = glareIntensity;

		if (currentBloomThreshold != lastBloomThreshold ||
			currentBloomIntensity != lastBloomIntensity ||
			currentLensFlareIntensity != lastLensFlareIntensity ||
			currentLensSurfaceIntensity != lastLensSurfaceIntensity ||
			currentGlareThreshold != lastGlareThreshold ||
			currentGlareIntensity != lastGlareIntensity)
		{
			if (targetComponent != null) UpdateVariable(targetComponent);

			lastBloomThreshold = currentBloomThreshold;
			lastBloomIntensity = currentBloomIntensity;
			lastLensFlareIntensity = currentLensFlareIntensity;
			lastLensSurfaceIntensity = currentLensSurfaceIntensity;
			lastGlareThreshold = currentGlareThreshold;
			lastGlareIntensity = currentGlareIntensity;
		}
	}

	private void UpdateDebug(VolumeComponent component)
	{
		FieldInfo[] fields = component.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo field in fields)
		{
			if (field.FieldType.IsSubclassOf(typeof(VolumeParameter)))
			{
				var parameter = field.GetValue(component) as VolumeParameter;

				if (field.Name == "debugView" && parameter is VolumeParameter<MK.Glow.DebugView> DebugView)
				{
					DebugView.value = (MK.Glow.DebugView)debugView;
				}
			}
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

				if (field.Name == "bloomThreshold" && parameter is VolumeParameter<MK.Glow.MinMaxRange> BloomThreshold)
				{
					BloomThreshold.value = new MK.Glow.MinMaxRange(bloomThreshold, 10);
				}
				else if (field.Name == "bloomIntensity" && parameter is VolumeParameter<float> BloomIntensity)
				{
					BloomIntensity.value = bloomIntensity;
				}
				else if (field.Name == "lensFlareGhostIntensity" && parameter is VolumeParameter<float> LensFlareIntensity)
				{
					LensFlareIntensity.value = lensFlareIntensity;
				}
				else if (field.Name == "lensSurfaceDirtIntensity" && parameter is VolumeParameter<float> LensSurfaceIntensity)
				{
					LensSurfaceIntensity.value = lensSurfaceIntensity;
				}
				else if (field.Name == "glareThreshold" && parameter is VolumeParameter<MK.Glow.MinMaxRange> GlareThreshold)
				{
					GlareThreshold.value = new MK.Glow.MinMaxRange(glareThreshold, 10); ;
				}
				else if (field.Name == "glareIntensity" && parameter is VolumeParameter<float> GlareIntensity)
				{
					GlareIntensity.value = glareIntensity;
				}
			}
		}
	}
}
