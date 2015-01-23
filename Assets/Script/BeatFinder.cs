using UnityEngine;
using System.Collections;

public class BeatFinder : MonoBehaviour {

	public int qSamples = 1024;
	public float bias = 0.25f;
	public float delay = 2f;

	private float[] samplesL, samplesR;
	private float sum, oldRms, newRms, timeBeforeRun;

	private AudioSource musicBeater;
	private AudioSource musicReader;

	// Use this for initialization
	void Start () {
		musicBeater = GetComponent<AudioSource> ();
		musicReader = gameObject.AddComponent<AudioSource> ();
		musicReader.clip = musicBeater.clip;
		musicReader.PlayDelayed(delay);


		musicBeater.volume = 0;


		samplesL = new float[qSamples];
		samplesR = new float[qSamples];

		oldRms = 0;
	}
	
	// Update is called once per frame
	void Update () {

		musicBeater.GetOutputData (samplesL, 0);
		musicBeater.GetOutputData (samplesR, 1);
		sum = 0.0f;

		for (int i = 0; i < qSamples; i++) {
			//sum += ((samplesL[i] * samplesL[i])+(samplesR[i] * samplesR[i]))/2;
			sum += (Mathf.Abs(samplesL[i])+Mathf.Abs(samplesR[i]));
		}
		//rms = Mathf.Sqrt (sum / qSamples);
		newRms = sum / (qSamples*2);



		if((newRms-oldRms)>bias)
			Debug.Log ("bing");


		oldRms = newRms;
	}
}
