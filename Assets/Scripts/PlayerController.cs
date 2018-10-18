using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Force;

    public void GenerateForce(Vector3 vector, float magnitude)
    {
        GameObject f = Instantiate(Force, vector, new Quaternion());
        Destroy(f, 0.5f);
    }
}
