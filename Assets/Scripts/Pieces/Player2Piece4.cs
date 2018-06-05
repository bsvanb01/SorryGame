using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Piece4 : MonoBehaviour {

    public int curSquare = 70;
    public bool p2p4Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p2p4Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p2_Game_Piece_4");
            GameManager.currentPlayer = 2;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p2p4Active = false;
        }
    }
}
