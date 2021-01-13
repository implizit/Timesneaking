using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class WeaponSO : ItemSO
{
	#region Variables
	public string weaponType = "weapon";
	[Range(0, 1000)]
	public int damage = 10;
	public float fireRate = 1f;
	[Range(0f, 100f)]
	public float inaccuracy = 0f;
	public float range = 100f;
	public int magazingröße = 20;

		
	//public Vector3 Wposition = new Vector3(0f, 0f, 0f);
	//public Vector3 Wrotation = new Vector3(0f, 0f, 0f);
	//public Vector3 Wscale = new Vector3(1f, 1f, 1f);
	#endregion

	#region Unity Methods

	#endregion

	#region Regular Methods

	#endregion

}
