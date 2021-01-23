using UnityEngine;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
	#region Variables

	//Allgemein
	public Animator anim;
	public CinemachineBrain cmb;
	public CinemachineFreeLook cmFreeLook;

	[Header("Camera")]
	public AxisState yAxis;//depracted
	public AxisState xAxis;//depracted
	public Transform cameraLookAt;

	public Camera mainCamera;

	[Header("Movement - Direction")]
	[Range(0f, 1f)]
	public float turnSmoothTime = 0.1f;
	public float turnSpeed = 10f;

	[Header("Movement - XZ")]
	[Range(0f, 100f)]
	public float sprintSpeed = 6f;

	[Header("Movement - Y")]
	[Range(0f, 100f)]
	public float jumpHeigth = 5f;
	[Range(-1000f, 0f)]
	public float gravity = -9.81f;
	[Range(-100f, 0f)]
	public float defaultgravity = 0f;

	[Header("GroundCheck")]
	public Transform groundCheck;
	[Range(0f, 10f)]
	public float groundCheckSphereRadius;
	public LayerMask groundCheckMask;


	private CharacterController controller;
	private float turnSmoothVelocity;
	private Transform camTransform;

	private float inputHorizontal;
	private float inputVertical;

	private Vector2 _inputVertHor;
	private float _targetSpeedXY;
	private float _currentSpeedXY;
	private float velocityXY;
	
	private bool inputSprinting;
	private Vector3 velocityY;
	private bool inputJump;
	private bool isJumping;
	private bool isgrounded;


	#endregion

    #region Unity Methods
    void Start()
    {
		if (mainCamera == null)
		{
			mainCamera = Camera.main;
		}
		camTransform = mainCamera.transform;
		Cursor.lockState = CursorLockMode.Locked;
		controller = GetComponent<CharacterController>();
    }

    private void LateUpdate()
    {
		if (!Pausenmenü.instance.getIsPausiert())
		{
			updateCamera();
			getScriptScopeInput();
			handleAirState();
			handleWalkAround();
			//cmb.ManualUpdate();
		}
	}

    private void OnDrawGizmosSelected()
    {
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckSphereRadius);
    }

    #endregion

    #region Regular Methods

	private void updateCamera()
    {
		xAxis.Update(Time.deltaTime);
		yAxis.Update(Time.deltaTime);

		cmFreeLook.m_XAxis.m_InputAxisValue = xAxis.m_InputAxisValue;
		cmFreeLook.m_YAxis.m_InputAxisValue = yAxis.m_InputAxisValue;

		//cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0f);
	}

	private void handleWalkAround()
    {
		_inputVertHor.x = Input.GetAxisRaw("Horizontal");
		_inputVertHor.y = Input.GetAxisRaw("Vertical");

		_targetSpeedXY = Mathf.Abs(_inputVertHor.x) + Mathf.Abs(_inputVertHor.y);

		_targetSpeedXY = Mathf.Clamp(_targetSpeedXY, 0f, 1f);
		_currentSpeedXY = Mathf.SmoothDamp(_currentSpeedXY, _targetSpeedXY, ref velocityXY, 0.1f);



		float speedFaktor = (inputSprinting ? 1f : 0.5f);

		anim.SetFloat("SpeedForward", inputVertical * speedFaktor);
		anim.SetFloat("SpeedSideward", inputHorizontal * speedFaktor);
		
		//transform.rotation = Quaternion.Euler(0f, cam.transform.rotation.eulerAngles.y, 0f);

		//float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, yawCamera, 0f), turnSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Euler(0f, mainCamera.transform.rotation.eulerAngles.y, 0f);

		Vector3 direction = new Vector3(inputHorizontal, 0f, inputVertical).normalized;

		if (direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(moveDir.normalized * sprintSpeed * speedFaktor * Time.deltaTime);

		/*Vector3 moveDir = Quaternion.Euler(0f, cam.transform.rotation.eulerAngles.y, 0f) * Vector3.forward;
		controller.Move(moveDir.normalized * sprintSpeed * speedFaktor * Time.deltaTime);*/
		}
	}

    private void getScriptScopeInput()
    {
		inputHorizontal = Input.GetAxisRaw("Horizontal");
		inputVertical = Input.GetAxisRaw("Vertical");
		inputJump = Input.GetButton("Jump");
		inputSprinting = !Input.GetKey(KeyCode.LeftShift);
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
	#endregion
}
/*
 		/*Vector3 direction = new Vector3(inputHorizontal, 0f, inputVertical).normalized;

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
		}}*/