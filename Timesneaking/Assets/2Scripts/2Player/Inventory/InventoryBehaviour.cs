﻿using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryBehaviour : MonoBehaviour
{

    #region Variables

    private readonly static int INVALID_INDEX = int.MinValue;
	//private readonly static int INVENTORY_SIZE = 20;

	public InventoryDefenition inventoryDefenition;

	//public int inventorySize { get; private set; }
	public TextMeshProUGUI tmesh;

	[Header("Bones")]
	public Transform leftHand;
	public Transform rightHand;

	[Header("Keys")]
	public KeyCode keyCodetDequip = KeyCode.T;
	public KeyCode keyCodetEquip1 = KeyCode.Alpha1;
	public KeyCode keyCodetEquip2 = KeyCode.Alpha2;
	public KeyCode keyCodetEquip3 = KeyCode.Alpha3;
	public KeyCode keyCodetEquip4 = KeyCode.Alpha4;
	public KeyCode keyCodetEquip5 = KeyCode.Alpha5;
	public KeyCode keyCodetEquip6 = KeyCode.Alpha6;
	public KeyCode keyCodetEquip7 = KeyCode.Alpha7;
	public KeyCode keyCodetEquip8 = KeyCode.Alpha8;

	private Camera cam;
	private Schnellzugriff schnellzugriff;
	//private List<PickUp> items = new List<PickUp>();
	//private PickUp equippedItem;
	//private int equippedItemIndex = INVALID_INDEX;
	private Inventory inventoryManager;
	private IPlayer player;

	#endregion

	#region Unity Methods

	void Start()
    {
		player = GetComponent<Player>();
		cam = player.getMainCamera();
		schnellzugriff = player.GetSchnellzugriff();
		inventoryManager = new Inventory(inventoryDefenition);
		//internalEquip(null, INVALID_INDEX);
	}

    void Update()
    {
        evaluateInput();
    }

	#endregion

	#region Regular Methods
	private void evaluateInput()
	{
		if (Input.GetKeyDown(keyCodetDequip)) {
			//internalEquip(null, INVALID_INDEX);
		}
		if (Input.GetKeyDown(keyCodetEquip1))
		{
			equip(0);
		}
		if (Input.GetKeyDown(keyCodetEquip2))
		{
			equip(1);
		}
		if (Input.GetKeyDown(keyCodetEquip3))
		{
			equip(2);
		}
	    if(Input.GetKeyDown(keyCodetEquip4))
		{
			equip(3);
		}
		if (Input.GetKeyDown(keyCodetEquip5))
		{
			equip(4);
		}
		if (Input.GetKeyDown(keyCodetEquip6))
		{
			equip(5);
		}
		if (Input.GetKeyDown(keyCodetEquip7))
		{
			equip(6);
		}
		if (Input.GetKeyDown(keyCodetEquip8))
		{
			equip(7);
		}
		handleMouseScrollWheel();
	}
	
	private void handleMouseScrollWheel()
    {/*
		if(Input.mouseScrollDelta.y > 0.1f)
        {
			equip(equippedItemIndex - 1);
        } 
		else if (Input.mouseScrollDelta.y < -0.1f)
		{
			equip(equippedItemIndex + 1);
		}*/
	}
	/*
	private void onSchnellzugriffChange()
    {
		for(int i = 0; i < schnellzugriff.size && i < items.Count; i++)
        {
			if(items[i].item.image != null)
            {
				schnellzugriff.setImage(i, items[i].item.image);
            }
        }
    }
	*/
	public bool add(ItemInterface item)
    {
		return inventoryManager.add(item);
		/*if(items.Count < inventorySize) 
		{
			items.Add(item);
			onSchnellzugriffChange();
			return true;
		}
        else
        {
			return false;
        }*/
    }
	
	private void equip(int index)
	{/*
		if (index >= 0 && index < items.Count)
		{
			internalEquip(items[index], index);
		}
		else
        {
			internalEquip(null, INVALID_INDEX);
		}
		if (equippedItem != null)
		{
			schnellzugriff.markAcitve(index);
		}
		else
        {
			schnellzugriff.revertAcitve();
        }*/
	}
	/*
	private void internalEquip(PickUp newItem, int index)
	{
		if (equippedItem != newItem)
		{
			if (equippedItem != null)
			{
				equippedItem.gameObject.SetActive(false);
			}
			if (newItem != null)
			{
				newItem.gameObject.SetActive(true);
				newItem.gameObject.transform.SetParent(rightHand.transform);

				newItem.gameObject.transform.localPosition = newItem.item.position;//new Vector3();//0.001773604f, 0.005654313f, -0.0009117064f
				newItem.gameObject.transform.localRotation = Quaternion.Euler(newItem.item.rotation);//Quaternion.Euler();//78.65601f, -29.607f, -48.652f
				newItem.gameObject.transform.localScale = newItem.item.scale;

				tmesh.text = newItem.item.itemName;
				if(index != INVALID_INDEX)
                {
					equippedItemIndex = index;
				}
			}
			equippedItem = newItem;
		}
		if(equippedItem == null)
		{
			tmesh.text = "";
		}
	}*/
	#endregion
	
}
