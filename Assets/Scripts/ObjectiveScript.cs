using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghostPrefab;
    public InventoryScript invScript;
    public bool hasGhost;
    public int objectiveNumber = 0;
    private GameObject player;
    private TakePhoto takePhoto;
    private bool isGhostActive;
    private bool hasTakenPic;
    void Start()
    {

        player = GameObject.Find("Player");
        takePhoto = player.GetComponentInChildren<TakePhoto>();
        invScript = player.GetComponentInChildren<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGhostActive)
        {
            StartCoroutine(SpawnGhost());
        }
    }
    private IEnumerator SpawnGhost()
    {
        ghostPrefab.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        ghostPrefab.SetActive(false);
        isGhostActive = false;
    }

    public void SetGhostActive()
    {
        isGhostActive = true;
    }
    public void PicTaken()
    {
        if (!hasTakenPic)
        {
            invScript.picturesTaken++;
            hasTakenPic = true;
        }
        
    }


}
