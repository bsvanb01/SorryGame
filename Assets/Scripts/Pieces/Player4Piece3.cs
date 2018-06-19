using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player4Piece3 : MonoBehaviour
{
    CheckMovement check = new CheckMovement();
    public static int curSquare = 49;

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
                if (hit.transform.name == "p4_Game_Piece_3" && PieceManager4.player4Active)
                {
                    GameManager.currentPiece = GameObject.Find("p4_Game_Piece_3");
                    GameManager.currentPlayer = 4;
                    GameManager.currentSquare = curSquare;

                    check.checkMovement(CardDeck.card, curSquare, PieceManager4.startSquare, GetComponent<Renderer>(), GameManager.currentPlayer);
                }
            }
        }
    }
}
