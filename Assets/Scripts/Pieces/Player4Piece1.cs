using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Piece1 : MonoBehaviour {

    public int curSquare = 70;
    public bool p4p1Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p4p1Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p4_Game_Piece_1");
            GameManager.currentPlayer = 4;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p4p1Active = false;
        }
    }
}
