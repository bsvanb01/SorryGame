using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfTurn : MonoBehaviour {

    public static GameObject playerLabel;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void endOfTurn(int curSquare2)
    {

        #region Clear Buttons

        Sprite UIMask = Resources.Load<Sprite>("unity_builtin_extra");

        GameObject forButton = GameObject.Find("Move Forward");
        //forButton.GetComponentInChildren<Text>().text = "";
        //forButton.GetComponent<Image>().sprite = UIMask;
        //forButton.GetComponent<Button>().interactable = false;
        forButton.SetActive(false);

        GameObject startButton = GameObject.Find("Move From Start");
        //startButton.GetComponentInChildren<Text>().text = "";
        //startButton.GetComponent<Image>().sprite = UIMask;
        //forButton.GetComponent<Button>().interactable = false;
        startButton.SetActive(false);


        GameObject backButton = GameObject.Find("Move Backward");
        backButton.GetComponentInChildren<Text>().text = "";
        backButton.GetComponent<Image>().sprite = UIMask;
        forButton.GetComponent<Button>().interactable = false;


        GameObject swapButton = GameObject.Find("Swap");
        swapButton.GetComponentInChildren<Text>().text = "";
        swapButton.GetComponent<Image>().sprite = UIMask;
        forButton.GetComponent<Button>().interactable = false;



        #endregion

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

        PieceManager1.player1Active = false;
        PieceManager2.player2Active = false;
        PieceManager3.player3Active = false;
        PieceManager4.player4Active = false;

        int curPlayer = GameManager.currentPlayer;
        playerLabel = GameObject.Find("PlayerLabel");
        curPlayer = (GameManager.currentPlayer + 1) % 4;
        if (curPlayer == 0)
            curPlayer = 4;
        playerLabel.GetComponent<Text>().text = "Player " + curPlayer;


        CardDeck.cardCount = 0;
    }
}
