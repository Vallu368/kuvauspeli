using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NightlessNightController : MonoBehaviour
{
	[SerializeField] Volume twilightVolume; // Twilight post processing volume
	[SerializeField] Volume nightVolume;    // Night post processing volume
	[SerializeField] Animator sunGimbal;   // Sun gimbal
	[SerializeField] Transform nightProbe;  // Reflection probe night
	[SerializeField] AnimationCurve nightProbeCurve;  // Reflection probe night curve
	[SerializeField] AnimationCurve twilightVolumeCurve;  // twilight post processing volume curve
	[SerializeField] AnimationCurve nightVolumeCurve;  // night post processing volume curve

	[SerializeField][Range(0f, 1f)] float startTime;  // Reflection probe night
	[Tooltip("Day day length in minutes")]
	[SerializeField] float dayLength;  // Reflection probe night
	[SerializeField] float nightProbeY = -95;  // Reflection probe night
	[SerializeField] bool randomizeDayTimer = false;
	[SerializeField] float dayTimer;
	float _halfDayTime;
	void Start()
	{
		if (randomizeDayTimer)
			dayTimer = Random.Range(0f, 1f);
	}

	void Update()
	{

		//Day cycle
		dayTimer = Mathf.MoveTowards(dayTimer, 1f, Time.deltaTime / (dayLength * 60));
		dayTimer = Mathf.Repeat(dayTimer, 1f);
		_halfDayTime = Mathf.PingPong(dayTimer * 2, 1f); //This maps the curves to half of day, so they're functionally mirrored

		//Sun Gimbal - set animation clip time to time of day
		AnimatorStateInfo state0 = sunGimbal.GetCurrentAnimatorStateInfo(0);
		sunGimbal.Play(state0.fullPathHash, -1, dayTimer); //Debug.Log(state0.normalizedTime);

		//Night reflection probe - set position to 0 Y at curve 0f, -95 Y at curve 1f
		nightProbe.position = Vector3.up * nightProbeCurve.Evaluate(_halfDayTime) * nightProbeY;

		//Post processing volumes
		twilightVolume.weight = twilightVolumeCurve.Evaluate(_halfDayTime);
		nightVolume.weight = nightVolumeCurve.Evaluate(_halfDayTime);


	}
}

