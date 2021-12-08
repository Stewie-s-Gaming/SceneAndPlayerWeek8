using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : MonoBehaviour
{
    [SerializeField] GameObject[] messages;
    int currIndex;
    bool isNearby;
    // Start is called before the first frame update
    void Start()
    {
        currIndex = 0;
        isNearby = false;
        foreach (var x in messages)
        {
            x.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isNearby && Input.GetKeyDown(KeyCode.E))
        {
            messages[currIndex++%messages.Length].SetActive(false);
            messages[currIndex % messages.Length].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        messages[currIndex].SetActive(true);
        Debug.Log("Trigger");
        isNearby = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isNearby = false;
        currIndex = 0;
        foreach(var x in messages)
        {
            x.SetActive(false);
        }
    }
}
