using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartUI : MonoBehaviour {


    public void StartGame()
    {
        Debug.Log("Clicked start");
        SceneManager.LoadScene("Sorry_Board_1");

    }
	

}
