﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Piece2 : MonoBehaviour {

    public static int curSquare = 4;
    CheckMovement check = new CheckMovement();

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "p1_Game_Piece_2" && PieceManager1.player1Active)
                {
                    GameManager.currentPiece = GameObject.Find("p1_Game_Piece_2");
                    GameManager.currentPlayer = 1;
                    GameManager.currentSquare = curSquare;

                    check.checkMovement(CardDeck.card, curSquare, PieceManager1.startSquare, GetComponent<Renderer>(), GameManager.currentPlayer);
                }
            }
        }
    }
}
