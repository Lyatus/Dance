using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BeatFinder : MonoBehaviour {

	public ButtonManager bm;
	public int qSamples = 2096;
	public float bias = 0.02f; //mini Amplitude to extract pitch
	public float delay = 0f;

	private Slider progress;

	public float easyMode = 1f;
	public float mediumMode = 0.8f;
	public float hardMode = 0.5f;
	private float timeBetweenKey;
	public float threshold = 1.7f;
	public int savedFrames = 60; 

	private float[] samplesL, samplesR;
	private Queue<float> previousEnergies = new Queue<float>();
	private float timeBeforeKey;

	private float startTime;
	private float endTime;

	private AudioSource musicBeater;
	private AudioSource musicReader;
	private AudioLowPassFilter filter;

	// Use this for initialization
	void Start () {

		musicBeater = GetComponent<AudioSource> ();
		GameObject smgo = GameObject.Find ("StartManager");
		if (smgo == null) {
			Application.LoadLevel(0);
		}
		StartManager sm = smgo.GetComponent<StartManager> ();

		musicBeater.clip = sm.getSelectedMusic ();

		switch (sm.getSelectedDifficulty()) {
		case 0 : timeBetweenKey = easyMode;
			break;
		case 1 : timeBetweenKey = mediumMode;
			break;
		case 2 : timeBetweenKey = hardMode;
			break;
		}

		Debug.Log (timeBetweenKey + " " + musicBeater.clip.name);

		musicReader = gameObject.AddComponent<AudioSource> ();
		musicReader.clip = musicBeater.clip;
		musicReader.PlayDelayed(delay);
		musicBeater.volume = 0;

		samplesL = new float[qSamples];
		samplesR = new float[qSamples];

		timeBeforeKey = Time.time + timeBetweenKey;

		startTime = Time.time;
		endTime = Time.time + musicReader.clip.length;

		progress = GameObject.Find ("CnvProgress").GetComponentInChildren<Slider> ();
		progress.value = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 0 && musicBeater.isPlaying) {
				musicBeater.Pause ();
				musicReader.Pause ();
		} else if (Time.timeScale > 0 && !musicBeater.isPlaying) {
				musicBeater.Play ();
				musicReader.Play ();
		}

		if (endTime < Time.time) {
			Application.LoadLevel("overGameWin");
		}

		musicBeater.GetSpectrumData (samplesL, 0, FFTWindow.BlackmanHarris);
		musicBeater.GetSpectrumData (samplesR, 1, FFTWindow.BlackmanHarris);

		float energy = 0;
		for (int i = 0; i < qSamples/4; i++) {
			energy += (samplesL[i]+samplesR[i])/2f;
		}
		
		
		if (timeBeforeKey < Time.time && energy > getAverageEnergy()*1.7f) {
			bm.beat(delay);
			timeBeforeKey = Time.time + timeBetweenKey;
		}
		previousEnergies.Enqueue(energy);
		if(previousEnergies.Count>60)
			previousEnergies.Dequeue();

		Debug.Log (progression ());
		progress.value = progression ();
	}
	float getAverageEnergy(){
		float wtr = 0;
		foreach(float energy in previousEnergies)
			wtr += energy;
		return wtr/previousEnergies.Count;
	}

	public float progression(){
		return ((Time.time-startTime)/(endTime-startTime))*100;
	}
}
