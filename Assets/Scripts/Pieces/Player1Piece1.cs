using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Piece1 : MonoBehaviour {

    public int curSquare = 70;
    public bool p1p1Active = false;

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
                if (hit.transform.name == "p1_Game_Piece_1" && PieceManager1.player1Active)
                {
                    bool buttonClicked = false;
                    GameManager.currentPiece = GameObject.Find("p1_Game_Piece_1");
                    GameManager.currentPlayer = 1;
                    GameManager.currentSquare = curSquare;

                    //call checkmovement

                    while (!buttonClicked) // wait for button to be pressed
                    {

                    }
                    curSquare = GameManager.currentSquare;
                    PieceManager1.player1Active = false;
                }
            }
        }
    }
}
