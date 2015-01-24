using UnityEngine;
using System.Collections;

public class BeatFinder : MonoBehaviour {

	public ButtonManager bm;
	public int qSamples = 1024;
	public float bias = 0.02f; //mini Amplitude to extract pitch
	public float delay = 0f;
	public int selectedPitch = 120;

	public float timeBetweenKey = 0.2f;
	//public float timeTweeker = 0.1f;
	//public int percent = 50; 

	private float[] samplesL, samplesR;
	private float /*sum,*/ oldRms, newRms, timeBeforeKey, maxSum, fSample;

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
		fSample = AudioSettings.outputSampleRate;



		timeBeforeKey = Time.time + timeBetweenKey;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 0 && musicBeater.isPlaying) {
			musicBeater.Pause ();
			musicReader.Pause ();
		} else if(Time.timeScale >0 && !musicBeater.isPlaying){
			musicBeater.Play();
			musicReader.Play ();
				}

		musicBeater.GetSpectrumData (samplesL, 0, FFTWindow.BlackmanHarris);
		musicBeater.GetSpectrumData (samplesR, 1, FFTWindow.BlackmanHarris);

		float[] sum = new float[qSamples];

		for (int i = 0; i < qSamples; i++) {
			sum[i] = (Mathf.Abs(samplesL[i])+Mathf.Abs(samplesR[i]))/2;
		}

		float maxV = 0;
		int maxN = 0;

		for (int i=0; i < qSamples; i++){ // find max 
			if (sum[i] > maxV && sum[i] > bias){
				maxV = sum[i];
				maxN = i; // maxN is the index of max
			}
		}

		float freqN = maxN; // pass the index to a float variable
		if (maxN > 0 && maxN < qSamples-1){ // interpolate index using neighbours
			float dL = sum[maxN-1]/sum[maxN];
			float dR = sum[maxN+1]/sum[maxN];
			freqN += 0.5f*(dR*dR - dL*dL);
		}
		float pitchValue = freqN*(fSample/2)/qSamples;

		//Debug.Log (timeBeforeKey+" "+Time.time);

		if (timeBeforeKey < Time.time && pitchValue > selectedPitch) {
			bm.beat(delay);
			//Debug.Log("ping");
			timeBeforeKey = Time.time + timeBetweenKey;
				}

		/*musicBeater.GetOutputData (samplesL, 0);
		musicBeater.GetOutputData (samplesR, 1);
		sum = 0.0f;

		for (int i = 0; i < qSamplesLow; i++) {
			sum += (Mathf.Abs(samplesL[i])+Mathf.Abs(samplesR[i]));
		}
		newRms = sum / (qSamples*2);

		if (timeBeforeTweek > Time.time) {
			timeBeforeTweek = Time.time + timeTweeker;
			
			if(newRms-oldRms > maxSum)
				maxSum = newRms-oldRms;
		}

		if((newRms-oldRms)>(maxSum*percent/100))
			Debug.Log ("bing");

		if (timeBeforeTweek > Time.time) {
			timeBeforeTweek = Time.time + timeTweeker;
			
			if(newRms-oldRms > maxSum){
				maxSum = newRms-oldRms;
			}
		}*/

		oldRms = newRms;
	}
}
