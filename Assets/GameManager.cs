using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerLabel;
    public static GameObject currentPiece;
    public static int currentPlayer = 0;
    public static int currentSquare;
    public static GameObject startButton;
    public static GameObject forButton;
    public static GameObject backButton;
    public static GameObject swapButton;

    public GameObject[] spaces = new GameObject[84];

    void Start()
    {
        startButton = GameObject.Find("Move From Start");
        startButton.SetActive(false);

        forButton = GameObject.Find("Move Forward");
        forButton.SetActive(false);

        backButton = GameObject.Find("Move Backward");
        backButton.SetActive(false);

        swapButton = GameObject.Find("Swap");
        swapButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerChange()
    {
        
        currentPlayer = currentPlayer % 4;

        if (currentPlayer == 0)             //Player 1 turn
        {
            bool piece1 = checkMovement(CardDeck.card, Player1Piece1.curSquare, PieceManager1.startSquare, GameObject.Find("p1_Game_Piece_1"), 1);
            bool piece2 = checkMovement(CardDeck.card, Player1Piece2.curSquare, PieceManager1.startSquare, GameObject.Find("p1_Game_Piece_2"), 1);
            bool piece3 = checkMovement(CardDeck.card, Player1Piece3.curSquare, PieceManager1.startSquare, GameObject.Find("p1_Game_Piece_3"), 1);
            bool piece4 = checkMovement(CardDeck.card, Player1Piece4.curSquare, PieceManager1.startSquare, GameObject.Find("p1_Game_Piece_4"), 1);

            if (!piece1 && !piece2 && !piece3 && !piece4)
            {
                EditorUtility.DisplayDialog("Cannot Move", "You are not able to move any of your pieces. You must forfeit your turn.", "OK");
                playerLabel = GameObject.Find("PlayerLabel");
                playerLabel.GetComponent<Text>().text = "Player 2";
                CardDeck.cardCount = 0;
            }
            else
            {
                PieceManager1.player1Active = true;
            }
        }

        else if (currentPlayer == 1)        //Player 2 turn
        {
            bool piece1 = checkMovement(CardDeck.card, Player2Piece1.curSquare, PieceManager2.startSquare, GameObject.Find("p2_Game_Piece_1"), 2);
            bool piece2 = checkMovement(CardDeck.card, Player2Piece2.curSquare, PieceManager2.startSquare, GameObject.Find("p2_Game_Piece_2"), 2);
            bool piece3 = checkMovement(CardDeck.card, Player2Piece3.curSquare, PieceManager2.startSquare, GameObject.Find("p2_Game_Piece_3"), 2);
            bool piece4 = checkMovement(CardDeck.card, Player2Piece4.curSquare, PieceManager2.startSquare, GameObject.Find("p2_Game_Piece_4"), 2);

            if (!piece1 && !piece2 && !piece3 && !piece4)
            {
                EditorUtility.DisplayDialog("Cannot Move", "You are not able to move any of your pieces. You must forfeit your turn.", "OK");
                playerLabel = GameObject.Find("PlayerLabel");
                playerLabel.GetComponent<Text>().text = "Player 3";
                CardDeck.cardCount = 0;
            }
            else
            {
                PieceManager2.player2Active = true;
            }
        }

        else if (currentPlayer == 2)         //Player 3 turn
        {
            bool piece1 = checkMovement(CardDeck.card, Player3Piece1.curSquare, PieceManager3.startSquare, GameObject.Find("p3_Game_Piece_1"), 3);
            bool piece2 = checkMovement(CardDeck.card, Player3Piece2.curSquare, PieceManager3.startSquare, GameObject.Find("p3_Game_Piece_2"), 3);
            bool piece3 = checkMovement(CardDeck.card, Player3Piece3.curSquare, PieceManager3.startSquare, GameObject.Find("p3_Game_Piece_3"), 3);
            bool piece4 = checkMovement(CardDeck.card, Player3Piece4.curSquare, PieceManager3.startSquare, GameObject.Find("p3_Game_Piece_4"), 3);

            if (!piece1 && !piece2 && !piece3 && !piece4)
            {
                EditorUtility.DisplayDialog("Cannot Move", "You are not able to move any of your pieces. You must forfeit your turn.", "OK");
                playerLabel = GameObject.Find("PlayerLabel");
                playerLabel.GetComponent<Text>().text = "Player 4";
                CardDeck.cardCount = 0;
            }
            else
            {
                PieceManager3.player3Active = true;
            }

        }

        else if (currentPlayer == 3)           //Player 4 turn
        {
            bool piece1 = checkMovement(CardDeck.card, Player4Piece1.curSquare, PieceManager4.startSquare, GameObject.Find("p4_Game_Piece_1"), 4);
            bool piece2 = checkMovement(CardDeck.card, Player4Piece2.curSquare, PieceManager4.startSquare, GameObject.Find("p4_Game_Piece_2"), 4);
            bool piece3 = checkMovement(CardDeck.card, Player4Piece3.curSquare, PieceManager4.startSquare, GameObject.Find("p4_Game_Piece_3"), 4);
            bool piece4 = checkMovement(CardDeck.card, Player4Piece4.curSquare, PieceManager4.startSquare, GameObject.Find("p4_Game_Piece_4"), 4);

            if (!piece1 && !piece2 && !piece3 && !piece4)
            {
                EditorUtility.DisplayDialog("Cannot Move", "You are not able to move any of your pieces. You must forfeit your turn.", "OK");
                playerLabel = GameObject.Find("PlayerLabel");
                playerLabel.GetComponent<Text>().text = "Player 1";
                CardDeck.cardCount = 0;
            }
            else
            {
                PieceManager4.player4Active = true;
            }
        }
    }

    public bool checkMovement(int card, int curSquare, int startSquare, GameObject piece, int player)
    {
        bool anyMovement = false;

        #region move from start
        if (card == 1 || card == 2)
        {
            if (piece.tag == "Start")
                anyMovement = true;
        }
        #endregion

        #region move forward
        if (card == 1 || card == 2 || card == 3 || card == 5 || card == 7 || card == 8 || card == 10 || card == 11 || card == 12)
        {
            if (piece.tag == "Normal" && curSquare > (startSquare + 46) % 60 && curSquare < (startSquare + 58) % 60)
            {
                if ((curSquare + card) % 60 <= (startSquare + 64) % 60) // won't fit in the home spaces
                    anyMovement = true;
            }
            else if (piece.tag == "Safe")
            {
                if ((curSquare % 6) + card <= 5)
                    anyMovement = true;
            }
            else if (piece.tag == "Normal" || piece.tag == "Safe")
                anyMovement = true;
        }
        #endregion

        #region move backward
        if (card == 4 || card == 10)
        {
            if (piece.tag == "Normal" || piece.tag == "Safe")
                anyMovement = true;
        }
        #endregion

        #region swap sorry
        if (card == 13)
        {
            if (piece.tag != "Start")
            {

            }
            //all other players are not on normal squares
            else if (player == 1)
            {
                if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
                         GameObject.Find("p2_Game_Piece_2").tag != "Normal" &&
                         GameObject.Find("p2_Game_Piece_3").tag != "Normal" &&
                         GameObject.Find("p2_Game_Piece_4").tag != "Normal" &&
                         GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
                         GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
                         GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
                         GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
                         GameObject.Find("p4_Game_Piece_1").tag != "Normal" &&
                         GameObject.Find("p4_Game_Piece_2").tag != "Normal" &&
                         GameObject.Find("p4_Game_Piece_3").tag != "Normal" &&
                         GameObject.Find("p4_Game_Piece_4").tag != "Normal")
                {

                }
                else
                    anyMovement = true;
            }
            else if (player == 2)
            {
                if (GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_4").tag != "Normal")
                {

                }
                else
                    anyMovement = true;
            }
            else if (player == 3)
            {
                if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_4").tag != "Normal")
                {

                }
                else
                    anyMovement = true;
            }
            else if (player == 4)
            {
                if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_4").tag != "Normal")
                {

                }
                else
                    anyMovement = true;
            }
        }
        #endregion

        #region swap 11
        if (card == 11)
        {
            if (piece.tag != "Normal")
            {
            }
            //all other players are not on normal squares
            else if (player == 1)
            {
                if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
                         GameObject.Find("p2_Game_Piece_2").tag != "Normal" &&
                         GameObject.Find("p2_Game_Piece_3").tag != "Normal" &&
                         GameObject.Find("p2_Game_Piece_4").tag != "Normal" &&
                         GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
                         GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
                         GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
                         GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
                         GameObject.Find("p4_Game_Piece_1").tag != "Normal" &&
                         GameObject.Find("p4_Game_Piece_2").tag != "Normal" &&
                         GameObject.Find("p4_Game_Piece_3").tag != "Normal" &&
                         GameObject.Find("p4_Game_Piece_4").tag != "Normal")
                {

                }
                else
                    anyMovement = true;
            }
            else if (player == 2)
            {
                if (GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_4").tag != "Normal")
                {

                }
                else
                    anyMovement = true;
            }
            else if (player == 3)
            {
                if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p4_Game_Piece_4").tag != "Normal")
                {

                }
                else
                    anyMovement = true;
            }
            else if (player == 4)
            {
                if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p2_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
                        GameObject.Find("p1_Game_Piece_4").tag != "Normal")
                {

                }
                else
                    anyMovement = true;
            }
        }
        #endregion
        return anyMovement;
    }

    public void endGame()
    {
        EditorUtility.DisplayDialog("You Win!", "You won!", "OK");
    }
}