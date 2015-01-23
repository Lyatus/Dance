using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class ButtonMap {
	static private SortedDictionary<string,string> buttonKeys = new SortedDictionary<string, string>();
	static ButtonMap(){
		buttonKeys.Add("1_1","w");
		buttonKeys.Add("1_2","x");
		buttonKeys.Add("1_3","c");
		buttonKeys.Add("1_4","q");
		buttonKeys.Add("1_5","s");
		buttonKeys.Add("1_6","d");
		buttonKeys.Add("1_7","a");
		buttonKeys.Add("1_8","z");
		buttonKeys.Add("1_9","e");
		buttonKeys.Add("2_1","v");
		buttonKeys.Add("2_2","b");
		buttonKeys.Add("2_3","n");
		buttonKeys.Add("2_4","f");
		buttonKeys.Add("2_5","g");
		buttonKeys.Add("2_6","h");
		buttonKeys.Add("2_7","r");
		buttonKeys.Add("2_8","t");
		buttonKeys.Add("2_9","y");
	}
	static string keyForButton(string button){
		string wtr;
		if(buttonKeys.TryGetValue(button,out wtr))
			return wtr;
		else throw new Exception("That button doesn't exit");
	}
}
