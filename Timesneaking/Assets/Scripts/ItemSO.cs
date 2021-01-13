using UnityEngine;
using UnityEngine.UI;

public class ItemSO : ScriptableObject
{
	public enum Qualität { gewöhnlich, hervorragend, episch, legendär };

	#region Variables
	public string itemName = "New Item";
	public Qualität qualität = Qualität.gewöhnlich;
	public Sprite image;

	public Vector3 position = new Vector3(0f, 0f, 0f);
	public Vector3 rotation = new Vector3(0f, 0f, 0f);
	public Vector3 scale = new Vector3(1f, 1f, 1f);
	#endregion

	#region Unity Methods

	#endregion

	#region Regular Methods

	#endregion

}
