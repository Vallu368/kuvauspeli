using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject sun;
    public GameObject rain;
    public GameObject heavyRain;
    public bool rainEnabled;
    public int rotateSpeed = 500;
    public Animator anim;


    void Start()
    {
        rain = GameObject.Find("Player/Bruh/Rain");
        heavyRain = GameObject.Find("Player/Bruh/HeavyRain");
        rain.SetActive(false);
        heavyRain.SetActive(false);
        
        
        
    }

    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            if (!rainEnabled)
            {
                StartCoroutine(Raining());

            }
            
            
        }
        if (Input.GetKeyDown("z"))
        {
            StartCoroutine(SunDown());
        }

    }


    public IEnumerator Raining()
    {
        rainEnabled = true;
        anim.SetBool("isSunDown", true);
        yield return new WaitForSeconds(45f);
        rain.SetActive(true);

        // yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        yield return new WaitForSeconds(40f);
        rain.SetActive(false);
        heavyRain.SetActive(true);
        Debug.Log("waiting for 60s");
        yield return new WaitForSeconds(60f);
        StartCoroutine(StopRaining());
    }
    public IEnumerator StopRaining()
    {
        Debug.Log("stopping rain");
        anim.SetBool("isSunDown", false);
        yield return new WaitForSeconds(45f);
        heavyRain.SetActive(false);
        rain.SetActive(true);
        yield return new WaitForSeconds(40f);
        rain.SetActive(false);
        rainEnabled = false;
    }

    public IEnumerator SunDown()
    {
     //   yield return new WaitForSeconds(180f);
        Debug.Log("sun down");
        anim.SetBool("isSunDown", true);
        yield return new WaitForSeconds(120f);
        StartCoroutine(SunUp());
    }
    public IEnumerator SunUp()
    {
        Debug.Log("sun up");
        yield return new WaitForSeconds(10f);
        anim.SetBool("isSunDown", true);
        
    }
}
