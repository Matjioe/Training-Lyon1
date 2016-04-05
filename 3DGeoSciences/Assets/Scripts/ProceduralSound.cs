using UnityEngine;
using System.Collections;

public class ProceduralSound : MonoBehaviour {

	public AudioSource simulationAudio;
	public float releaseSpeed = 0.2f;

	public void UpdateSimulationSound(float simuPercentage)
	{
		simulationAudio.pitch = 0.3f + simuPercentage / 100f;
	}

	public void Play()
	{
		simulationAudio.volume = 0.0f;
		simulationAudio.Play();
		StartCoroutine("AttackSound");
	}

	public void Stop()
	{
		StartCoroutine("ReleaseSound");
	}

	IEnumerator ReleaseSound()
	{
		while(simulationAudio.volume > 0f)
		{
			simulationAudio.volume -= releaseSpeed * Time.deltaTime;
			yield return null;
		}
		simulationAudio.Stop();
	}

	IEnumerator AttackSound()
	{
		while(simulationAudio.volume < 1f)
		{
			simulationAudio.volume += releaseSpeed * Time.deltaTime;
			yield return null;
		}
	}
}
