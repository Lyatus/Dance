using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SuicideManager : MonoBehaviour {

	private GameObject[] listSuicide = new GameObject[7];

	private int etatSuicide = 0;

	// Use this for initialization
	void Start () {
		listSuicide[0] = GameObject.Find("imgSuicideMinus3");
		listSuicide[1] = GameObject.Find("imgSuicideMinus2");
		listSuicide[2] = GameObject.Find("imgSuicideMinus1");
		listSuicide[3] = GameObject.Find("imgSuicideIdle");
		listSuicide[4] = GameObject.Find("imgSuicidePlus1");
		listSuicide[5] = GameObject.Find("imgSuicidePlus2");
		listSuicide[6] = GameObject.Find("imgSuicidePlus3");
		displaySuicideStats ();
	}

	public void lostLife(){
		if (etatSuicide > -3)
						etatSuicide--;
				else
						Application.LoadLevel ("overGameLost");

		displaySuicideStats ();
	}

	public void winLife(){
		if (etatSuicide < 3)
			etatSuicide++;

		displaySuicideStats ();
	}

	void displaySuicideStats(){
		foreach(GameObject go in listSuicide)
			go.SetActive(false);
		if(etatSuicide>=-3 && etatSuicide<=3)
			listSuicide[3+etatSuicide].SetActive(true);
	}
}
