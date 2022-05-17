using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghostPrefab;
    public bool isGhostActive;
    public PhotoItem item;
    public TakePhoto takePhoto;
    public int objectiveNumber = 0;
    void Start()
    {
        
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

}
