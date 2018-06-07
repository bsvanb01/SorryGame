using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void move(int cardNum)
    {

    }


    public bool checkMovement(int card, int player, int curSquare, int startSquare)
    {
        bool anyMovement = false;
        Renderer piece = GetComponent<Renderer>();

        #region move from start
        if (card == 1 || card == 2)
        {
            GameObject startButton = GameObject.Find("Move From Start");
            startButton.GetComponent<Text>().text = "Move From Start";
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
            GameObject forButton = GameObject.Find("Move Forward");
            forButton.GetComponent<Text>().text = "Move Forward";
            Sprite UISprite = Resources.Load("unity_builtin_extra") as Sprite;
            forButton.GetComponent<Image>().sprite = UISprite;

            if (piece.tag == "Normal" && curSquare > (startSquare + 46) % 60 && curSquare < (startSquare + 58) % 60)
            {
                if (curSquare + card > startSquare + 64) // won't fit in the home spaces
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
                //THIS IS WRONG, DEPENDS ON HOW THE SAFETY SQUARES ARE NAMED
                if (curSquare + card > 5)
                    forButton.GetComponent<Button>().interactable = false;
                else
                {
                    forButton.GetComponent<Button>().interactable = true;
                    anyMovement = true;
                }
            }
            else if (piece.tag == "Home")
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
            GameObject backButton = GameObject.Find("Move Backward");
            backButton.GetComponent<Text>().text = "Move Backward";
            Sprite UISprite = Resources.Load("unity_builtin_extra") as Sprite;
            backButton.GetComponent<Image>().sprite = UISprite;
            backButton.GetComponent<Button>().interactable = true;
            anyMovement = true;
        }
        #endregion

        #region swap sorry
        if (card == 13)
        {
            //if(piece.tag != "Start")
            //{

            //}
            //else if (all other players pieces are not in normal spaces
            //else
            //anyMovement = true;
        }
        #endregion

        #region swap 11
        if (card == 11)
        {
            //GameObject swapButton = GameObject.Find("Swap");
            //make button visible

            //if(piece.squareType!=normal)
            //swapButton.GetComponent<Button>().interactable = false;
            //else if(All other players pieces aren't normal)
            //swapButton.GetComponent<Button>().interactable = false;
            //else
            //anyMovement = true;
            //swapButton.GetComponent<Button>().interactable = true;
        }
        #endregion
        return anyMovement;
    }
}