using System.Collections;
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
    int curSquare2;
    GameObject curPiece2;
    public int slideSpaces;

    // Use this for initialization
    void Start()
    {

    }

    public void MovingForward()
    {
        int moveNum = CardDeck.card;
        curSquare2 = GameManager.currentSquare;
        int curPlayer2 = GameManager.currentPlayer;
        curPiece2 = GameManager.currentPiece;
        int spacesLeft = moveNum;
        slideSpaces = 0;



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
                Debug.Log(spacesLeft);
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

        #region bump
        //int nextSquare = curSquare2 + 1;
        //GameObject bumpedPiece;
        //string moveTo = "30";

        //if(Player1Piece1.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p1_Game_Piece_1");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player1Piece2.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p1_Game_Piece_2");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player1Piece3.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p1_Game_Piece_3");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player1Piece4.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p1_Game_Piece_4");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player2Piece1.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p2_Game_Piece_1");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player2Piece2.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p2_Game_Piece_2");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player2Piece3.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p2_Game_Piece_3");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player2Piece4.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p2_Game_Piece_4");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player3Piece1.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p3_Game_Piece_1");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player3Piece2.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p3_Game_Piece_2");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player3Piece3.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p3_Game_Piece_3");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player3Piece4.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p3_Game_Piece_4");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player4Piece1.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p4_Game_Piece_1");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player4Piece2.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p4_Game_Piece_2");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player4Piece3.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p4_Game_Piece_3");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}
        //else if (Player4Piece4.curSquare == nextSquare)
        //{
        //    bumpedPiece = GameObject.Find("p4_Game_Piece_4");
        //    bumpedPiece.transform.position = GameObject.FindGameObjectWithTag(moveTo).transform.position;
        //}

        //curSquare2 += 1;
        //curSquare2 = curSquare2 % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
        //                                  /* movement of the physical piece updating its physical position based on the new curSquare. */
        //curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;

        //Debug.Log("spaces left:" + 0);
        #endregion
        
        #endregion

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

        Invoke("slideSpace", 1.0f);
        #endregion
    }

    public void slideSpace()
    {
        for (int Left = slideSpaces; Left > 0; Left--)
        {
            curSquare2 += 1;
            curSquare2 = curSquare2 % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
                                          /* movement of the physical piece updating its physical position based on the new curSquare. */
            curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;

            Debug.Log("spaces left:" + Left);
        }
        GameManager.currentSquare = curSquare2;

        #region update home tag
        if (curPiece2.tag == "Home")
        {
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
        }
        #endregion
        if(curPiece.tag == "Normal" && curSquare >= 60)
        {
            curPiece.tag = "Safe";
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