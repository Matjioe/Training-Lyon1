using UnityEngine;
using System.Collections;

public class SpawnEarthquakeBehaviour : StateMachineBehaviour {

	public GameObject prefab;
	public string exitTrigger;
	public AudioClip audioClip;

	private GameObject go;
	bool spawned = false;

	public float dragTime = 0f;
	public bool raiseEvent = false;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		go = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		go.transform.SetParent(animator.gameObject.transform);
		go.SetActive(false);
		spawned = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Measure drag time
		if (Input.GetMouseButtonDown(0))
		{
			dragTime = 0f;
		}
		else if (Input.GetMouseButton(0))
		{
			dragTime += Time.deltaTime;
		}

		bool hit = MoveObjectOnSphere();
		if (hit == true)
		{
			// Show object when the mouse is not over a spwaning surface
			go.SetActive(true);

			// Spawn object if clicking (not dragging)
			if (Input.GetMouseButtonUp(0) && dragTime < 0.5f)
			{
				spawned = true;
				animator.SetTrigger(exitTrigger);
				dragTime = 0f;
				if (raiseEvent)
				{
					animator.GetComponent<GameEvents>().onSpawnedSeism.Invoke();
				}
				if (audioClip != null)
					AudioSource.PlayClipAtPoint(audioClip, go.transform.position);
			}
		}
		else
		{
			// Hide object when the mouse is not over a spwaning surface
			go.SetActive(false);
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (spawned == false)
		{
			Destroy(go);
		}
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

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
