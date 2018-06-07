using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Piece1 : MonoBehaviour
{

    public int curSquare = 70;

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
                if (hit.transform.name == "p3_Game_Piece_1" && PieceManager3.player3Active)
                {
                    GameManager.currentPiece = GameObject.Find("p3_Game_Piece_1");
                    GameManager.currentPlayer = 3;
                    GameManager.currentSquare = curSquare;

                    //call checkmovement
                }
            }
        }
    }
}
