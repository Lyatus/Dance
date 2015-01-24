using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour {
	public float disappearDelay;
	public Sprite poofSprite;
	public Sprite failSprite;
	public float failDistance;

	private string buttonName;
	private Vector3 speed = Vector3.zero;
	
	void Update(){
		if(speed.x<0 &&transform.position.x<-failDistance
	   	|| speed.x>0 && transform.position.x>failDistance)
			disappear(failSprite);
	   	transform.position += speed * Time.deltaTime;
	}
	public void init(string buttonName, Vector3 speed){
		this.buttonName = buttonName;
		this.speed = speed;
		GetComponent<SpriteRenderer>().sprite = ButtonMap.spriteForButton(buttonName);
		unhighlight();
	}
	public string getButtonName(){
		return buttonName;
	}
	public void success(){
		disappear(poofSprite);
	}
	public void failure(){
		disappear(failSprite);
	}
	void disappear(Sprite sprite){
		StartCoroutine(disappearCoroutine(sprite));
	}
	IEnumerator disappearCoroutine(Sprite sprite){
		GetComponent<AudioSource>().Play();
		GetComponent<SpriteRenderer>().sprite = sprite;
		yield return new WaitForSeconds(disappearDelay);
		Destroy(gameObject);
		yield break;
	}
	public void highlight(){
		GetComponent<SpriteRenderer>().color = Color.white;
	}
	public void unhighlight(){
		GetComponent<SpriteRenderer>().color = Color.gray;
	}
}
