using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

	private void Update()
	{
		FollowingTarget(target);	
	}

	private void FollowingTarget(Transform target)
	{
		var dir = new Vector3(target.position.x, target.position.y, transform.position.z);

		transform.position = dir;
	}
}
