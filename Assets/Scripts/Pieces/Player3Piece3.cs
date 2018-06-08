using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3Piece3 : MonoBehaviour
{

    public static int curSquare = 34;

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
                if (hit.transform.name == "p3_Game_Piece_3" && PieceManager3.player3Active)
                {
                    GameManager.currentPiece = GameObject.Find("p3_Game_Piece_3");
                    GameManager.currentPlayer = 3;
                    GameManager.currentSquare = curSquare;

                    bool anyMovement = checkMovement(CardDeck.card, curSquare, PieceManager3.startSquare, GetComponent<Renderer>());
                }
            }
        }
    }

    public bool checkMovement(int card, int curSquare, int startSquare, Renderer piece)
    {
        bool anyMovement = false;

        #region move from start
        if (card == 1 || card == 2)
        {
            GameObject startButton = GameManager.startButton;
            startButton.SetActive(true);
            startButton.GetComponentInChildren<Text>().text = "Move From Start";
            Sprite UISprite = Resources.Load("unity_builtin_extra") as Sprite;
            startButton.GetComponent<Image>().sprite = UISprite;

            if (!(piece.tag == "Start"))
            {
                startButton.GetComponent<Button>().interactable = false;
            }
            else
                startButton.GetComponent<Button>().interactable = true;
            anyMovement = true;
        }
        #endregion

        #region move forward
        if (card == 1 || card == 2 || card == 3 || card == 5 || card == 7 || card == 8 || card == 10 || card == 11 || card == 12)
        {
            GameObject forButton = GameManager.forButton;
            forButton.SetActive(true);
            forButton.GetComponentInChildren<Text>().text = "Move Forward";
            Sprite UISprite = Resources.Load("unity_builtin_extra") as Sprite;
            forButton.GetComponent<Image>().sprite = UISprite;

            if (piece.tag == "Normal" && curSquare > (startSquare + 46) && curSquare < (startSquare + 58) % 60)
            {
                if ((curSquare + card) % 60 > (startSquare + 64) % 60) // won't fit in the home spaces
                {
                    forButton.GetComponent<Button>().interactable = false;
                }
                else
                {
                    forButton.GetComponent<Button>().interactable = true;
                    anyMovement = true;
                }
            }
            else if (piece.tag == "Safe")
            {
                if ((curSquare % 6) + card > 5)
                    forButton.GetComponent<Button>().interactable = false;
                else
                {
                    forButton.GetComponent<Button>().interactable = true;
                    anyMovement = true;
                }
            }
            else if (piece.tag == "Home" || piece.tag == "Start")
            {
                forButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                forButton.GetComponent<Button>().interactable = true;
                anyMovement = true;
            }
        }
        #endregion

        #region move backward
        if (card == 4 || card == 10)
        {
            GameObject backButton = GameManager.backButton;
            backButton.SetActive(true);
            backButton.GetComponentInChildren<Text>().text = "Move Backward";
            Sprite UISprite = Resources.Load("unity_builtin_extra") as Sprite;
            backButton.GetComponent<Image>().sprite = UISprite;

            if (piece.tag == "Normal" || piece.tag == "Safe")
            {
                backButton.GetComponent<Button>().interactable = true;
                anyMovement = true;
            }
            else
                backButton.GetComponent<Button>().interactable = false;
        }
        #endregion

        #region swap sorry
        if (card == 13)
        {
            if (piece.tag != "Start")
            {

            }
            //all other players are not on normal squares
            else if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
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
            {
                anyMovement = true;
            }
        }
        #endregion

        #region swap 11
        if (card == 11)
        {
            GameObject swapButton = GameManager.swapButton;
            swapButton.SetActive(true);
            swapButton.GetComponentInChildren<Text>().text = "Swap";
            Sprite UISprite = Resources.Load("unity_builtin_extra") as Sprite;
            swapButton.GetComponent<Image>().sprite = UISprite;

            if (piece.tag != "Normal")
            {
                swapButton.GetComponent<Button>().interactable = false;
            }
            //all other players are not on normal squares
            else if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
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
                swapButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                anyMovement = true;
                swapButton.GetComponent<Button>().interactable = true;
            }
        }
        #endregion
        return anyMovement;
    }
}
