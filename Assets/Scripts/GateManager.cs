using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

	public static GateManager instance;
	public string colour;
	public GameObject player;
	private GameObject trigger;
	

	// Use this for initialization
	void Start () {
		instance = this;
		player = GameObject.Find("Player");
		trigger = transform.Find("GateTrigger").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
		{
			colour = "Blue";
		}
		setColour(colour);
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "PLAYER")
		{
			print(player.GetComponent<PlayerManager>().getPlayerColour().colourName());
			print(colour);
			if (player.GetComponent<PlayerManager>().getPlayerColour().colourName().Equals(colour))
			{
				print("5");
				other.gameObject.layer = 8;
				this.gameObject.layer = 9;
				Physics2D.IgnoreLayerCollision(8, 9);
			}
			else
			{
				print("3");
				other.gameObject.layer = 0;
				this.gameObject.layer = 0;
			}
		}
	}

	private void setColour(string colour)
	{
		if (colour == ColourObject.RED_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.red;
			trigger.gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
		else if (colour == ColourObject.BLUE_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
			trigger.gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
		else if (colour == ColourObject.GREEN_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.green;
			trigger.gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else if (colour == ColourObject.PURPLE_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 1);
			trigger.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 1);
		}
		else if (colour == ColourObject.ORANGE_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = new Color(1, (float)0.5, 0, 1);
			trigger.gameObject.GetComponent<Renderer>().material.color = new Color(1, (float)0.5, 0, 1);
		}
		else if (colour == ColourObject.YELLOW_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
			trigger.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
		}
		else if (colour == ColourObject.WHITE_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.white;
			trigger.gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
		else if (colour == ColourObject.BLACK_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.black;
			trigger.gameObject.GetComponent<Renderer>().material.color = Color.black;
		}
	}
	
	public string GetColour()
	{
		return colour;
	}

	public GameObject GetPlayer()
	{
		return player;
	}
}
