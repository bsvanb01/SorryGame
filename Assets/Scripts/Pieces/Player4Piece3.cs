using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Piece3 : MonoBehaviour
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
                if (hit.transform.name == "p4_Game_Piece_3" && PieceManager4.player4Active)
                {
                    bool buttonClicked = false;
                    GameManager.currentPiece = GameObject.Find("p4_Game_Piece_3");
                    GameManager.currentPlayer = 4;
                    GameManager.currentSquare = curSquare;

                    //call checkmovement

                    while (!buttonClicked) // wait for button to be pressed
                    {

                    }
                    curSquare = GameManager.currentSquare;
                    PieceManager4.player4Active = false;
                }
            }
        }
    }
}
