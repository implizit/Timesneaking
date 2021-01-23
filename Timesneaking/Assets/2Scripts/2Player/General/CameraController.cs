using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
	#region Variables
	public KeyCode keyCodeAim;
	public int mouseButtonAiming = 1;
	public CinemachineVirtualCameraBase CameraNormal;
	public CinemachineVirtualCameraBase CameraAiming;
	public bool isAiming { get; private set; }

	private static int prioLow = 20;
	private static int prioHigh = 40;
	#endregion
	
	#region Unity Methods
	
    void Start()
	{
		setIsAiming(false);
	}

    void Update()
    {
        if(Input.GetKey(keyCodeAim) || Input.GetMouseButton(mouseButtonAiming)) {
			if(!isAiming)
			{
				setIsAiming(true);
			}
        }
		else
        {
			if(isAiming)
			{
				setIsAiming(false);
            }
        }
    }

	private void setIsAiming(bool value)
    {
		if(isAiming != value)
        {
			isAiming = value;
			if(isAiming)
			{
				CameraAiming.Priority = prioHigh;
				CameraNormal.Priority = prioLow;
			} else
            {
				CameraNormal.Priority = prioHigh;
				CameraAiming.Priority = prioLow;
			}
        }
    }
	
	#endregion
	
	#region Regular Methods
		
	#endregion
	
}
