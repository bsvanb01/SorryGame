using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void move(int cardNum)
    {

    }


    public bool checkMovement(int card, int player)
    {
        bool anyMovement = false;
        Renderer piece = GetComponent<Renderer>();

        #region move from start
        if(card == 1 || card == 2)
        {
            GameObject startButton = GameObject.Find("Move From Start");
            startButton.GetComponent<Text>().text = "Move From Start";
            Sprite UISprite = Resources.Load("unity_builtin_extra") as Sprite;
            startButton.GetComponent<Image>().sprite = UISprite;

            //if(!piece.squareType.Equals("start"))
            //  startButton.GetComponent<Button>().interactable = false;
            //else
            //  startButton.GetComponent<Button>().interactable = true;
            //  anyMovement = true;
            //RedPiece1.curSquare = 0;
        }
        #endregion

        #region move forward
        if (card == 1 || card == 2 || card == 3 || card == 5 || card == 7 || card == 8 || card == 10 || card == 11 || card == 12)
        {
            GameObject forButton = GameObject.Find("Move Forward");
            //make button visible

            //if(piece.squareType == normal && piece.curSquare > (player.startSquare + 50) % 60 && piece.curSquare < (player.startSquare + 60) % 60)
            //{
            //    if(piece.curSquare + card > player.startSquare + 65)
            //    {
            //        forButton.GetComponent<Button>().interactable = false;
            //    }
            //    else
            //    {
            //        forButton.GetComponent<Button>().interactable = true;
            //        anyMovement = true;
            //    }
            //}
            //else if (piece.squareType == "safe")
            //{
            //    if(piece.curSquare + card > 5)
            //        forButton.GetComponent<Button>().interactable = false;
            //    else
            //    {
            //        forButton.GetComponent<Button>().interactable = true;
            //        anyMovement = true;
            //    }
            //}
            //else if (piece.squareType == "home")
            //{
            //    forButton.GetComponent<Button>().interactable = false;
            //}
            //else
            //{
            //    forButton.GetComponent<Button>().interactable = true;
            //    anyMovement = true;
            //}
        }
        #endregion

        #region move backward
        if(card == 4 || card == 10)
        {
            GameObject backButton = GameObject.Find("Move Backward");
            //make button visible
            backButton.GetComponent<Button>().interactable = true;
            anyMovement = true;
        }
        #endregion

        #region swap sorry
        if(card == 13)
        {
            //if(piece.squareType != "start")
            //else if (all other players pieces are not in normal spaces
            //else
                    //anyMovement = true;
        }
        #endregion

        #region swap 11
        if (card == 11)
        {
            GameObject swapButton = GameObject.Find("Swap");
            //make button visible

            //if(piece.squareType!=normal)
            //swapButton.GetComponent<Button>().interactable = false;
            //else if(FindObjectsOfTypeAll other players pieces aren't normal)
            //swapButton.GetComponent<Button>().interactable = false;
            //else
            //anyMovement = true;
            //swapButton.GetComponent<Button>().interactable = true;
        }
        #endregion
        return anyMovement;
    }
}
