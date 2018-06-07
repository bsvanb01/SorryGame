using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager2 : MonoBehaviour {

    [SerializeField] private GameObject p2Piece1;
    [SerializeField] private GameObject p2Piece2;
    [SerializeField] private GameObject p2Piece3;
    [SerializeField] private GameObject p2Piece4;
    public static bool player2Active = false;

    GameObject go = null;

    public void activate()
    {
        go = GameObject.Find("Player 2 Pieces");
        go.SetActive(true);

    }

    public void deactivate()
    {
        go = GameObject.Find("Player 2 Pieces");
        go.SetActive(false);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
