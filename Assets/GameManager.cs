using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;
    public static GameObject currentPiece;
    public static int currentPlayer = 0;
    public static int currentSquare;

    public Text playerTurnText;

    
    public void PlayerChange ()
    {

        //Debug.Log("Access PlayerChange()");

        currentPlayer = currentPlayer % 4;

        if (currentPlayer == 0)             //Player 1 turn
        {
            Debug.Log("Player 1 turn");
            if (GameObject.Find("Player 1 Pieces") != null)
            {
                PieceManager1.player1Active = true;
                PieceManager2.player2Active = false;
                PieceManager3.player3Active = false;
                PieceManager4.player4Active = false;

            }
            //currentPlayer++;
        }


        else if (currentPlayer == 1)        //Player 2 turn
        {
            Debug.Log("Player 2 turn");
            if (GameObject.Find("Player 2 Pieces") != null)
            {
                PieceManager1.player1Active = false;
                PieceManager2.player2Active = true;
                PieceManager3.player3Active = false;
                PieceManager4.player4Active = false;
                
            }
            //currentPlayer++;

        }


        else if (currentPlayer == 2)         //Player 3 turn
        {
            Debug.Log("Player 3 turn");
            if (GameObject.Find("Player 3 Pieces") != null)
            {
                PieceManager1.player1Active = false;
                PieceManager2.player2Active = false;
                PieceManager3.player3Active = true;
                PieceManager4.player4Active = false;
                
            }
            //currentPlayer++;
        }


        else if (currentPlayer == 3)           //Player 4 turn
        {
            Debug.Log("Player 4 turn");                          
            if (GameObject.Find("Player 4 Pieces") != null)
            {

                PieceManager1.player1Active = false;
                PieceManager2.player2Active = false;
                PieceManager3.player3Active = false;
                PieceManager4.player4Active = true;
       
            }
            
        }
        

    }


    // Update is called once per frame
    void Update () {
		
	}
}


	

