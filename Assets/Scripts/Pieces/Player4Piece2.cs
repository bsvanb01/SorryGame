﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Piece2 : MonoBehaviour {

    public int curSquare = 70;
    public bool p4p2Active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && p4p2Active)
        {
            bool buttonClicked = false;
            GameManager.currentPiece = GameObject.Find("p4_Game_Piece_2");
            GameManager.currentPlayer = 4;
            GameManager.currentSquare = curSquare;

            //call checkmovement

            while (!buttonClicked) // wait for button to be pressed
            {

            }
            curSquare = GameManager.currentSquare;
            p4p2Active = false;
        }
    }
}
