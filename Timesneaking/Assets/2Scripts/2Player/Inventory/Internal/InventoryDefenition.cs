using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Defenition", menuName = "Inventory/Defenition")]
public class InventoryDefenition : ScriptableObject
{
	public int slot_count = 20;
	public int max_amount_per_slot = 1;
}
