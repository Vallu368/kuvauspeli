using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    public Animator camAnim;
    [SerializeField] public AudioSource camSound;

    [SerializeField] private GameObject polaroid;
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;
    [SerializeField] private Animator fadingAnimation;
    [SerializeField] private GameObject cameraUI;
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject crosshair;
    public InventoryScript inv;
    public CameraRaycast raycast;
    public bool cameraMode = false;
    private Texture2D screenCapture;
    private bool viewingPhoto;
    public bool takingPhoto;


    private void Awake()
    {
       camAnim = polaroid.GetComponent<Animator>();
    }

    private void Start()
    {
        tutorialText.SetActive(true);
        polaroid.SetActive(false);
        camSound = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (!cameraMode && Input.GetMouseButtonDown(1)) //jos pid‰t right click pohjassa niin kamerajutut menee p‰‰lle ja voit ottaa kuvia
        {
            cameraMode = true;
            tutorialText.SetActive(false);
            AnimFrame();
            polaroid.SetActive(true);
            camAnim.Play("holdingCam");

            
        }
        else if (Input.GetMouseButtonDown(1))
        {
            cameraMode = false;
            StartCoroutine(ForAnimYay());
        }

        if (!takingPhoto && cameraMode) 
        {
            cameraUI.SetActive(true);
            polaroid.SetActive(true);
        }
        else 
            cameraUI.SetActive(false);


        if (cameraMode && Input.GetMouseButtonDown(0)) //jos pid‰t right click pohjassa ja painat left click otat kuvan, jos kuva jo valmiina ruudulla left click poistaa sen
        {
            if (!viewingPhoto)
            {
                takingPhoto = true;
                camSound.Play();
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

    IEnumerator ForAnimYay()
    {
        Debug.Log("okkkkkkkkk");
        yield return new WaitForSeconds(0.2f);
            camAnim.Play("noCam");
            yield return new WaitForSeconds(1);
            polaroid.SetActive(false);
    }

    IEnumerator AnimFrame()
    {
        yield return new WaitForEndOfFrame();
    }

    IEnumerator CapturePhoto()
    {
        foreach (Transform child in polaroid.transform)
        {
            child.GetComponent<MeshRenderer>().enabled = false;
        }
        cameraUI.SetActive(false);
        crosshair.SetActive(false);
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        viewingPhoto = true;

        yield return new WaitForSeconds(0.001f);
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
        foreach (Transform child in polaroid.transform)
        {
            child.GetComponent<MeshRenderer>().enabled = true;
        }


    }
    IEnumerator CameraFlashEffect()
    {
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
        takingPhoto = false;
    }

    void ShowPhoto()
    {
        
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        if (raycast.objective == 1)
        {   
            inv.AddImageToInventory(raycast.hitObjectID, photoSprite);
        }

        photoDisplayArea.sprite = photoSprite;
        StartCoroutine(CameraFlashEffect());
        photoFrame.SetActive(true);
        fadingAnimation.Play("PhotoFade");




    }


    void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
        crosshair.SetActive(true);
    }
}
