using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3Piece3 : MonoBehaviour
{
    CheckMovement check = new CheckMovement();
    public static int curSquare = 34;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "p3_Game_Piece_3" && PieceManager3.player3Active)
                {
                    GameManager.currentPiece = GameObject.Find("p3_Game_Piece_3");
                    GameManager.currentPlayer = 3;
                    GameManager.currentSquare = curSquare;

                    check.checkMovement(CardDeck.card, curSquare, PieceManager3.startSquare, GetComponent<Renderer>(), GameManager.currentPlayer);
                }
            }
        }
    }
}
