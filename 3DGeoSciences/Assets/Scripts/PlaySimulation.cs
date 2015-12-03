using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaySimulation : MonoBehaviour {
	
	public float framesPerSeconds = 10f;
	
	void Update ()
	{
		Slider slider = GetComponent<Slider>();
		float value = slider.value;
		value += Time.deltaTime * framesPerSeconds;
		if (value > slider.maxValue)
			value = 0;
		slider.value = value;
	}
}