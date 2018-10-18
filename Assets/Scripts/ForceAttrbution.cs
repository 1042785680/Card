using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAttrbution : MonoBehaviour {

    public float forceMagnitude;
    public float attenuationRate;

    public float ForceAttenuation(float magnitude,float distance)
    {
        float ret = magnitude* Mathf.Exp(-attenuationRate * distance);
        return ret;
    }
}
