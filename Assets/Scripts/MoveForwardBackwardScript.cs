using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBackward : MonoBehaviour
{

    private static int curSquare;
    private static int curPlayer;
    private static GameObject curPiece;


    // Use this for initialization
    void Start()
    {

    }

    public static void MovingForward(int moveNum, int curSquare2, int curPlayer2, ref GameObject curPiece2)
    {
        int spacesLeft = moveNum;

        #region Safety Zone
        if ((curSquare + moveNum > 2 && curPlayer2 == 1)
        || (curSquare + moveNum > 17 && curPlayer2 == 2)
        || (curSquare + moveNum > 32 && curPlayer2 == 3)
        || (curSquare + moveNum > 47 && curPlayer2 == 4)) // if going into safety zone. has to be going to a space greater than their last normal space.
        {
            while (curSquare2 != 2 || curSquare2 != 17 || curSquare2 != 32 || curSquare2 != 47)
            { // keep moving till you hit the space that makes you go into the safety zone
                curSquare2 += 1;
                curSquare2 = curSquare % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
                /* movement of the physical piece updating its physical position based on the new curSquare. */
                spacesLeft -= 1; // subtract one from the spaces left
            }
            spacesLeft -= 1;

            switch (curPlayer) // assigning each piece its new position in the safety zone
            {
                case 1:
                    curSquare2 = 60;
                    break;
                case 2:
                    curSquare2 = 66;
                    break;
                case 3:
                    curSquare2 = 72;
                    break;
                case 4:
                    curSquare2 = 78;
                    break;
            }

            while (spacesLeft != 0)
            {
                curSquare += 1;
                spacesLeft -= 1;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
            }
            #endregion

        #region Normal Movement
        }
        else
        {
            for (int Left = spacesLeft; Left > 0; Left--)
            {
                curSquare2 += 1;
                curSquare2 = curSquare2 % 60; // if the number is 60, that sets it back to 0. so the board loops its normal spaces
                /* movement of the physical piece updating its physical position based on the new curSquare. */
            }
        }
        #endregion

        GameManager.currentSquare = curSquare2; // update the gameManager version of currentSquare so that it now has curSquare2.
                                                //that will be passed onto curSquare, which is updated every frame.

    }

    public static void MovingBackward(int moveNum, int curSquare2, int curPlayer2)
    {
        int spacesLeft = moveNum;
        #region Moving Backward
        for (int Left = spacesLeft; Left > 0; Left--) // iterate until Left = 0; in other words spacesLeft is run out.
        {
            if (curSquare2 == 60 || curSquare2 == 66 || curSquare2 == 72 || curSquare2 == 78) // if its on the end of a safety zone
            {
                if (curSquare2 == 60) curSquare2 = 2;
                if (curSquare2 == 66) curSquare2 = 17;
                if (curSquare2 == 72) curSquare2 = 32;
                if (curSquare2 == 78) curSquare2 = 47;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
            }
            else if (curSquare2 == 0)
            { // if its at space 0 set it to 59 to loop the board
                curSquare2 = 59;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
            }
            else
            {
                curSquare2--;
                /* movement of the physical piece updating its physical position based on the new curSquare. */
            }
            #endregion

        }

        GameManager.currentSquare = curSquare2; // update the gameManager version of currentSquare so that it now has curSquare2.
                                                //that will be passed onto curSquare, which is updated every frame.
    }

    // Update is called once per frame
    void Update()
    {
        curSquare = GameManager.currentSquare;
        curPlayer = GameManager.currentPlayer;
        curPiece = GameManager.currentPiece;
    }
}