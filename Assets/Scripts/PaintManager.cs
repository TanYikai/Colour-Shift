using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour {

	public static PaintManager instance;
	private Stack<ColourObject> paintStack = new Stack<ColourObject>();

	private List<GameObject> bars = new List<GameObject>();

	int MAX_STACK_CAPACITY = 5;
	int MIN_TO_MERGE = 2;

	// Use this for initialization
	void Start () {
		instance = this;

		//Sample
		paintStack.Push(new ColourObject(true, false, false));
		paintStack.Push(new ColourObject(false, false, true));
		paintStack.Push(new ColourObject(true, false, true));
		paintStack.Push(new ColourObject(false, true, false));
		paintStack.Push(new ColourObject(false, false, true));

		GameObject barZero = GameObject.Find("Stack 0");
		GameObject barOne = GameObject.Find("Stack 1");
		GameObject barTwo = GameObject.Find("Stack 2");
		GameObject barThree = GameObject.Find("Stack 3");
		GameObject barFour = GameObject.Find("Stack 4");

		bars.Add(barZero);
		bars.Add(barOne);
		bars.Add(barTwo);
		bars.Add(barThree);
		bars.Add(barFour);
	}

	// Update is called once per frame
	void Update () {
		int i = 0;
		if (Input.GetKeyDown(KeyCode.C)) {
			mergeStack();
		}
		ColourObject[] stackArray = paintArray();
		for (i = 0; i < stackArray.Length; i++)
		{
			setColour(bars[i], stackArray[stackArray.Length - 1 - i]);
		}
		for (int j = stackArray.Length; j < MAX_STACK_CAPACITY; j++)
		{
			setColour(bars[j], new ColourObject(false, false, false));
		}
	}

	/**
	 * Adds a colour to the stack if it is not full, does nothing if it is
	 **/
	public void pushToStack(ColourObject colour)
	{
		print(paintStack.Count);
		if (paintStack.Count < MAX_STACK_CAPACITY && paintStack.Count >= 0)
		{
			paintStack.Push(colour);
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
		return paintStack.Pop();
	}

	//Merges the top 2 colours in the stack
	public void mergeStack()
	{
		//Cannot merge less than 2 colours
		if (paintStack.Count >= MIN_TO_MERGE && paintStack.Count <= MAX_STACK_CAPACITY) {
			ColourObject firstColor = paintStack.Pop();
			ColourObject secondColor = paintStack.Pop();

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
			}
			else if (colourNames.Contains(ColourObject.BLUE_NAME)) {
				if (colourNames.Contains(ColourObject.YELLOW_NAME))
				{
					//Green
					newColour = new ColourObject(false, true, true);
					canMerge = true;
				}
			}
			else if (colourNames.Contains(ColourObject.ORANGE_NAME)) {
				if (colourNames.Contains(ColourObject.PURPLE_NAME) || colourNames.Contains(ColourObject.GREEN_NAME) || colourNames.Contains(ColourObject.BLUE_NAME))
				{
					//White
					newColour = new ColourObject(true, true, true);
					canMerge = true;
				}
			}
			else if (colourNames.Contains(ColourObject.PURPLE_NAME))
			{
				if (colourNames.Contains(ColourObject.GREEN_NAME) || colourNames.Contains(ColourObject.YELLOW_NAME))
				{
					//White
					newColour = new ColourObject(true, true, true);
					canMerge = true;
				}
			}
			else if (colourNames.Contains(ColourObject.GREEN_NAME))
			{
				if (colourNames.Contains(ColourObject.RED_NAME))
				{
					//White
					newColour = new ColourObject(true, true, true);
					canMerge = true;
				}
			}
			
			if (canMerge) {
				//If can merge, push the merged colour in
				paintStack.Push(newColour);
			}
			else {
				// If cannot merge, just push back the original two colours
				paintStack.Push(secondColor);
				paintStack.Push(firstColor);
			}
		}
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
