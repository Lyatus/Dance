using UnityEngine;
using System.Collections;

public class BeatFinder : MonoBehaviour {

	public int qSamples = 1024;
	public float bias = 0.25f;
	public float delay = 2f;
	public float timeTweeker = 0.1f;
	public int percent = 50; 

	private float[] samplesL, samplesR;
	private float sum, oldRms, newRms, timeBeforeTweek, maxSum;

	private AudioSource musicBeater;
	private AudioSource musicReader;
	private AudioLowPassFilter filter;

	// Use this for initialization
	void Start () {
		musicBeater = GetComponent<AudioSource> ();
		musicReader = gameObject.AddComponent<AudioSource> ();
		//musicReader = gameObject.GetComponentInChildren<AudioSource> ();
		musicReader.clip = musicBeater.clip;
		musicReader.PlayDelayed(delay);

		musicBeater.volume = 0;


		samplesL = new float[qSamples];
		samplesR = new float[qSamples];

		oldRms = 0; maxSum = 0;

		timeBeforeTweek = Time.time + timeTweeker;
	}
	
	// Update is called once per frame
	void Update () {

		//musicBeater.GetSpectrumData (samplesL, 0, FFTWindow.Blackman);
		//musicBeater.GetSpectrumData (samplesR, 1, FFTWindow.Blackman);

		musicBeater.GetOutputData (samplesL, 0);
		musicBeater.GetOutputData (samplesR, 1);
		sum = 0.0f;

		for (int i = 0; i < qSamples; i++) {
			sum += (Mathf.Abs(samplesL[i])+Mathf.Abs(samplesR[i]));
		}
		newRms = sum / (qSamples*2);

		//Debug.Log (newRms-oldRms);

		if (timeBeforeTweek > Time.time) {
			timeBeforeTweek = Time.time + timeTweeker;
			
			if(newRms-oldRms > maxSum)
				maxSum = newRms-oldRms;
		}

		if((newRms-oldRms)>(maxSum*percent/100))
			Debug.Log ("bing");

		//Debug.Log (maxSum);

		if (timeBeforeTweek > Time.time) {
			timeBeforeTweek = Time.time + timeTweeker;
			
			if(newRms-oldRms > maxSum){
				maxSum = newRms-oldRms;
			}
		}
		oldRms = newRms;
	}
}
