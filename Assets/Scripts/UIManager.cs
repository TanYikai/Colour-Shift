using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private int livesLeft = 3;
    private SpriteRenderer[] hearts;
    public Sprite brokenHeart;
    public Sprite fullHeart;

    private static UIManager instance;

	// Use this for initialization
	void Start () {
        hearts = this.GetComponentsInChildren<SpriteRenderer>();
        instance = this;
	}

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void breakHeart() 
    {
        if (livesLeft != 0)
            hearts[--livesLeft].sprite = brokenHeart;
    }
}
