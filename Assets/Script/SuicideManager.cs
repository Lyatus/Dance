using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SuicideManager : MonoBehaviour {

	private Image[] listSuicide;

	private int etatSuicide = 0;

	// Use this for initialization
	void Start () {
		listSuicide = this.GetComponentsInChildren<Image> ();
		displaySuicideStats ();
	}

	public void lostLife(){
		if (etatSuicide > -3)
			etatSuicide--;
		else
			Debug.Log ("mort");

		displaySuicideStats ();
	}

	public void winLife(){
		if (etatSuicide < 3)
			etatSuicide++;

		displaySuicideStats ();
	}

	void displaySuicideStats(){

		for (int i=0; i<listSuicide.Length; i++) {
			listSuicide[i].enabled = false;
				}

		switch (etatSuicide) {
		case -3 : searchSuicide("imgSuicideMinus3").enabled = true;
			break;
		case -2 : searchSuicide("imgSuicideMinus2").enabled = true;
			break;
		case -1 : searchSuicide("imgSuicideMinus1").enabled = true;
			break;
		case 0 : searchSuicide("imgSuicideIdle").enabled = true;
			break; 
		case 1 : searchSuicide("imgSuicidePlus1").enabled = true;
			break;
		case 2 : searchSuicide("imgSuicidePlus2").enabled = true;
			break;
		case 3 : searchSuicide("imgSuicidePlus3").enabled = true;
			break;
		}
	}

	Image searchSuicide(string name){
		for (int i=0; i<listSuicide.Length; i++) {
			if(name == listSuicide[i].name)
				return listSuicide[i];
				}
		return null;
	}
}
