using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghostPrefab;
    public bool hasGhost;
    public TakePhoto takePhoto;
    public int objectiveNumber = 0;

    public bool isGhostActive;
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
