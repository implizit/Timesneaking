using UnityEngine;
using System.Collections.Generic;

public class Inventory
{

	private List<Slot> slots;
	private Slot acitveSlot;
	//private List<ItemInterface> items;
	private InventoryDefenition defenition;

	public Inventory(InventoryDefenition defenition)
	{
		//items = new List<ItemInterface>(size);
		this.defenition = defenition;
		slots = new List<Slot>(defenition.slot_count);
		for (int i = 0; i < defenition.slot_count; i++)
		{
			slots.Add(new Slot());
		}
	}

	public bool add(ItemInterface item)
	{
		Slot slot = get1stFreeSlot();
		if (slot != null)
		{
			slot.setItem(item);
			return slot.getItem() == item;
		}
		return false;
	}

	private Slot get1stFreeSlot()
	{
		foreach (var slot in slots)
		{
			if (slot.isEmpty())
			{
				return slot;
			}
		}
		return null;
	}

	public void setActiveSlot(Slot slot)
    {
		if(acitveSlot != slot)
        {
			acitveSlot = slot;
        }
    }
}
