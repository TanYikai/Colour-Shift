using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour {
    public int size;
	public static PaintManager instance;
    public List<Sprite> listOfSprites = new List<Sprite>();
    public List<GameObject> listOfBlocks = new List<GameObject>();

	private Stack<ColourObject> paintStack = new Stack<ColourObject>();

	private List<GameObject> bars = new List<GameObject>();

	int MAX_STACK_CAPACITY = 5;
	int MIN_TO_MERGE = 2;

	// Use this for initialization
	void Start () {
		instance = this;

        //Sample
        pushColor(new ColourObject(true, false, false));
        pushColor(new ColourObject(false, false, true));
        pushColor(new ColourObject(true, false, true));
        pushColor(new ColourObject(false, true, false));
        pushColor(new ColourObject(false, false, true));

		//GameObject barZero = GameObject.Find("Stack 0");
		//GameObject barOne = GameObject.Find("Stack 1");
		//GameObject barTwo = GameObject.Find("Stack 2");
		//GameObject barThree = GameObject.Find("Stack 3");
		//GameObject barFour = GameObject.Find("Stack 4");

		//bars.Add(barZero);
		//bars.Add(barOne);
		//bars.Add(barTwo);
		//bars.Add(barThree);
		//bars.Add(barFour);
	}

	// Update is called once per frame
	void Update () {
        size = paintStack.Count;
		int i = 0;
		if (Input.GetKeyDown(KeyCode.C)) {
			mergeStack();
		}
		//ColourObject[] stackArray = paintArray();
		//for (i = 0; i < stackArray.Length; i++)
		//{
  //          setColour(bars[i], stackArray[stackArray.Length - 1 - i]);
  //      }
		//for (int j = stackArray.Length; j < MAX_STACK_CAPACITY; j++)
		//{
  //          setColour(bars[j], new ColourObject(false, false, false));
  //      }
	}

	/**
	 * Adds a colour to the stack if it is not full, does nothing if it is
	 **/
	public void pushToStack(ColourObject colourObject)
	{
		if (paintStack.Count < MAX_STACK_CAPACITY && paintStack.Count >= 0)
		{
            pushColor(colourObject);

		}
		else
		{
			throw new System.Exception("Stack Size is invalid. Stack Size: " + paintStack.Count);
		}
	}

	/**
	 * Pops a ColourObject from the stack if it is not empty
	 **/
	public ColourObject popFromStack()
	{
        listOfBlocks[paintStack.Count-1].SetActive(false);
        return paintStack.Pop();
	}

	//Merges the top 2 colours in the stack
	public void mergeStack()
	{
		//Cannot merge less than 2 colours
		if (paintStack.Count >= MIN_TO_MERGE && paintStack.Count <= MAX_STACK_CAPACITY) {
			ColourObject firstColor = popFromStack();
			ColourObject secondColor = popFromStack();

			List<string> colourNames = new List<string>();
			colourNames.Add(firstColor.colourName());
			colourNames.Add(secondColor.colourName());

			//To keep track if merging is possible
			Boolean canMerge = false;
			ColourObject newColour = new ColourObject(false, false, false);

			if (colourNames.Contains(ColourObject.RED_NAME)) {
				if (colourNames.Contains(ColourObject.BLUE_NAME))
				{
					//Purple
					newColour = new ColourObject(true, true, false);
					canMerge = true;
				}
				else if (colourNames.Contains(ColourObject.YELLOW_NAME))
				{
					//Orange
					newColour = new ColourObject(true, false, true);
					canMerge = true;
				}
				else if (colourNames.Contains(ColourObject.GREEN_NAME))
				{
					//White
					newColour = new ColourObject(true, true, true);
					canMerge = true;
				}
			}
			else if (colourNames.Contains(ColourObject.BLUE_NAME)) {
				if (colourNames.Contains(ColourObject.YELLOW_NAME))
				{
					//Green
					newColour = new ColourObject(false, true, true);
					canMerge = true;
				}
				else if (colourNames.Contains(ColourObject.ORANGE_NAME))
				{
					//White
					newColour = new ColourObject(true, true, true);
					canMerge = true;
				}
			}
			else if (colourNames.Contains(ColourObject.YELLOW_NAME))
			{
				if (colourNames.Contains(ColourObject.PURPLE_NAME))
				{
					//White
					newColour = new ColourObject(true, true, true);
					canMerge = true;
				}
			}
			else if (colourNames.Contains(ColourObject.ORANGE_NAME)) {
				if (colourNames.Contains(ColourObject.PURPLE_NAME) || colourNames.Contains(ColourObject.GREEN_NAME))
				{
					//White
					newColour = new ColourObject(true, true, true);
					canMerge = true;
				}
			}
			else if (colourNames.Contains(ColourObject.PURPLE_NAME))
			{
				if (colourNames.Contains(ColourObject.GREEN_NAME))
				{
					//White
					newColour = new ColourObject(true, true, true);
					canMerge = true;
				}
			}
            if (canMerge) {
                //If can merge, push the merged colour in
                pushColor(newColour);
               
            }
			else {
                // If cannot merge, just push back the original two colours
                pushColor(secondColor);
                pushColor(firstColor);
			}
		}
	}
    void pushColor(ColourObject newColour)
    {
        GameObject gobject = listOfBlocks[paintStack.Count];

        if(gobject.activeSelf == false)
        {
            gobject.SetActive(true);
        }

        if (newColour.colourName() == ColourObject.RED_NAME)
        {
            gobject.GetComponent<UnityEngine.UI.Image>().overrideSprite = listOfSprites[0];
        }
        else if (newColour.colourName() == ColourObject.BLUE_NAME)
        {
            gobject.GetComponent<UnityEngine.UI.Image>().overrideSprite = listOfSprites[2];
        }
        else if (newColour.colourName() == ColourObject.GREEN_NAME)
        {
            gobject.GetComponent<UnityEngine.UI.Image>().overrideSprite = listOfSprites[5];
        }
        else if (newColour.colourName() == ColourObject.PURPLE_NAME)
        {
            gobject.GetComponent<UnityEngine.UI.Image>().overrideSprite = listOfSprites[3];
        }
        else if (newColour.colourName() == ColourObject.ORANGE_NAME)
        {
            gobject.GetComponent<UnityEngine.UI.Image>().overrideSprite = listOfSprites[4];
        }
        else if (newColour.colourName() == ColourObject.YELLOW_NAME)
        {
            gobject.GetComponent<UnityEngine.UI.Image>().overrideSprite = listOfSprites[1];
        }
        else if (newColour.colourName() == ColourObject.WHITE_NAME)
        {
            gobject.GetComponent<UnityEngine.UI.Image>().overrideSprite = listOfSprites[6];
        }
        paintStack.Push(newColour);
    }

	//Provides an array representation of the stack
	public ColourObject[] paintArray()
	{
		return paintStack.ToArray();
	}

	private void setColour(GameObject gameObject, ColourObject colourObject)
	{
		if (colourObject.colourName() == ColourObject.RED_NAME)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
		else if (colourObject.colourName() == ColourObject.BLUE_NAME)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
		else if (colourObject.colourName() == ColourObject.GREEN_NAME)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else if (colourObject.colourName() == ColourObject.PURPLE_NAME)
		{
			gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 1);
		}
		else if (colourObject.colourName() == ColourObject.ORANGE_NAME)
		{
			gameObject.GetComponent<Renderer>().material.color = new Color(1, (float)0.5, 0, 1);
		}
		else if (colourObject.colourName() == ColourObject.YELLOW_NAME)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.yellow;
		}
		else if (colourObject.colourName() == ColourObject.WHITE_NAME)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.white;
		}
		else if (colourObject.colourName() == ColourObject.BLACK_NAME)
		{
			gameObject.GetComponent<Renderer>().material.color = Color.black;
		}
	}

	public int getStackSize()
	{
		return paintStack.Count;
	}
}
