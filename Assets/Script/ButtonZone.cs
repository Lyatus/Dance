using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class ButtonZone : MonoBehaviour {
	private Dictionary<string,Button> currentButtons = new Dictionary<string,Button>();
	
	void Update () {
		for(int i=1;i<=2;i++)
			for(int j=1;j<=9;j++)
				if(Input.GetKeyDown(ButtonMap.keyForButton(i+"_"+j))){
					Button button;
					if(currentButtons.TryGetValue(i+"_"+j,out button)){
						currentButtons.Remove(i+"_"+j);
						button.disappear();
					}
					else Debug.Log("NO");
				}
					
	}
	void OnTriggerEnter2D(Collider2D c){
		Button button = c.gameObject.GetComponent<Button>();
		if(button != null) // A button is entering the button zone
			currentButtons.Add(button.getButtonName(),button);
	}
	void OnTriggerExit2D(Collider2D c){
		if(c.gameObject.GetComponent<Button>() != null) // A button is exiting the button zone
			currentButtons.Remove(c.gameObject.GetComponent<Button>().getButtonName());
	}
}
