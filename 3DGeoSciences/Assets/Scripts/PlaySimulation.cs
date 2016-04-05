using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaySimulation : MonoBehaviour {
	
	public float framesPerSeconds = 10f;
	public Slider timeLineSlider;
	public ProceduralSound proceduralSound;

	void Start()
	{
		if (timeLineSlider == null)
			Debug.LogError("PlaySimulation requires a slider");
	}

	void Update ()
	{
		if (timeLineSlider == null)
			return;
		
		float value = timeLineSlider.value;
		value += Time.deltaTime * framesPerSeconds;
		if (value > timeLineSlider.maxValue)
			value = 0;
		timeLineSlider.value = value;
	}

	void OnEnable()
	{
		if (proceduralSound)
			proceduralSound.Play();
	}

	void OnDisable()
	{
		if (proceduralSound)
			proceduralSound.Stop();
	}
}