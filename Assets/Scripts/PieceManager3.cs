using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager3 : MonoBehaviour {


    [SerializeField] private GameObject p3Piece1;
    [SerializeField] private GameObject p3Piece2;
    [SerializeField] private GameObject p3Piece3;
    [SerializeField] private GameObject p3Piece4;
    public static bool player3Active = false;


    GameObject go = null;

    public void activate()
    {
        go = GameObject.Find("Player 3 Pieces");
        go.SetActive(true);

    }

    public void deactivate()
    {
        go = GameObject.Find("Player 3 Pieces");
        go.SetActive(false);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
