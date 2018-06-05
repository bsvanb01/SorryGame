using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Piece2 : MonoBehaviour {

    public int curSquare = 70;
    public bool p1p2Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p1p2Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p1_Game_Piece_2");
            GameManager.currentPlayer = 1;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p1p2Active = false;
        }
    }
}
