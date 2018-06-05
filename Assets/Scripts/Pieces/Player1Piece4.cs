﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Piece4 : MonoBehaviour {

    public int curSquare = 70;
    public bool p1p4Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p1p4Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p1_Game_Piece_4");
            GameManager.currentPlayer = 1;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p1p4Active = false;
        }
    }
}