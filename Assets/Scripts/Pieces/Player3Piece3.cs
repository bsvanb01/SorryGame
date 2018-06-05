using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Piece3 : MonoBehaviour {

    public int curSquare = 70;
    public bool p3p3Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p3p3Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p3_Game_Piece_3");
            GameManager.currentPlayer = 3;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p3p3Active = false;
        }
    }
}
