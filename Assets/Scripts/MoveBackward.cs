using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBackward : MonoBehaviour
{

    // Use this for initialization


    private static int curSquare;
    private static int curPlayer;
    private static GameObject curPiece;
    public GameObject playerLabel;
    GameManager GM = new GameManager();



    void Start()
    {

    }

    public void MovingBackward()
    {

        int moveNum = CardDeck.card;
        int curSquare2 = GameManager.currentSquare;
        int curPlayer2 = GameManager.currentPlayer;
        GameObject curPiece2 = GameManager.currentPiece;
        int spacesLeft = moveNum;
        int slideSpaces = 0;
        Debug.Log("set up variables");

        if (spacesLeft == 10)
        {
            spacesLeft = 1;
        }

        #region Moving Backward
        for (int Left = spacesLeft; Left > 0; Left--) // iterate until Left = 0; in other words spacesLeft is run out.
        {
            if (curSquare2 == 60 || curSquare2 == 66 || curSquare2 == 72 || curSquare2 == 78) // if its on the end of a safety zone
            {
                if (curSquare2 == 60) curSquare2 = 2;
                if (curSquare2 == 66) curSquare2 = 17;
                if (curSquare2 == 72) curSquare2 = 32;
                if (curSquare2 == 78) curSquare2 = 47;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
            }
            else if (curSquare2 == 0)
            { // if its at space 0 set it to 59 to loop the board
                curSquare2 = 59;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
                curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;
            }
            else
            {
                curSquare2--;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
                curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;
            }
            #endregion

            curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;
            Debug.Log("current sqaure:" + curSquare2);
        }

        #region Slide

        if (curPlayer == 1)
        {
            if (curSquare2 == 16 || curSquare2 == 31 || curSquare2 == 46)
            {
                slideSpaces += 3;
            }
            else if (curSquare2 == 24 || curSquare2 == 39 || curSquare2 == 54)
            {
                slideSpaces += 4;
            }
        }
        if (curPlayer == 2)
        {
            if (curSquare2 == 1 || curSquare2 == 31 || curSquare2 == 46)
            {
                slideSpaces += 3;
            }
            else if (curSquare2 == 9 || curSquare2 == 39 || curSquare2 == 54)
            {
                slideSpaces += 4;
            }
        }
        if (curPlayer == 3)
        {
            if (curSquare2 == 1 || curSquare2 == 16 || curSquare2 == 46)
            {
                slideSpaces += 3;
            }
            else if (curSquare2 == 9 || curSquare2 == 24 || curSquare2 == 54)
            {
                slideSpaces += 4;
            }

        }
        if (curPlayer == 4)
        {
            if (curSquare2 == 1 || curSquare2 == 16 || curSquare2 == 31)
            {
                slideSpaces += 3;
            }
            else if (curSquare2 == 9 || curSquare2 == 24 || curSquare2 == 39)
            {
                slideSpaces += 4;
            }
        }
        for (int Left = slideSpaces; Left > 0; Left--)
        {
            curSquare2 += 1;
            curSquare2 = curSquare2 % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
                                          /* movement of the physical piece updating its physical position based on the new curSquare. */
            curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;

            Debug.Log("spaces left:" + Left);
        }
        #endregion

        GameManager.currentSquare = curSquare2; // update the gameManager version of currentSquare so that it now has curSquare2.
                                                //that will be passed onto curSquare, which is updated every frame.

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
