using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{

    public GameObject Card;
    public int cardNum;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;

    private void Start()
    {
        StartCoroutine(GenerateCard());
    }

    IEnumerator GenerateCard()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < cardNum; ++i)
        {
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);
            Vector3 postion = new Vector3(x, 3, z);
            float angle = Random.Range(-180, 180);
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            Instantiate(Card, postion, rotation);
            yield return new WaitForSeconds(0.2f);
        }

    }


}
