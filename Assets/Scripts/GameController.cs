using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject player;
    public int playerNum;
    public GameObject[] players;
    public GameObject currentPlayer;

    private int currentTurn;
    private void Start()
    {
        playerNum = Mathf.Clamp(playerNum, 2, 4);
        List<GameObject> playerList = new List<GameObject>();
        for (int i = 0; i < playerNum; ++i)
        {
            GameObject playerTmp = Instantiate(player);
            playerList.Add(playerTmp);
        }
        players = playerList.ToArray();
        currentTurn = 0;
        currentPlayer = players[currentTurn % playerNum];
    }


    public void NextTurn()
    {
        currentTurn += 1;
        currentPlayer = players[currentTurn % playerNum];
        Debug.Log(currentTurn);
        Debug.Log(currentPlayer);
    }


    //判断所有卡牌是否都静止
    public bool isAllCardStill()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject card in cards)
        {
            Rigidbody cardRb = card.GetComponent<Rigidbody>();
            if (cardRb.velocity != new Vector3(0, 0, 0))
                return false;
        }
        return true;
    }


}
