using UnityEngine;

public class Slot
{
	private ItemInterface item;
	//public readonly int number;

	/*public Slot(int n)
	{
		number = n;
	}*/

	public bool isEmpty()
	{
		return item == null;
	}

	public void setItem(ItemInterface value)
	{
		if (value != item)
		{
			item = value;
			onItemChange();
		}
	}

	public ItemInterface getItem()
	{
		return item;
	}

	protected virtual void onItemChange()
    {

    }
}
/*if (value != item)
{
	bool doSwap = false;
	Item oldItem = item;
	if (item != null)
	{
		if (slotSwaps != null && slotSwaps.Count > 0 && slotSwaps[0].allow)
		{
			doSwap = true;
		}
		else
		{
			throw new System.Exception("Slot ist bereits belegt!");
		}
	}
	item = value;
	if (item != null)
	{
		item.setOrCheckSlot(this, null);
	}
	if (doSwap)
	{
		Slot slot = slotSwaps[0].slot;
		slotSwaps.RemoveAt(0);
		oldItem.setOrCheckSlot(slot, slotSwaps);
	}
}*/