using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    [SerializeField] GameObject[] states;
    [SerializeField] string tags;
    bool isNearby;
        // Start is called before the first frame update
    void Start()
    {
        isNearby = false;
       foreach(var x in states)
        {
            if (states[0].Equals(x)) x.SetActive(true);
            else x.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(tags.Equals(other.tag)) isNearby = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(tags.Equals(other.tag))  isNearby = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isNearby && Input.GetKeyDown(KeyCode.E) && states[0].activeSelf)
        {
            states[0].SetActive(false);
            states[1].SetActive(true);
        }
        else if(isNearby && Input.GetKeyDown(KeyCode.Z) && states[1].activeSelf)
        {
            states[1].SetActive(false);
            states[2].SetActive(true);
        }
    }
}
