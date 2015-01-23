using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
	public GameObject buttonPrefab;
	
	public void createButton(Vector3 position, string buttonName, Vector3 speed){
		GameObject button = Instantiate(buttonPrefab,position,Quaternion.identity) as GameObject;
		button.GetComponent<Button>().init(buttonName,speed);
		button.transform.parent = transform.parent;
	}
}
