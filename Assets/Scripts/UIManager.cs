using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private int livesLeft;
    private Image[] hearts;
    public Sprite brokenHeart;
    public Sprite fullHeart;

    public static UIManager instance;

	// Use this for initialization
	void Start () {
        livesLeft = 3;
        hearts = this.GetComponentsInChildren<Image>();
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
        {
            livesLeft--;
            hearts[livesLeft].sprite = brokenHeart;
        }
    }
}
