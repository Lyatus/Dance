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
	[DllImport("user32.dll")]
	private static extern int GetKeyNameText(int lParam, StringBuilder lpString, int cchSize);
	static private int layout;
		
	static KeyboardLayout(){
		StringBuilder buffer = new StringBuilder(64);
		int scanCode = 0x10;
		int lParam = scanCode << 16;
		GetKeyNameText(lParam, buffer, buffer.Capacity);
		if(buffer.ToString()=="A")
			layout = AZERTY;
		else
			layout = QWERTY;
	}
	public static int getLayout(){
		return layout;
	}
	public static bool isQwerty(){
		return layout==QWERTY;
	}
	public static bool isAzerty(){
		return layout==AZERTY;
	}
}
