using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingStuff : MonoBehaviour
{
    public InventoryScript inv;
    public GameObject player;
    public Image image;
    public GameObject teleportLocation;
    private float targetAlpha;
    public float FadeRate;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bruh")
        {
            if (inv.picturesTaken == 0)
            {
                Debug.Log("booop");
                player = collision.gameObject;
                StartCoroutine(Teleport());
            }
        }
    }
    IEnumerator Teleport()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(2f);
        player.transform.position = teleportLocation.transform.position;
        StartCoroutine(FadeOut());
        player.GetComponent<PlayerMovement>().enabled = true;
    }
    IEnumerator FadeIn()
    {

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
    }
}