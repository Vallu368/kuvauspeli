using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioCoding : MonoBehaviour
{
    public AudioSource audioSource;
    private bool askeleetEnabled;
    public bool woodActivated;

    private void Start()
    {
        woodActivated = false;
    }

    private void Update()
    {
        if (woodActivated == true && Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            askeleetEnabled = true;
        }
        else askeleetEnabled = false;

        if (woodActivated && askeleetEnabled && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (!woodActivated || !askeleetEnabled)
        {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        woodActivated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        woodActivated = false;
    }
}
