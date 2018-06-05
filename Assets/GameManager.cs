using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;
    public static GameObject currentPiece;
    public static int currentPlayer;
    public static int currentSquare;

    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
