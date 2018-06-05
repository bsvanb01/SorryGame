using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager4 : MonoBehaviour {


    [SerializeField] private GameObject p4Piece1;
    [SerializeField] private GameObject p4Piece2;
    [SerializeField] private GameObject p4Piece3;
    [SerializeField] private GameObject p4Piece4;
    public static bool player4Active = false;

    public float movespeed;
    private Vector3 Direction;
    
    // Use this for initialization
    void Start () {
        //Direction = Vector3.left;
        //movespeed = 1.8F;
        //GameObject.FindGameObjectWithTag("Player4Piece1").transform.Translate(Direction * movespeed);

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
