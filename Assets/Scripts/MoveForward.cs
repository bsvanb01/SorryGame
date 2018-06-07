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
    public GameObject playerLabel;
    GameManager GM = new GameManager();


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

        #region Clear Buttons

        Sprite UIMask = Resources.Load<Sprite>("unity_builtin_extra");

        GameObject forButton = GameObject.Find("Move Forward");
        forButton.GetComponentInChildren<Text>().text = "";
        forButton.GetComponent<Image>().sprite = UIMask;
        forButton.GetComponent<Button>().interactable = false;

        GameObject startButton = GameObject.Find("Move From Start");
        startButton.GetComponentInChildren<Text>().text = "";
        startButton.GetComponent<Image>().sprite = UIMask;
        forButton.GetComponent<Button>().interactable = false;


        GameObject backButton = GameObject.Find("Move Backward");
        backButton.GetComponentInChildren<Text>().text = "";
        backButton.GetComponent<Image>().sprite = UIMask;
        forButton.GetComponent<Button>().interactable = false;


        GameObject swapButton = GameObject.Find("Swap");
        swapButton.GetComponentInChildren<Text>().text = "";
        swapButton.GetComponent<Image>().sprite = UIMask;
        forButton.GetComponent<Button>().interactable = false;



        #endregion

        #region Safety Zone
        if ((curPlayer2 == 1 && curSquare + moveNum > 2 && (curSquare2 <= 2 || (curSquare2 >= 50 && curSquare2 < 60))) // that last one basically means it has to be in the range of 50 to 2 spacewise, and nothing else.
        || (curPlayer2 == 2 && curSquare + moveNum > 17 && curSquare2 <= 17)
        || (curPlayer2 == 3 && curSquare + moveNum > 32 && curSquare2 <= 32)
        || (curPlayer2 == 4 && curSquare + moveNum > 47 && curSquare2 <= 47) && curPiece2.tag == "Normal") // if going into safety zone. has to be going to a space greater than their last normal space. and has to be currently on a space less than or equal to the last normal space.
        {
            while (curSquare2 != 2 || curSquare2 != 17 || curSquare2 != 32 || curSquare2 != 47)
            { // keep moving till you hit the space that makes you go into the safety zone
                curSquare2 += 1;
                curSquare2 = curSquare % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
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

            while (spacesLeft != 0)
            {
                curSquare += 1;
                spacesLeft -= 1;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
            }
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

        #region Set Current Square

        if (GameManager.currentPiece == GameObject.Find("p1_Game_Piece_1"))
            Player1Piece1.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p1_Game_Piece_2"))
            Player1Piece2.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p1_Game_Piece_3"))
            Player1Piece3.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p1_Game_Piece_4"))
            Player1Piece4.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p2_Game_Piece_1"))
            Player2Piece1.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p2_Game_Piece_2"))
            Player2Piece2.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p2_Game_Piece_3"))
            Player2Piece3.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p2_Game_Piece_4"))
            Player2Piece4.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p3_Game_Piece_1"))
            Player3Piece1.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p3_Game_Piece_2"))
            Player3Piece2.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p3_Game_Piece_3"))
            Player3Piece3.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p3_Game_Piece_4"))
            Player3Piece4.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p4_Game_Piece_1"))
            Player4Piece1.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p4_Game_Piece_2"))
            Player4Piece2.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p4_Game_Piece_3"))
            Player4Piece3.curSquare = curSquare2;
        else if (GameManager.currentPiece == GameObject.Find("p4_Game_Piece_4"))
            Player4Piece4.curSquare = curSquare2;

        #endregion

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
        }

        if (curPlayer2 == 1)
            PieceManager1.player1Active = false;
        else if (curPlayer2 == 2)
            PieceManager2.player2Active = false;
        else if (curPlayer2 == 2)
            PieceManager3.player3Active = false;
        else
            PieceManager4.player4Active = false;


        playerLabel = GameObject.Find("PlayerLabel");
        curPlayer = (GameManager.currentPlayer + 1) % 4;
        if (curPlayer == 0)
            curPlayer = 4;
        playerLabel.GetComponent<Text>().text = "Player " + curPlayer;


        CardDeck.cardCount = 0;
    }



    // Update is called once per frame
    void Update()
    {
        curSquare = GameManager.currentSquare;
        curPlayer = GameManager.currentPlayer;
        curPiece = GameManager.currentPiece;
    }
}