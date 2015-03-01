using UnityEngine;
using System.Collections;

public class CameraandMovement : MonoBehaviour {
	private Camera cam;
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	float rotationY = 0F;
	public bool _controllable=false;
	// Use this for initialization
	void Start () {
		cam = new Camera ();
		cam = Instantiate (gameObject.AddComponent<Camera> (), new Vector3 (0, 0, 0), gameObject.transform.rotation)as Camera;
		cam.transform.parent = gameObject.transform.parent;
		cam.transform.position = gameObject.transform.position;
		if (rigidbody)
			rigidbody.freezeRotation = true;
		_controllable = true;
		gameObject.GetComponent<CharacterController> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxisRaw("Mouse X") * sensitivityX;
			rotationY += Input.GetAxisRaw("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxisRaw("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxisRaw("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}


		CharacterController controller = GetComponent<CharacterController>();
		// is the controller on the ground?
		if (controller.isGrounded) {
			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);
	
	

	
	
	
	
	
	
	
	
	
	}
	

	void FixUpdate(){

		
	}




}
