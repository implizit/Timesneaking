using UnityEngine;

public class MaterialHandler : MonoBehaviour
{
	#region Variables
	public static MaterialHandler instance;

	public Material gewöhnlichMat;
	public Material hervorragendMat;
	public Material epischMat;
	public Material legendärMat;
	#endregion

	#region Unity Methods

	void Awake()
    {
		instance = this;
    }

	
	#endregion
	
	#region Regular Methods
		
	#endregion
	
}
