using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnGround : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("fail to find GameObject GameController");
    }



    private void OnMouseDown()
    {
        //当所有卡牌静止时才下一回合
        if (!gameController.isAllCardStill())
            return;
        Vector3 screenPosition = Input.mousePosition;
        Vector3 worldPosition = new Vector3();
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit groundHit;
        if (Physics.Raycast(ray, out groundHit))
        {
            worldPosition = groundHit.point;
            worldPosition.y = -5;
            GameObject player = gameController.currentPlayer;
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.GenerateForce(worldPosition, 800);
        }
        gameController.NextTurn();
    }
}
