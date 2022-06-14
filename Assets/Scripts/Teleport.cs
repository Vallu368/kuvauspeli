using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    private InventoryScript inv;
    private GameObject player;
    private GameObject fadeoutImage;
    private Image image;
    public GameObject teleportLocation;
    private float targetAlpha;
    public float FadeRate;
    public int PicturesNeededToUse;

    void Start()
    {
        fadeoutImage = GameObject.Find("Player/CameraCanvas/FadeOutImage");
        inv = GameObject.Find("Player/Bruh").GetComponent<InventoryScript>();
        image = fadeoutImage.GetComponent<Image>();
        fadeoutImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "Test")
        {
            if (inv.picturesTaken == PicturesNeededToUse)
            {
                Debug.Log("booop");
                player = coll.gameObject.transform.parent.gameObject;
                StartCoroutine(TeleportPlayer());
            }
            else Debug.Log("not enough pictures taken");
        }
    }
    IEnumerator TeleportPlayer()
    {

        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(2f);
        player.transform.position = teleportLocation.transform.position;
        StartCoroutine(FadeOut());
        
    }
    IEnumerator FadeIn()
    {
        fadeoutImage.SetActive(true);
        targetAlpha = 1.0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        { 
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }
    IEnumerator FadeOut()
    {
        targetAlpha = 0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
        fadeoutImage.SetActive(false);
    }
   
}
