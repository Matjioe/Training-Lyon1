﻿using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
	public void LoadScene(string name)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(name);
		//Application.LoadLevel(name);
	}

}
