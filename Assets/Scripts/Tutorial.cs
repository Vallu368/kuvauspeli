using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialText;
    private float targetAlpha;
    public bool used;
    public bool sasdadas = false;
    void Start()
    {
        tutorialText = GameObject.Find("Player/CameraCanvas/TutorialText");
        tutorialText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider coll)
    {
        
        if (coll.gameObject.name == "Test")
        {
            if (!used)
            {
                tutorialText.SetActive(true);
                used = true;
                Debug.Log("boop");
                Debug.Log(coll);
            }
        }

    }
    

}

