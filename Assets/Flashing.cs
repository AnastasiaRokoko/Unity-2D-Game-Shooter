using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    public Light _light;
    public bool isOn = true;
    void Start()
    {
        if (_light) _light.enabled = isOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (_light)
        {
            isOn = !isOn;
            _light.enabled = isOn;
        }
        
    }
}
