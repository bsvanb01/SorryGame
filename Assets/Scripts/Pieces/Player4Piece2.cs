using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Piece2 : MonoBehaviour
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
                if (hit.transform.name == "p4_Game_Piece_2" && PieceManager4.player4Active)
                {
                    GameManager.currentPiece = GameObject.Find("p4_Game_Piece_2");
                    GameManager.currentPlayer = 4;
                    GameManager.currentSquare = curSquare;

                    //call checkmovement
                }
            }
        }
    }
}
