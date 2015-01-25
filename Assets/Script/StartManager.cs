using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class StartManager : MonoBehaviour {

	//faire la liste des musiques dans le répertoire musique, remplir une liste et modifier la musique lu
	public string path = "Assets/Music";

	public Sprite tutoJ1Azerty, tutoJ2Azerty;

	public AudioClip[] listMusics;
	private AudioClip selectedMusic;
	private int selectedIndexMusic;
	private int selectedDifficulty;

	private Text displaySelectedMusic;
	private Text displaySelectedDifficulty;

	void Awake () {
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		selectedDifficulty = 1;
		selectedIndexMusic = 0;

		displaySelectedMusic = GameObject.Find("TextMusic").GetComponentInChildren<Text>();
		displaySelectedDifficulty = GameObject.Find("TextDifficulty").GetComponentInChildren<Text>();

		Debug.Log (displaySelectedMusic.text);

		displayDifficulty ();
		displayMusic ();

		if(KeyboardLayout.isAzerty()){
			GameObject.Find("TutoJ1").GetComponent<Image>().sprite = tutoJ1Azerty;
			GameObject.Find("TutoJ2").GetComponent<Image>().sprite = tutoJ2Azerty;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void upDifficulty(){
		if (selectedDifficulty < 2)
			selectedDifficulty++;
		else
			selectedDifficulty = 0;

		displayDifficulty ();
	}

	public void downDifficulty(){
		if (selectedDifficulty > 0)
			selectedDifficulty--;
		else
			selectedDifficulty = 2;

		displayDifficulty ();
	}

	public void upMusic(){
		if (selectedIndexMusic < listMusics.Length-1)
			selectedIndexMusic++;
		else
			selectedIndexMusic = 0;
		
		displayMusic ();
	}
	
	public void downMusic(){
		if (selectedIndexMusic > 0)
			selectedIndexMusic--;
		else
			selectedIndexMusic = listMusics.Length-1;
		
		displayMusic ();
	}

	void displayDifficulty(){
		switch (selectedDifficulty) {
		case 0 : displaySelectedDifficulty.text = "Easy";
			break;
		case 1 : displaySelectedDifficulty.text = "Medium";
			break;
		case 2 : displaySelectedDifficulty.text = "Hard";
			break;
				}
	}

	void displayMusic(){
		selectedMusic = listMusics [selectedIndexMusic];
		displaySelectedMusic.text = selectedMusic.name;
		//Debug.Log (selectedMusic.name);
	}


	public void play(){
		Application.LoadLevel(2);
	}

	public AudioClip getSelectedMusic(){
		return selectedMusic;
	}

	public int getSelectedDifficulty(){
		return selectedDifficulty;
	}
}
