using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Schnellzugriff : MonoBehaviour
{
	private class Slot
    {
		public GameObject root;
		public Image itemimg;
		public Image border;
    }

	#region Variables
	[Range(1, 20)]
	public int size;
	public GameObject SlotPrefab;
	public GameObject SchnellzugriffParent;
	public Image defalutItem;
	public Image defalutEmpty;

	private List<Slot> slots;
	private Slot acitveSlot;

	#endregion
	
	#region Unity Methods
	
    void Start()
    {
		slots = new List<Slot>();

		for (int i = 0; i < size; i++)
        {
			GameObject go = Instantiate(SlotPrefab);
			go.transform.SetParent(SchnellzugriffParent.transform);

			Slot slot = new Slot();
			slot.root = go;
			slot.itemimg = go.transform.GetChild(0).GetComponent<Image>();
			slot.border = go.GetComponent<Image>();
			slots.Add(slot);
        }
    }
	
	#endregion
	
	#region Regular Methods
	public void setImage(int slot, Sprite image)
    {
		if(slot >= 0 && slot < slots.Count)
        {
			if (image != null)
			{
				slots[adjustIndex(slot)].itemimg.sprite = image;
			}
			else
            {
				Debug.Log("no image");
            }
        }
    }

	public void markAcitve(int slot)
    {
		revertAcitve();
		acitveSlot = slots[adjustIndex(slot)];
		//acitveSlot.border.color = new Color();
		acitveSlot.border.enabled = true;
	}

	public void revertAcitve()
	{
		if (acitveSlot != null)
		{
			acitveSlot.border.enabled = false;
		}
	}

	public int adjustIndex(int original)
    {
		return size - original - 1;
    }
	#endregion
	
}
