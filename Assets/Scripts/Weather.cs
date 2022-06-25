using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
	[SerializeField] private GameObject rain;
	[SerializeField] private GameObject heavyRain;
	public bool rainEnabled;
	private int nextUpdate;
	private int i = 0;




	void Start()
	{
		//rain = GameObject.Find("Player/Bruh/Rain"); //using serialized reference in favor of GameObject.Find
		//heavyRain = GameObject.Find("Player/Bruh/HeavyRain"); //using serialized reference in favor of GameObject.Find
		rain.SetActive(false);
		heavyRain.SetActive(false);

	}
	private void Update()
	{
		if (Time.time >= nextUpdate)
		{

			nextUpdate = Mathf.FloorToInt(Time.time) + 1;
			UpdateEverySecond();
		}
		if (i >= 60) //joka 60 sekunttia kattoo randomin, jos randomi on 2 alkaa satamaan
		{
			int ind = Random.Range(0, 3);
			if (ind == 2)
			{
				StartCoroutine(Raining());
				i = 0;
			}
			else Debug.Log("not raining");
			i = 0;
		}
	}

	void UpdateEverySecond()
	{
		if (!rainEnabled)
		{
			i++;
		}
	}

	IEnumerator Raining()
	{
		Debug.Log("Raining");
		rainEnabled = true;
		rain.SetActive(true);
		yield return new WaitForSeconds(20f);
		rain.SetActive(false);
		heavyRain.SetActive(true);
		yield return new WaitForSeconds(60f);
		heavyRain.SetActive(false);
		rainEnabled = false;


	}


}
