using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class ButtonZone : MonoBehaviour {
	private Dictionary<string,GameObject> currentButtons = new Dictionary<string,GameObject>();
	
	void Update () {
		for(int i=1;i<=2;i++)
			for(int j=1;j<=9;j++)
				if(Input.GetKeyDown(ButtonMap.keyForButton(i+"_"+j))){
					GameObject button;
					if(currentButtons.TryGetValue(i+"_"+j,out button)){
						Destroy(button);
						Debug.Log("YES");
					}
					else Debug.Log("NO");
				}
					
	}
	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.GetComponent<Button>() != null) // A button is entering the button zone
			currentButtons.Add(c.gameObject.GetComponent<Button>().getButtonName(),c.gameObject);
	}
	void OnTriggerExit2D(Collider2D c){
		if(c.gameObject.GetComponent<Button>() != null) // A button is exiting the button zone
			currentButtons.Remove(c.gameObject.GetComponent<Button>().getButtonName());
	}
}
