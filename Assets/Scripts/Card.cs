using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public GameObject ForceBall;

    public Vector3 ForcePosition;

    void Start () {

        Invoke("Force", 1);
	}
	
	void Update () {

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Force();
        //}
	}

    void Force()
    {
        //gameObject.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(ForceBall.transform.position.x - transform.position.x,
        //    100, ForceBall.transform.position.z - transform.position.z), new Vector3(0, 0, 0));

        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3((transform.position.x - ForceBall.transform.position.x) * 30,
            200, (transform.position.z - ForceBall.transform.position.z) * 10), ForceBall.transform.position);
    }

}
