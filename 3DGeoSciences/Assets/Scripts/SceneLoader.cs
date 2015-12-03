using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
	public void LoadScene(string name)
	{
		Application.LoadLevel(name);
	}

}
