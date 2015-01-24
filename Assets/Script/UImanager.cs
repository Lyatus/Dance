using UnityEngine;
using System.Collections;

public class UImanager : MonoBehaviour {

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//mettre en pause
			Debug.Log("pause");
				}
			

	}

	public void exitApplication() {
		Application.Quit ();
	}
}
