using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

	public static GateManager instance;
	public string colour;
	public GameObject player;

	// Use this for initialization
	void Start () {
		instance = this;
		player = GameObject.Find("Player");
		
	}

	// Update is called once per frame
	void Update () {
		setColour(colour);
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "PLAYER")
		{
			if (player.GetComponent<PlayerManager>().getPlayerColour().colourName().Equals(colour))
			{
				Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
			}
		}
	}

	private void setColour(string colour)
	{
		if (colour == ColourObject.RED_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
		else if (colour == ColourObject.BLUE_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
		else if (colour == ColourObject.GREEN_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else if (colour == ColourObject.PURPLE_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 1);
		}
		else if (colour == ColourObject.ORANGE_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = new Color(1, (float)0.5, 0, 1);
		}
		else if (colour == ColourObject.YELLOW_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
		}
		else if (colour == ColourObject.WHITE_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
		else if (colour == ColourObject.BLACK_NAME)
		{
			this.gameObject.GetComponent<Renderer>().material.color = Color.black;
		}
	}
}
