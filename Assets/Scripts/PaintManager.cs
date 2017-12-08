using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour {

	private Stack<ColourObject> paintStack = new Stack<ColourObject>();

	int MAX_STACK_CAPACITY = 5;
	int MIN_TO_MERGE = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	 * Adds a colour to the stack if it is not full, does nothing if it is
	 **/
	public void pushToStack(ColourObject colour)
	{
		if (paintStack.Count <= MAX_STACK_CAPACITY && paintStack.Count >= 0)
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
}
