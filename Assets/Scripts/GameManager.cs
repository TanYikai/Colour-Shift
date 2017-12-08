using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public bool objectiveMet = false;
    public GameObject portal;
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
        
	}
    public void meetObjective()
    {
        objectiveMet = true;
        portal.SetActive(true);
    }
}
