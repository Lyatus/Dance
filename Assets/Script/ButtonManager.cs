using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
	public GameObject buttonPrefab;
	
	IEnumerator Start(){
		while(true){
			if(Random.Range(0,2)==0)
				createButtonForPlayer1(randomButton());
			else createButtonForPlayer2(randomButton());
			yield return new WaitForSeconds(1.5f);
		}
	}
	public void createButton(Vector3 position, string buttonName, Vector3 speed){
		GameObject button = Instantiate(buttonPrefab) as GameObject;
		button.GetComponent<Button>().init(buttonName,speed);
		button.transform.parent = transform;
		button.transform.localPosition = position;
	}
	public void createButtonForPlayer1(string buttonName){
		createButton(new Vector3(-10,.5f,0),buttonName,new Vector3(1,0,0));
	}
	public void createButtonForPlayer2(string buttonName){
		createButton(new Vector3(10,-.5f,0),buttonName,new Vector3(-1,0,0));
	}
	public string randomButton(){
		return Random.Range(1,3)+"_"+Random.Range(1,10);
	}
	public void beat(float delay){
		
	}
}
