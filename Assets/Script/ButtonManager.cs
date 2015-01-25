using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
	public GameObject buttonPrefab;
	public float easySpeed;
	public float mediumSpeed;
	public float hardSpeed;
	public float zoneDistance;
	public float correctMappingModifier;
	public float correctMappingProb;
	public float lineYOffset;
	private float speed;
	
	void Start(){
		StartCoroutine(correctMappingCoroutine());
		GameObject smgo = GameObject.Find("StartManager");
		if(smgo==null) return;
		StartManager sm = smgo.GetComponent<StartManager> ();
	
		switch (sm.getSelectedDifficulty()) {
			case 0 : speed = easySpeed; break;
			case 1 : speed = mediumSpeed; break;
			case 2 : speed = hardSpeed; break;
		}
	}
	IEnumerator correctMappingCoroutine(){
		while(true){
			correctMappingProb *= correctMappingModifier;
			yield return new WaitForSeconds(1f);
		}
	}
	public void createButton(Vector3 position, string buttonName, Vector3 speed){
		GameObject button = Instantiate(buttonPrefab) as GameObject;
		button.GetComponent<Button>().init(buttonName,speed);
		button.transform.parent = transform;
		button.transform.localPosition = position;
	}
	public void beat(float delay){
		Vector3 position = new Vector3(zoneDistance+delay*this.speed,-lineYOffset,0);
		Vector3 speed = new Vector3(-this.speed,0,0);
		string buttonName;
		
		if(Random.Range(0,2)==0){
			position = -position;
			speed = -speed;
			buttonName = "1_"+Random.Range(1,10);
		}
		else buttonName = "2_"+Random.Range(1,10);
		
		if(Random.Range(0f,1f)>correctMappingProb)
			buttonName = Random.Range(1,3)+"_"+Random.Range(1,10); // Use incorrect mapping because fuck them
		
		createButton(position,buttonName,speed);
	}
}
