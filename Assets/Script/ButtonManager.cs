using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
	public GameObject buttonPrefab;
	public float speed;
	public float zoneDistance;
	
	IEnumerator Start(){
		yield return new WaitForSeconds(10f);
		Time.timeScale = 0;
	}
	public void createButton(Vector3 position, string buttonName, Vector3 speed){
		GameObject button = Instantiate(buttonPrefab) as GameObject;
		button.GetComponent<Button>().init(buttonName,speed);
		button.transform.parent = transform;
		button.transform.localPosition = position;
	}
	public void createButtonForPlayer1(string buttonName, float delay){
		createButton(new Vector3(-(zoneDistance+delay*speed),.5f,0),buttonName,new Vector3(speed,0,0));
	}
	public void createButtonForPlayer2(string buttonName, float delay){
		createButton(new Vector3(zoneDistance+delay*speed,-.5f,0),buttonName,new Vector3(-speed,0,0));
	}
	public string randomButton(){
		return Random.Range(1,3)+"_"+Random.Range(1,10);
	}
	public void beat(float delay){
		string buttonName = randomButton();
		if(Random.Range(0,2)==0)
			createButtonForPlayer1(buttonName,delay);
		else createButtonForPlayer2(buttonName,delay);
	}
}
