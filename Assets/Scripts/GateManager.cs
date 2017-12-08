using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

	public string colour;
	public bool isColliderEnabled = true;
	public GameObject player = GameObject.Find("Player");
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other)
	{
		if (isColliderEnabled)
		{
			if (other.gameObject == player)
			{
				print("1");
				PlayerManager playerManager = player.GetComponent<PlayerManager>();
				if (playerManager.getPlayerColour().colourName().Equals(colour))
				{
					print("3");
					Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), other.GetComponent<Collider2D>());
				}
				else
				{
					print("4");
					isColliderEnabled = true;
				}
			}
		}
	}
}
