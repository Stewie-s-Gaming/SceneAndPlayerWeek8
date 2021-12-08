using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject LightOn;
    [SerializeField] GameObject LightOff;
    [SerializeField] GameObject light;

    bool isNearby;
    // Start is called before the first frame update
    void Start()
    {
        isNearby = false;
        LightOn.SetActive(true);
        LightOff.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        isNearby = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isNearby = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isNearby && Input.GetKeyDown(KeyCode.E))
        {
            LightOn.SetActive(!LightOn.activeSelf);
            LightOff.SetActive(!LightOff.activeSelf);
            light.SetActive(LightOn.activeSelf);
        }
    }
}
