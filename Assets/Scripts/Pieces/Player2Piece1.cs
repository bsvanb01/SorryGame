using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Piece1 : MonoBehaviour {

    public int curSquare = 70;
    public bool p2p1Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p2p1Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p2_Game_Piece_1");
            GameManager.currentPlayer = 2;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p2p1Active = false;
        }
    }
}
