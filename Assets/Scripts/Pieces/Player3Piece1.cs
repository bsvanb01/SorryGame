using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Piece1 : MonoBehaviour {

    public int curSquare = 70;
    public bool p3p1Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p3p1Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p3_Game_Piece_1");
            GameManager.currentPlayer = 3;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p3p1Active = false;
        }
    }
}
