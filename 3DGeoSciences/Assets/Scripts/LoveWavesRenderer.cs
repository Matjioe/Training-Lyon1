using UnityEngine;
using System.Collections;

public class LoveWavesRenderer : MonoBehaviour {
	
	public int maxElementCount = 100;
	public Vector3[] vertices;
	public int[] indices;
	public Material material;
	private Mesh mesh;
	public bool showMesh = false;
	
	void Start() {
		mesh = new Mesh();
		vertices = new Vector3[maxElementCount];
		for (int i = 0; i < maxElementCount; ++i)
		{
			vertices[i] = Vector3.zero;
		}
		indices = new int[maxElementCount];
		for (int i = 0; i < maxElementCount; ++i)
		{
			indices[i] = i;
		}
		mesh.vertices = vertices;
		mesh.SetIndices(indices, MeshTopology.LineStrip, 0);
	}
	
	public void Render(float percent)
	{
		Vector3 pickedPos = transform.FindChild("Earthquake(Clone)").position;
		Vector3[] vertices = mesh.vertices;
		float percentf = (float)percent/100f;
		float percentRad = percentf * Mathf.PI;
		for (int i = 0; i < maxElementCount; ++i)
		{
			vertices[i] = pickedPos - pickedPos * percentf * 2f
				+ Quaternion.AngleAxis(360f*(float)i/(float)maxElementCount, -pickedPos) * Vector3.right * pickedPos.magnitude * Mathf.Sin(percentRad);
		}
		mesh.vertices = vertices;
		
	}
	
	public void ShowMesh(bool show)
	{
		showMesh = show;
	}
	
	void Update()
	{
		if (showMesh)
			Graphics.DrawMesh(mesh, Matrix4x4.identity, material, 0); 
	}
}
