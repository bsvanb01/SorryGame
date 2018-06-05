using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Piece4 : MonoBehaviour
{

    public int curSquare = 70;

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
                    bool buttonClicked = false;
                    GameManager.currentPiece = GameObject.Find("p2_Game_Piece_4");
                    GameManager.currentPlayer = 2;
                    GameManager.currentSquare = curSquare;

                    //call checkmovement
                    while (!buttonClicked) // wait for button to be pressed
                    {

                    }

                    curSquare = GameManager.currentSquare;
                    PieceManager2.player2Active = false;
                }
            }
        }
    }
}
