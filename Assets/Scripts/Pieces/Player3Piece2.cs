using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Piece2 : MonoBehaviour {

    public int curSquare = 70;
    public bool p3p2Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p3p2Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p3_Game_Piece_2");
            GameManager.currentPlayer = 3;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p3p2Active = false;
        }
    }
}
