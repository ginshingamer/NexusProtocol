using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offset = new Vector3(0f,11f,-8f);
	
	private void LateUpdate()
	{
		if(target==null)
		{
			return;
		}

		transform.position = target.position+offset;
	}
}