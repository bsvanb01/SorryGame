using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDeck : MonoBehaviour {
    public const int SORRY = 13;
    public static List<int> orgDeck = new List<int>()
            { 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 7, 7, 7, 7, 8, 8, 8, 8, 10, 10, 10, 10, 11, 11, 11, 11, 12, 12, 12, 12, SORRY, SORRY, SORRY, SORRY };
    public List<int> curDeck = orgDeck;
    public int card;
    public Material[] materialsArray = new Material[11];

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.Translate(3, 0, 15);
            card = drawCard();
            updateCard(card);
            Invoke("zoomOut", 3.5f);
        }
    }

    public void zoomOut()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.Translate(-3, 0, -15);
    }

    public void zoomIn()
    {
        Camera.main.orthographic = true;
        
        Camera.main.orthographic = false;

    }

    public int drawCard()
    {
        if (curDeck.Count == 0)
            curDeck = orgDeck;

        System.Random rnd = new System.Random();
        int indexOfCard = rnd.Next(0, curDeck.Count());

        card = curDeck[indexOfCard];
        Debug.Log(card);
        curDeck.RemoveAt(indexOfCard);

        return card;
    }

    public void updateCard(int card)
    {

        Renderer renderer = GetComponent<Renderer>();
        //Material myMaterial = renderer.material;
        if (renderer != null)
        {
            switch (card)
            {
                case 1:
                    renderer.material = materialsArray[0];
                    break;
                case 2:
                    renderer.material = materialsArray[1];
                    break;
                case 3:
                    renderer.material = materialsArray[2];
                    break;
                case 4:
                    renderer.material = materialsArray[3];
                    break;
                case 5:
                    renderer.material = materialsArray[4];
                    break;
                case 7:
                    renderer.material = materialsArray[5];
                    break;
                case 8:
                    renderer.material = materialsArray[6];
                    break;
                case 10:
                    renderer.material = materialsArray[7];
                    break;
                case 11:
                    renderer.material = materialsArray[8];
                    break;
                case 12:
                    renderer.material = materialsArray[9];
                    break;
                case SORRY:
                    renderer.material = materialsArray[10];
                    break;
            }            
        }
    }
}
