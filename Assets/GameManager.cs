using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Use this for initialization

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject player3;
    [SerializeField]
    private GameObject player4;
    public static GameObject currentPiece;
    public static int currentPlayer = 0;
    public static int currentSquare;

    public GameObject[] spaces = new GameObject[84];

    void Start()
    {

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
            Debug.Log("Player 1 turn");
            PieceManager1.player1Active = true;
            PieceManager2.player2Active = false;
            PieceManager3.player3Active = false;
            PieceManager4.player4Active = false;
        }

        else if (currentPlayer == 1)        //Player 2 turn
        {
            Debug.Log("Player 2 turn");

            PieceManager1.player1Active = false;
            PieceManager2.player2Active = true;
            PieceManager3.player3Active = false;
            PieceManager4.player4Active = false;

        }

        else if (currentPlayer == 2)         //Player 3 turn
        {
            Debug.Log("Player 3 turn");

            PieceManager1.player1Active = false;
            PieceManager2.player2Active = false;
            PieceManager3.player3Active = true;
            PieceManager4.player4Active = false;

        }

        else if (currentPlayer == 3)           //Player 4 turn
        {
            Debug.Log("Player 4 turn");

            PieceManager1.player1Active = false;
            PieceManager2.player2Active = false;
            PieceManager3.player3Active = false;
            PieceManager4.player4Active = true;

        }
    }
}
