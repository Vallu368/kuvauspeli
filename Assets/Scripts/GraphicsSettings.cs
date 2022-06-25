using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class GraphicsSettings : MonoBehaviour
{
	UniversalAdditionalCameraData _camData;
	void Start()
	{
		//Get settings from PlayerPrefs, update buttons to reflect settings if different from defaults?
	}

	public void SetVsync(bool toggled)
	{
		QualitySettings.vSyncCount = toggled ? 1 : 0;
		Debug.Log(toggled);

	}

	public void SetAO(bool toggled)
	{
		_camData = Camera.main.GetUniversalAdditionalCameraData();
		if (toggled)
		{
			_camData.SetRenderer(0); // switch to renderer with AO render feature.
			Debug.Log(toggled);
		}
		else
		{
			_camData.SetRenderer(1); // switch to renderer without AO render feature.
			Debug.Log(_camData.renderType);
		}
	}

	public void SetQualityLevel(TMP_Dropdown choice)
	{
		QualitySettings.SetQualityLevel(choice.value);
	}
}
