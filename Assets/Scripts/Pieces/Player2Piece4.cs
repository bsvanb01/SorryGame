using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Piece4 : MonoBehaviour
{
    CheckMovement check = new CheckMovement();
    public static int curSquare = 19;

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
                if (hit.transform.name == "p2_Game_Piece_4" && PieceManager2.player2Active)
                {
                    GameManager.currentPiece = GameObject.Find("p2_Game_Piece_4");
                    GameManager.currentPlayer = 2;
                    GameManager.currentSquare = curSquare;

                    check.checkMovement(CardDeck.card, curSquare, PieceManager2.startSquare, GetComponent<Renderer>(), GameManager.currentPlayer);
                }
            }
        }
    }
}
