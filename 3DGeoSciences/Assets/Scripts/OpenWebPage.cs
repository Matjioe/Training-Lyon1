using UnityEngine;
using System.Collections;

public class OpenWebPage : MonoBehaviour {

	public string url;

	public void OpenUrl()
	{
		Application.OpenURL(url);
	}
}
