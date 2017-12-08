using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public bool objectiveMet = false;
    public GameObject portal;

    int SceneNo = 1;
	// Use this for initialization
	void Start () {
        //Basically make sure that there is only one Instance of SaveManager
        if (Instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        //Protects GameManager from Being Destroyed when changing Scene
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //For Scene Management 
        if (SceneManager.GetActiveScene().name == "Scene1"&&SceneNo!=1)
        {
            SceneNo = 1;
        }
        else if (SceneManager.GetActiveScene().name != "MainMenu" && SceneNo != 0)
        {
            SceneNo = 0;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Scene1");
        }
    }
    public void meetObjective()
    {
        objectiveMet = true;
        portal.SetActive(true);
    }
}
