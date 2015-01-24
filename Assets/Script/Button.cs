using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour {
	private string buttonName;
	private Vector3 speed = Vector3.zero;
	
	private SpriteRenderer spriteRenderer;
	
	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer>();
		init("1_1", new Vector3(-1,0,0));
	}
	void Update(){
		transform.position += speed * Time.deltaTime;
	}
	public void init(string buttonName, Vector3 speed){
		this.buttonName = buttonName;
		this.speed = speed;
		spriteRenderer.sprite = ButtonMap.spriteForButton(buttonName);
	}
	public string getButtonName(){
		return buttonName;
	}
	public void disappear(){
		StartCoroutine(disappearCoroutine());
	}
	IEnumerator disappearCoroutine(){
		spriteRenderer.sprite = ButtonMap.spriteForPoof();
		yield return new WaitForSeconds(.1f);
		Destroy(gameObject);
		yield break;
	}
}
