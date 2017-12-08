using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourObject {

	public Boolean isRed;
	public Boolean isBlue;
	public Boolean isYellow;

	public static string RED_NAME = "Red";
	public static string BLUE_NAME = "Blue";
	public static string YELLOW_NAME = "Yellow";
	public static string ORANGE_NAME = "Orange";
	public static string PURPLE_NAME = "Purple";
	public static string GREEN_NAME = "Green";
	public static string WHITE_NAME = "White";
	public static string BLACK_NAME = "Black";

	public ColourObject(Boolean r, Boolean b, Boolean y) {
		isRed = r;
		isBlue = b;
		isYellow = y;
	}

	public Boolean getIsRed()
	{
		return isRed;
	}

	public Boolean getIsBlue()
	{
		return isBlue;
	}

	public Boolean getIsYellow()
	{
		return isYellow;
	}

	public void setRed(Boolean r)
	{
		isRed = r;
	}

	public void setBlue(Boolean b)
	{
		isBlue = b;
	}

	public void setYellow(Boolean y)
	{
		isYellow = y;
	}

	public String colourName() {
		if (isRed)
		{
			if (isBlue)
			{
				if (isYellow)
				{
					return WHITE_NAME;
				}
				else
				{
					return PURPLE_NAME;
				}
			}
			else
			{
				if (isYellow)
				{
					return ORANGE_NAME;
				}
				else
				{
					return RED_NAME;
				}
			}
		}
		else
		{
			if (isBlue)
			{
				if (isYellow)
				{
					return GREEN_NAME;
				}
				else
				{
					return BLUE_NAME;
				}
			}
			else
			{
				if (isYellow)
				{
					return YELLOW_NAME;
				}
				else
				{
					return BLACK_NAME;
				}
			}
		}
	}

	Boolean canMerge(ColourObject other)
	{
		return this.isRed != other.getIsRed() || this.isBlue != other.getIsBlue() || this.isYellow != other.getIsYellow();
	}
}
