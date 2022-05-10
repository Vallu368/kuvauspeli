using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;
    [SerializeField] private Animator fadingAnimation;
    [SerializeField] private GameObject cameraUI;
    public bool cameraMode = false;
    private Texture2D screenCapture;
    private bool viewingPhoto;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1)) //jos pid‰t right click pohjassa niin kamerajutut menee p‰‰lle ja voit ottaa kuvia
        {
            cameraMode = true;
        }
        else cameraMode = false;
        if (cameraMode) 
        {
            cameraUI.SetActive(true);
        }
        else cameraUI.SetActive(false);
        if(cameraMode && Input.GetMouseButtonDown(0)) //jos pid‰t right click pohjassa ja painat left click otat kuvan, jos kuva jo valmiina ruudulla left click poistaa sen
        {
            if(!viewingPhoto)
            {
                StartCoroutine(CapturePhoto());
            }
            else
            {
                RemovePhoto();
            }
        }
        if (!cameraMode && Input.GetMouseButtonDown(0)) 
        {
            if (viewingPhoto)
            {
                RemovePhoto(); //left click poistaa kuvan vaikka right click ei olis pohjassa
            }
        }
    }

    IEnumerator CapturePhoto()
    {
        viewingPhoto = true; 

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }
    IEnumerator CameraFlashEffect()
    {
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }

    void ShowPhoto()
    {
        
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;
        StartCoroutine(CameraFlashEffect());
        photoFrame.SetActive(true);
        fadingAnimation.Play("PhotoFade");
    }


    
    void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
    }
}
