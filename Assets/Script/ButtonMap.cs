using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ButtonMap : MonoBehaviour{		
	static private SortedDictionary<string,string> buttonKeys;
	static private SortedDictionary<string,Sprite> buttonSprites;
	public Sprite aSprite;
	public Sprite bSprite;
	public Sprite cSprite;
	public Sprite dSprite;
	public Sprite eSprite;
	public Sprite fSprite;
	public Sprite gSprite;
	public Sprite hSprite;
	public Sprite nSprite;
	public Sprite qSprite;
	public Sprite rSprite;
	public Sprite sSprite;
	public Sprite tSprite;
	public Sprite vSprite;
	public Sprite wSprite;
	public Sprite xSprite;
	public Sprite ySprite;
	public Sprite zSprite;
	
	void Start(){
		bool qwerty = KeyboardLayout.isQwerty();
		if(buttonKeys!=null)
			return;
	
		buttonKeys = new SortedDictionary<string, string>();
		buttonSprites = new SortedDictionary<string, Sprite>();

		buttonKeys.Add("1_1",(qwerty)?"z":"w");
		buttonKeys.Add("1_2","x");
		buttonKeys.Add("1_3","c");
		buttonKeys.Add("1_4",(qwerty)?"a":"q");
		buttonKeys.Add("1_5","s");
		buttonKeys.Add("1_6","d");
		buttonKeys.Add("1_7",(qwerty)?"q":"a");
		buttonKeys.Add("1_8",(qwerty)?"w":"z");
		buttonKeys.Add("1_9","e");
		buttonKeys.Add("2_1","v");
		buttonKeys.Add("2_2","b");
		buttonKeys.Add("2_3","n");
		buttonKeys.Add("2_4","f");
		buttonKeys.Add("2_5","g");
		buttonKeys.Add("2_6","h");
		buttonKeys.Add("2_7","r");
		buttonKeys.Add("2_8","t");
		buttonKeys.Add("2_9","y");
		
		buttonSprites.Add("1_1",(qwerty)?zSprite:wSprite);
		buttonSprites.Add("1_2",xSprite);
		buttonSprites.Add("1_3",cSprite);
		buttonSprites.Add("1_4",(qwerty)?aSprite:qSprite);
		buttonSprites.Add("1_5",sSprite);
		buttonSprites.Add("1_6",dSprite);
		buttonSprites.Add("1_7",(qwerty)?qSprite:aSprite);
		buttonSprites.Add("1_8",(qwerty)?wSprite:zSprite);
		buttonSprites.Add("1_9",eSprite);
		buttonSprites.Add("2_1",vSprite);
		buttonSprites.Add("2_2",bSprite);
		buttonSprites.Add("2_3",nSprite);
		buttonSprites.Add("2_4",fSprite);
		buttonSprites.Add("2_5",gSprite);
		buttonSprites.Add("2_6",hSprite);
		buttonSprites.Add("2_7",rSprite);
		buttonSprites.Add("2_8",tSprite);
		buttonSprites.Add("2_9",ySprite);		
	}
	public static string keyForButton(string button){
		string wtr;
		if(buttonKeys.TryGetValue(button,out wtr))
			return wtr;
		else throw new Exception("That button doesn't exit");
	}
	public static Sprite spriteForButton(string button){
		Sprite wtr;
		if(buttonSprites.TryGetValue(button,out wtr))
			return wtr;
		else throw new Exception("That button doesn't exit");
	}
}
