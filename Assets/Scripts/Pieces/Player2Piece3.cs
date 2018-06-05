using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Piece3 : MonoBehaviour {

    public int curSquare = 70;
    public bool p2p3Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p2p3Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p2_Game_Piece_3");
            GameManager.currentPlayer = 2;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p2p3Active = false;
        }
    }
}
