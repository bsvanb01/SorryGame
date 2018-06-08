using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveFromStart : MonoBehaviour
{

    private static int curSquare;
    private static int curPlayer;
    private static GameObject curPiece;
    GameManager forSpaces;


    // Use this for initialization
    void Start()
    {

    }

    public void MovingFromStart()
    {
        int moveNum = CardDeck.card;
        int curSquare2 = GameManager.currentSquare;
        int curPlayer2 = GameManager.currentPlayer;
        GameObject curPiece2 = GameManager.currentPiece;
        int spacesLeft = moveNum;

        #region Normal Movement

        switch (curPlayer2) // based on which player is moving out of start move to a different "out of the gate" square
        {
            case 1:
                curPiece2.transform.position = GameObject.FindGameObjectWithTag("4").transform.position;
                curSquare2 = 4;
                break;
            case 2:
                curPiece2.transform.position = GameObject.FindGameObjectWithTag("19").transform.position;
                curSquare2 = 19;
                break;
            case 3:
                curPiece2.transform.position = GameObject.FindGameObjectWithTag("34").transform.position;
                curSquare2 = 34;
                break;
            case 4:
                curPiece2.transform.position = GameObject.FindGameObjectWithTag("49").transform.position;
                curSquare2 = 49;
                break;
        }
        spacesLeft -= 1;

        //if (spacesLeft == 1) // if you got a 2 card
        //{
        //    curSquare2 += 1;
        //    curSquare2 = curSquare2 % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
        //                                  /* movement of the physical piece updating its physical position based on the new curSquare. */
        //    curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;
        //}
        #endregion

        GameManager.currentSquare = curSquare2; // update the gameManager version of currentSquare so that it now has curSquare2.
                                                //that will be passed onto curSquare, which is updated every frame.
        Debug.Log("current square now:" + GameManager.currentSquare);
        curPiece2.tag = "Normal";
        GameManager.currentPiece = curPiece2; // changed

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