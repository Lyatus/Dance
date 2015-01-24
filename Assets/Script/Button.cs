using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour {
	public float disappearDelay;
	public Sprite poofSprite;
	public float failDistance;

	private string buttonName;
	private Vector3 speed = Vector3.zero;
	private ButtonZone buttonZone;
	private bool failed = false;
	
	void Start(){
		buttonZone = GameObject.Find("ButtonZone").GetComponent<ButtonZone>();
	}
	
	void Update(){
		if(!failed
		&& (speed.x<0 &&transform.position.x<-failDistance
	   	|| speed.x>0 && transform.position.x>failDistance))
			failure();
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
		buttonZone.success();
		StartCoroutine(successCoroutine());
	}
	IEnumerator successCoroutine(){
		GetComponent<AudioSource>().Play();
		for(int i=1;i<=4;i++){
			transform.localScale = new Vector3(1f+i*.1f,1f+i*.1f,1f);
			yield return 0;
		}
		Destroy(gameObject);
		yield break;
	}
	public void failure(){
		failed = true;
		buttonZone.failure();
		StartCoroutine(failureCoroutine());
	}
	IEnumerator failureCoroutine(){
		GetComponent<SpriteRenderer>().sprite = poofSprite;
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
	public int getPlayerId(){
		return (transform.localPosition.y>0)?0:1;
	}
}
