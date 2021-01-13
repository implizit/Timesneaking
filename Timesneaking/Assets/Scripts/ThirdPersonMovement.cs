using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
	#region Variables

	//Allgemein
	public Animator anim;

	[Header("Camera")]
	public Cinemachine.AxisState yAxis;//depracted
	public Cinemachine.AxisState xAxis;//depracted
	//public Transform cameraLookAt;

	private Camera cam;

	[Header("Movement")]
	private CharacterController controller;

	[Header("Movement - Direction")]
	[Range(0f, 1f)]
	public float turnSmoothTime = 0.1f;
	public float turnSpeed = 3f;

	private float turnSmoothVelocity;
	private Transform camTransform;
	private float inputHorizontal;
	private float inputVertical;

	[Header("Movement - XZ")]
	[Range(0f, 100f)]
	public float sprintSpeed = 6f;

	private bool isSprinting;

	[Header("Movement - Y")]
	[Range(0f, 100f)]
	public float jumpHeigth = 5f;
	[Range(-1000f, 0f)]
	public float gravity = -9.81f;
	[Range(-100f, 0f)]
	public float defaultgravity = 0f;

	private Vector3 velocityY;
	private bool inputJump;
	private bool isJumping;

	[Header("GroundCheck")]
	public Transform groundCheck;
	[Range(0f, 10f)]
	public float groundCheckSphereRadius;
	public LayerMask groundCheckMask;

	private bool isgrounded;

	#endregion

    #region Unity Methods
    void Start()
    {
		cam = Camera.main;
		camTransform = cam.transform;
		Cursor.lockState = CursorLockMode.Locked;
		controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
		if (!Pausenmenü.instance.getisPausiert())
		{
			getScriptScopeInput();
			handleAirState();
			handleWalkAround();
		}
	}

    private void OnDrawGizmosSelected()
    {
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckSphereRadius);
    }

    #endregion

    #region Regular Methods

	/*private void updateCamera()
    {
		xAxis.Update(Time.deltaTime);
		yAxis.Update(Time.deltaTime);

		cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0f);
	}*/

	private void handleWalkAround()
    {
		float speedFaktor = (isSprinting ? 1f : 0.5f);

		anim.SetFloat("SpeedForward", inputVertical * speedFaktor);
		anim.SetFloat("SpeedSideward", inputHorizontal * speedFaktor);

		Vector3 direction = new Vector3(inputHorizontal, 0f, inputVertical).normalized;

		if (direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(moveDir.normalized * sprintSpeed * speedFaktor * Time.deltaTime);
		}

		if (Input.GetMouseButton(1))
		{
			float yawCamera = cam.transform.rotation.eulerAngles.y;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, yawCamera, 0f), turnSpeed * Time.deltaTime);
		}
	}

    private void getScriptScopeInput()
    {
		inputHorizontal = Input.GetAxisRaw("Horizontal");
		inputVertical = Input.GetAxisRaw("Vertical");
		inputJump = Input.GetButton("Jump");
		isSprinting = !Input.GetKey(KeyCode.LeftShift);
	}

	private void handleAirState()
    {
		dogroundCheck();
		calculateAirState();
		applyAirState();
	}

	private void calculateAirState()
    {
		if (isgrounded && velocityY.y < 0f)
		{
			velocityY.y = defaultgravity;
			if(isJumping)
			{
				endJump();
			}
		}

		velocityY.y += gravity * Time.deltaTime;

		if (inputJump && !isJumping && isgrounded)
		{
			beginJump();
		}
	}

	private void applyAirState()
    {
		controller.Move(velocityY * Time.deltaTime);
	}

	private void dogroundCheck()
    {
		isgrounded = Physics.CheckSphere(groundCheck.position, groundCheckSphereRadius, groundCheckMask);
		//Alternative: controller.isGrounded
		anim.SetBool("isJumping", !isgrounded);
	}

	private void beginJump()
	{
		isJumping = true;
		velocityY.y = Mathf.Sqrt(jumpHeigth * -2f * gravity);
	}
	private void endJump()
    {
		isJumping = false;
	}

	/*
	else if(inputJump)
	{
		Debug.Log("isJumping: " + isJumping + " isgrounded: " + isgrounded);
	}
	if (isgrounded && velocity.y < 0f)
	{
		velocity.y = defaultgravity;
	}

	if (!wasgrounded && isjumping)
	{
		isjumping = false;
	}

	if (isgrounded && !isjumping && inputJump)
	{
		velocity.y += Mathf.Sqrt(jumpHeigth * -2f * gravity);
		isjumping = true;
	}*/

	#endregion
}
