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

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.Equals(player))
		{
			print("1");
			PlayerManager playerManager = player.GetComponent<PlayerManager>();
			if (playerManager.getPlayerColour().colourName().Equals(colour))
			{
				print("3");
				Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), other.GetComponent<Collider2D>());
			}
		}
	}
}
