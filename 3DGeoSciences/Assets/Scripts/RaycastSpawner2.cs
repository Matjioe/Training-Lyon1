using UnityEngine;
using System.Collections;

public class RaycastSpawner2 : MonoBehaviour {

	public GameObject prefab;
	private GameObject go;

	// Use this for initialization
	void Start ()
	{
		go = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		go.transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveObjectOnSphere();
	}

	/// <summary>
	/// Move gameObject on sphere.
	/// Return true if sphere hit.
	/// </summary>
	/// <returns><c>true</c>, if object on sphere was moved, <c>false</c> otherwise.</returns>
	bool MoveObjectOnSphere()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit) == true)
		{
			go.transform.position = hit.point;
			go.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
			return true;
		}
		
		return false;
	}
}
