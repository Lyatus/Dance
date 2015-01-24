using UnityEngine;
using System.Collections;

public class UImanager : MonoBehaviour {

	private bool isPause;
	private Canvas CvsPause;

	void Start(){
		isPause = false;
		CvsPause = GameObject.Find ("CvsPause").GetComponent<Canvas>();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//mettre en pause
			isPause = !isPause;
		}

		if(isPause){
			Time.timeScale = 0;
			CvsPause.enabled = true;

		}else{
			Time.timeScale = 1;
			CvsPause.enabled = false;
			
		}
	}

	public void exitApplication() {
		Application.Quit ();
	}
}
