﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class ButtonZone : MonoBehaviour {
	private Dictionary<string,HashSet<Button>> currentButtons = new Dictionary<string,HashSet<Button>>();
	
	void Update () {
		if(Time.timeScale>0f)
			for(int i=1;i<=2;i++)
				for(int j=1;j<=9;j++)
					if(Input.GetKeyDown(ButtonMap.keyForButton(i+"_"+j))){
						HashSet<Button> buttons = getCurrentButtons(i+"_"+j);
						if(buttons!=null && buttons.Count>0){
							foreach(Button button in buttons)
								button.success();
							buttons.Clear();
						}
						else GetComponent<AudioSource>().Play();
					}
					
	}
	void OnTriggerEnter2D(Collider2D c){
		Button button = c.gameObject.GetComponent<Button>();
		if(button != null){ // A button is entering the button zone
			button.highlight();
			getCurrentButtons(button.getButtonName()).Add(button);
		}
	}
	void OnTriggerExit2D(Collider2D c){
		Button button = c.gameObject.GetComponent<Button>();
		if(button != null){ // A button is exiting the button zone
			button.unhighlight();
			getCurrentButtons(button.getButtonName()).Clear();
		}
	}
	HashSet<Button> getCurrentButtons(string name){
		HashSet<Button> buttons;
		if(currentButtons.TryGetValue(name,out buttons))
			return buttons;
		else buttons = new HashSet<Button>();
		currentButtons.Add(name,buttons);
		return buttons;
	}
}
