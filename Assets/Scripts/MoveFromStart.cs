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
    public GameObject playerLabel;


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

        #region Normal Movement

        switch (curPlayer2) // based on which player is moving out of start move to a different "out of the gate" square
        {
            case 1:
                curPiece2.transform.position = GameObject.FindGameObjectWithTag("4").transform.position;
                curSquare2 = 4;
                Debug.Log("it was player one");
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

        if (spacesLeft == 1) // if you got a 2 card
        {
            curSquare2 += 1;
            curSquare2 = curSquare2 % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
                                          /* movement of the physical piece updating its physical position based on the new curSquare. */
            curPiece2.transform.position = GameObject.FindGameObjectWithTag(curSquare2.ToString()).transform.position;
        }
        #endregion

        GameManager.currentSquare = curSquare2; // update the gameManager version of currentSquare so that it now has curSquare2.
                                                //that will be passed onto curSquare, which is updated every frame.
        Debug.Log("current square now:" + GameManager.currentSquare);
        curPiece2.tag = "Normal";
        GameManager.currentPiece = curPiece2; // changed

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
            curPlayer = 1;
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