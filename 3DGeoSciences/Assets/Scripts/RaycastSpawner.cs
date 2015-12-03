using UnityEngine;
using System.Collections;

public class RaycastSpawner : MonoBehaviour {

	public GameObject prefab;

	private float lastTimeMouseButtonDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			lastTimeMouseButtonDown = Time.time;
		}

		if (Input.GetMouseButtonUp(0) && Time.time - lastTimeMouseButtonDown < 0.1f)
		{
			SpawnOnHit();
		}
	}

	void SpawnOnHit()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit) == true)
		{
			GameObject go = (GameObject) Instantiate(prefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
			go.transform.SetParent(transform);
		}
	}
}
