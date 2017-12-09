using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PLAYER")
        {
			if (SceneManager.GetActiveScene().name == "Scene1temp")
			{
				SceneManager.LoadScene("Scene2");
			}
			else if (SceneManager.GetActiveScene().name == "Scene2")
			{
				SceneManager.LoadScene("MainMenu");
			}
		}
    }
}
