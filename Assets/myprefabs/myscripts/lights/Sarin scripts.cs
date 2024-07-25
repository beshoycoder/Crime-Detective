using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarinscripts : MonoBehaviour
{
    //this script is only for creating the light effect of a police lights or ambulance lights
    [SerializeField] private Light RedLight;
    [SerializeField] private Light RedLight1;
    [SerializeField] private Light BlueLight;
    [SerializeField] private Light BlueLight1;
    [SerializeField] private float flashdurations;
    void Start()
    {
        StartCoroutine(Sarinlight());
    }

    IEnumerator Sarinlight()
    {
        while (true)
        {
            RedLight.enabled = !RedLight.enabled;
            RedLight1.enabled = !RedLight1.enabled;
            BlueLight.enabled = !BlueLight.enabled;
            BlueLight1.enabled = !BlueLight1.enabled;
            yield return new WaitForSeconds(flashdurations);
        }
    }
}
