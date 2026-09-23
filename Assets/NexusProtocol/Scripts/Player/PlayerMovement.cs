using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;

	private Rigidbody playerRigidbody;
	private Vector3 moveDirection;
	private void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");

		moveDirection = new Vector3(horizontalInput,0f,verticalInput).normalized;
	}
	private void FixedUpdate()
	{
		Vector3 movementVelocity = moveDirection * moveSpeed;
		movementVelocity.y = playerRigidbody.velocity.y;

		playerRigidbody.velocity = movementVelocity;
	}
}