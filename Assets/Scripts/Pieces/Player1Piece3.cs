using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Piece3 : MonoBehaviour {

    public int curSquare = 70;
    public bool p1p3Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p1p3Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p1_Game_Piece_3");
            GameManager.currentPlayer = 1;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p1p3Active = false;
        }
    }
}
