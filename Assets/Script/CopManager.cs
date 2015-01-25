using UnityEngine;
using System.Collections;

public class CopManager : MonoBehaviour {
	Animator[] listAnim = new Animator[10];

	void Start () {
		listAnim[0] = GameObject.Find("LeftAttente").GetComponent<Animator>();
		listAnim[1] = GameObject.Find("LeftAnim1").GetComponent<Animator>();
		listAnim[2] = GameObject.Find("LeftAnim2").GetComponent<Animator>();
		listAnim[3] = GameObject.Find("LeftAnim3").GetComponent<Animator>();
		listAnim[4] = GameObject.Find("LeftAnim4").GetComponent<Animator>();
		listAnim[5] = GameObject.Find("RightAttente").GetComponent<Animator>();
		listAnim[6] = GameObject.Find("RightAnim1").GetComponent<Animator>();
		listAnim[7] = GameObject.Find("RightAnim2").GetComponent<Animator>();
		listAnim[8] = GameObject.Find("RightAnim3").GetComponent<Animator>();
		listAnim[9] = GameObject.Find("RightAnim4").GetComponent<Animator>();
		display(0,0);
		display(1,0);
	}
	
	void clear(int p){
		for(int i=p*5;i<p*5+5;i++)
			if(listAnim[i]!=null)
				listAnim[i].gameObject.SetActive(false);
	}
	public void display(int p, int i){
		clear(p);
		if(listAnim[i+p*5]!=null){
			if(listAnim[i+p*5].gameObject.activeSelf) return; // Already playing
			listAnim[i+p*5].gameObject.SetActive(true);
			listAnim[i+p*5].Play(0,-1,0f);
		}
		if(i>0)
			StartCoroutine(displayCoroutine(p));
	}
	IEnumerator displayCoroutine(int p){
		yield return new WaitForSeconds(1f);
		display(p,0);
	}
}
