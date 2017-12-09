using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTriggerManager : MonoBehaviour {

	GameObject parentGate;
	public bool isLeftGate;
	// Use this for initialization
	void Start () {
		parentGate = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "PLAYER")
		{
			if (!parentGate.GetComponent<GateManager>().GetPlayer().GetComponent<PlayerManager>().getPlayerColour().colourName().Equals(parentGate.GetComponent<GateManager>().GetColour()))
			{
				print("2");
				if (isLeftGate)
				{
					parentGate.GetComponent<GateManager>().GetPlayer().transform.Translate(-0.1f, 0, 0);
				}
				else
				{
					parentGate.GetComponent<GateManager>().GetPlayer().transform.Translate(0.1f, 0, 0);
				}
				parentGate.gameObject.layer = 0;
				other.gameObject.layer = 0;
			}
		}
	}
}
