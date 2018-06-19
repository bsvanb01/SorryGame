using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3Piece1 : MonoBehaviour
{

    public static int curSquare = 34;
    CheckMovement check = new CheckMovement();


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
                if (hit.transform.name == "p3_Game_Piece_1" && PieceManager3.player3Active)
                {
                    Debug.Log("Cur square is : " + curSquare);

                    GameManager.currentPiece = GameObject.Find("p3_Game_Piece_1");
                    GameManager.currentPlayer = 3;
                    GameManager.currentSquare = curSquare;

                    check.checkMovement(CardDeck.card, curSquare, PieceManager3.startSquare, GetComponent<Renderer>(), GameManager.currentPlayer);
                }
            }
        }
    }
}
