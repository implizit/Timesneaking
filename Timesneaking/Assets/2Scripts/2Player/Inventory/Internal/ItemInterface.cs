using UnityEngine;

public class ItemInterface 
{
	/*private string ItemType_amount; // TODO mithilfe von Vererbung lösen
	private int max_amount;
	private int amount;*/

	private string itemName;
	private ItemSO.Qualität quality;
	private Sprite image;

	private ItemInterface(ItemSO.Qualität qu, string name, Sprite img)
	{
		quality = qu;
		itemName = name;
		image = img;
	}

	public static ItemInterface factory_Item(InventoryBehaviour i)
	{
		return factory_internal(i, "", null, ItemSO.Qualität.gewöhnlich);
	}/*
	public static ItemInterface factory_ItemStackable(string name, Sprite img, ItemSO.Qualität qu)
	{
		Item product = new Item(qu, name, img);
		return product;
	}*/

	private static ItemInterface factory_internal(InventoryBehaviour i, string name, Sprite img, ItemSO.Qualität qu)
    {
		return new ItemInterface(qu, name, img);
    }

	/*public void setOrCheckSlot(Slot value, List<SlotSwap> slotSwaps)
	{
		if (value != slot)
		{
			if (slot != null)
			{
				try
				{
					slot.setOrCheckItem(this, slotSwaps);
				}
				catch (System.Exception)
				{
					return;
				}
			}
			slot = value;
		}
	}

	public Slot getSlot()
	{
		return slot;
	}*/
}
