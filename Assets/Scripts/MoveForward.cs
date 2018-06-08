﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveForward : MonoBehaviour
{

    private static int curSquare;
    private static int curPlayer;
    private static GameObject curPiece;
    GameManager forSpaces;
    GameManager GM = new GameManager();
    EndOfTurn endTurn = new EndOfTurn();

    // Use this for initialization
    void Start()
    {

    }

    public void MovingForward()
    {
        int moveNum = CardDeck.card;
        int curSquare2 = GameManager.currentSquare;
        int curPlayer2 = GameManager.currentPlayer;
        GameObject curPiece2 = GameManager.currentPiece;
        int spacesLeft = moveNum;

        #region Safety Zone
        if ((curPlayer2 == 1 && curSquare2 + moveNum > 2 && (curSquare2 <= 2 || (curSquare2 >= 50 && curSquare2 < 60))) // that last one basically means it has to be in the range of 50 to 2 spacewise, and nothing else.
        || (curPlayer2 == 2 && curSquare2 + moveNum > 17 && curSquare2 <= 17)
        || (curPlayer2 == 3 && curSquare2 + moveNum > 32 && curSquare2 <= 32)
        || (curPlayer2 == 4 && curSquare2 + moveNum > 47 && curSquare2 <= 47) && curPiece2.tag == "Normal") // if going into safety zone. has to be going to a space greater than their last normal space. and has to be currently on a space less than or equal to the last normal space.
        {
            while (curSquare2 != 2 && curSquare2 != 17 && curSquare2 != 32 && curSquare2 != 47)
            { // keep moving till you hit the space that makes you go into the safety zone
                curSquare2 += 1;
                curSquare2 = curSquare2 % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
                curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
                spacesLeft -= 1; // subtract one from the spaces left
            }
            spacesLeft -= 1;

            switch (curPlayer) // assigning each piece its new position in the safety zone
            {
                case 1:
                    curSquare2 = 60;
                    break;
                case 2:
                    curSquare2 = 66;
                    break;
                case 3:
                    curSquare2 = 72;
                    break;
                case 4:
                    curSquare2 = 78;
                    break;
            }
            curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;
            while (spacesLeft != 0)
            {
                curSquare2 += 1;
                spacesLeft -= 1;
                curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
            }

            Debug.Log(curSquare2);
            #endregion

            #region Normal Movement
        }
        else
        {
            for (int Left = spacesLeft; Left > 0; Left--)
            {
                curSquare2 += 1;
                curSquare2 = curSquare2 % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
                /* movement of the physical piece updating its physical position based on the new curSquare. */
                curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;

                Debug.Log("spaces left:" + Left);
            }
        }
        #endregion

        GameManager.currentSquare = curSquare2; // update the gameManager version of currentSquare so that it now has curSquare2.
                                                //that will be passed onto curSquare, which is updated every frame.

        #region update home tag
        if (curPiece2.tag == "Home") {
            if (curPlayer == 1)
            {
                PieceManager1.piecesHome++;
                if (PieceManager1.piecesHome == 4)
                    GM.endGame();
            }
            else if (curPlayer == 2)
            {
                PieceManager2.piecesHome++;
                if (PieceManager2.piecesHome == 4)
                    GM.endGame();
            }
            else if (curPlayer == 3)
            {
                PieceManager3.piecesHome++;
                if (PieceManager3.piecesHome == 4)
                    GM.endGame();
            }
            else
            {
                PieceManager4.piecesHome++;
                if (PieceManager4.piecesHome == 4)
                    GM.endGame();
            }
            #endregion

        }

        EndOfTurn.endOfTurn(curSquare2);

    }



    // Update is called once per frame
    void Update()
    {
        curSquare = GameManager.currentSquare;
        curPlayer = GameManager.currentPlayer;
        curPiece = GameManager.currentPiece;
    }
}