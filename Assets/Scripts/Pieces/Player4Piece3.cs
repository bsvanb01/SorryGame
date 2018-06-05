using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Piece3 : MonoBehaviour {

    public int curSquare = 70;
    public bool p4p3Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p4p3Active)
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
            p4p3Active = false;
        }
    }
}
