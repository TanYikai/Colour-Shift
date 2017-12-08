using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

	public string colour;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {
		
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
}
