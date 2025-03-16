using System.Collections;
using System.Reflection;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class GetVolumeFields : MonoBehaviour
{
	[Header("Global Volume")]
	public Volume globalVolume;

	private VolumeComponent targetComponent;
	private string logFilePath;

	private void Start()
	{
		logFilePath = Path.Combine(Application.persistentDataPath, "VolumeFieldsLog.txt");

		if (File.Exists(logFilePath))
		{
			File.Delete(logFilePath);
		}

		if (globalVolume == null) return;

		VolumeProfile profile = globalVolume.profile;

		if (profile == null) return;

		foreach (VolumeComponent component in profile.components)
		{
			Debug.Log(component.name);

			if (component.name.StartsWith("MKGlow"))
			{
				targetComponent = component;
				// GetFields(targetComponent);
			}
		}
	}

	private void GetFields(VolumeComponent component)
	{
		FieldInfo[] fields = component.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo field in fields)
		{
			string logMessage = $"{field.Name} : {field.FieldType}";
			Debug.Log(logMessage);
			AppendLogToFile(logMessage);
		}
	}

	private void AppendLogToFile(string message)
	{
		using (StreamWriter writer = new StreamWriter(logFilePath, true))
		{
			writer.WriteLine(message);
		}
	}
}
