using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkMovement(int card, int curSquare, int startSquare, Renderer piece, int player)
    {
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

            // player 1 safety zone
            if (player == 1 && piece.tag == "Normal" && (curSquare > 50 || (curSquare % 60) < 3))
            {
                if (curSquare == 0 || curSquare == 1 || curSquare == 2)
                    curSquare += 60;
                if (curSquare + card > 68) // won't fit in the home spaces
                    forButton.GetComponent<Button>().interactable = false;
                else
                    forButton.GetComponent<Button>().interactable = true;
            }

            else if (player == 2 && piece.tag == "Normal" && curSquare > 5 && curSquare < 18)
            {
                if (curSquare + card > 23) // won't fit in the home spaces
                    forButton.GetComponent<Button>().interactable = false;
                else
                    forButton.GetComponent<Button>().interactable = true;
            }

            else if (player == 3 && piece.tag == "Normal" && curSquare > 20 && curSquare < 33)
            {
                if (curSquare + card > 38) // won't fit in the home spaces
                    forButton.GetComponent<Button>().interactable = false;
                else
                    forButton.GetComponent<Button>().interactable = true;
            }

            else if (player == 4 && piece.tag == "Normal" && curSquare > 35 && curSquare < 48)
            {
                if (curSquare + card > 53) // won't fit in the home spaces
                    forButton.GetComponent<Button>().interactable = false;
                else
                    forButton.GetComponent<Button>().interactable = true;
            }

            else if (player == 1 && piece.tag == "Safe")
            {
                if ((curSquare % 60) + card > 5)
                    forButton.GetComponent<Button>().interactable = false;
                else
                    forButton.GetComponent<Button>().interactable = true;
            }

            else if (player == 2 && piece.tag == "Safe")
            {
                if ((curSquare - 66) + card > 5)
                    forButton.GetComponent<Button>().interactable = false;
                else
                    forButton.GetComponent<Button>().interactable = true;
            }

            else if (player == 3 && piece.tag == "Safe")
            {
                if ((curSquare - 72) + card > 5)
                    forButton.GetComponent<Button>().interactable = false;
                else
                    forButton.GetComponent<Button>().interactable = true;
            }

            else if (player == 4 && piece.tag == "Safe")
            {
                if ((curSquare - 78) + card > 5)
                    forButton.GetComponent<Button>().interactable = false;
                else
                    forButton.GetComponent<Button>().interactable = true;
            }

            else if (piece.tag == "Home" || piece.tag == "Start")
                forButton.GetComponent<Button>().interactable = false;
            else
                forButton.GetComponent<Button>().interactable = true;
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
                backButton.GetComponent<Button>().interactable = true;
            else
                backButton.GetComponent<Button>().interactable = false;
        }
        #endregion

        if(player == 1)
        {
            #region swap sorry
            //if (card == 13)
            //{
            //    if (piece.tag != "Start")
            //    {

            //    }
            //    //all other players are not on normal squares
            //    //change this for each player
            //    else if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p2_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p2_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p2_Game_Piece_4").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_4").tag != "Normal")
            //    {

            //    }
            //    else
            //    {
            //        anyMovement = true;
            //    }
            //}
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
                    swapButton.GetComponent<Button>().interactable = false;
                //all other players are not on normal squares
                else if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
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
                    swapButton.GetComponent<Button>().interactable = false;
                }
                else
                    swapButton.GetComponent<Button>().interactable = true;
            }
            #endregion
        }
        else if (player == 2)
        {
            #region swap sorry
            //if (card == 13)
            //{
            //    if (piece.tag != "Start")
            //    {

            //    }
            //    //all other players are not on normal squares
            //    //change this for each player
            //    else if (GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_4").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_4").tag != "Normal")
            //    {

            //    }
            //    else
            //    {
            //    }
            //}
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
                    swapButton.GetComponent<Button>().interactable = false;
                //all other players are not on normal squares
                else if (GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
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
                    swapButton.GetComponent<Button>().interactable = false;
                }
                else
                    swapButton.GetComponent<Button>().interactable = true;
            }
            #endregion
        }
        else if (player == 3){
            #region swap sorry
            //if (card == 13)
            //{
            //    if (piece.tag != "Start")
            //    {

            //    }
            //    //all other players are not on normal squares
            //    else if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p2_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p2_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p2_Game_Piece_4").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_4").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p4_Game_Piece_4").tag != "Normal")
            //    {

            //    }
            //    else
            //    {
            //    }
            //}
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
                    swapButton.GetComponent<Button>().interactable = true;
            }
            #endregion
        }
        else
        {
            #region swap sorry
            //if (card == 13)
            //{
            //    if (piece.tag != "Start")
            //    {

            //    }
            //    //all other players are not on normal squares
            //    else if (GameObject.Find("p2_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p2_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p2_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p2_Game_Piece_4").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
            //         GameObject.Find("p1_Game_Piece_4").tag != "Normal")
            //    {

            //    }
            //    else
            //    {
            //    }
            //}
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
                     GameObject.Find("p3_Game_Piece_1").tag != "Normal" &&
                     GameObject.Find("p3_Game_Piece_2").tag != "Normal" &&
                     GameObject.Find("p3_Game_Piece_3").tag != "Normal" &&
                     GameObject.Find("p3_Game_Piece_4").tag != "Normal" &&
                    GameObject.Find("p1_Game_Piece_1").tag != "Normal" &&
                     GameObject.Find("p1_Game_Piece_2").tag != "Normal" &&
                     GameObject.Find("p1_Game_Piece_3").tag != "Normal" &&
                     GameObject.Find("p1_Game_Piece_4").tag != "Normal")
                {
                    swapButton.GetComponent<Button>().interactable = false;
                }
                else
                    swapButton.GetComponent<Button>().interactable = true;
            }
            #endregion
        }
    }
}
