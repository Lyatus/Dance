using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour {
	public Sprite[] buttonImages;

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
		spriteRenderer.sprite = buttonImages[(buttonName[0] - '1') * 9 + (buttonName[2] - '1')];
	}
	public string getButtonName(){
		return buttonName;
	}
	
}
