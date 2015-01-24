using UnityEngine;
using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;

public static class KeyboardLayout{
	const int QWERTY = 0;
	const int AZERTY = 1;
	const int QWERTZ = 2;
	const int DVORAK = 3;
	
	[DllImport("user32.dll")]
	private static extern long GetKeyboardLayoutName(
		System.Text.StringBuilder pwszKLID);
	static private int layout;
		
	static KeyboardLayout(){
		/*
		StringBuilder name = new StringBuilder(9);
		GetKeyboardLayoutName(name);
		String KeyBoardLayout = name.ToString();
		if (KeyBoardLayout == "00000407" || KeyBoardLayout == "00000807")
			layout = QWERTZ;
		else if (KeyBoardLayout == "0000040c" || KeyBoardLayout == "0000080c")
			layout = AZERTY;
		else if (KeyBoardLayout == "00010409")
			layout = DVORAK;
		else
			layout = QWERTY;
		*/
		
	}
	public static int getLayout(){
		return layout;
	}
	public static bool isQwerty(){
		return false;
	}
}
