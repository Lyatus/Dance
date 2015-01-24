using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour {
	public float poofDelay;

	private string buttonName;
	private Vector3 speed = Vector3.zero;
	
	void Update(){
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
	public void disappear(){
		StartCoroutine(disappearCoroutine());
	}
	IEnumerator disappearCoroutine(){
		GetComponent<AudioSource>().Play();
		GetComponent<SpriteRenderer>().sprite = ButtonMap.spriteForPoof();
		yield return new WaitForSeconds(poofDelay);
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
