using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject rain;
    private bool rainEnabled;
    
    void Start()
    {
        rain = GameObject.Find("Player/Bruh/Rain");
    }

    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            if (!rainEnabled)
            {
                Raining();
            }
            else StopRaining();
        }

    }

    public void SunDown()
    {
            
    }

    public void Raining()
    {
        rain.SetActive(true);
        rainEnabled = true;
        
    }
    public void StopRaining()
    {
        rain.SetActive(false);
        rainEnabled = false;
    }
}
