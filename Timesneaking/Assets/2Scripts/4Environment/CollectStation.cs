using UnityEngine;
using System;

public class CollectStation : PickUpInventoryItem<InteractionPlayer, ItemHandler>
{

	#region Variables
	public float rotationSpeed;

	public MeshRenderer ownMR;
	#endregion
	
	#region Unity Methods
	
    void Start()
    {
		refresh();
    }

	void Update()
	{
		refresh();
		foreach (ItemHandler item in targets)
		{
			item.gameObject.transform.rotation = Quaternion.Euler(0f, item.gameObject.transform.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, 0f);
		}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
			Interactor i = other.gameObject.GetComponent<Interactor>();
			if(i != null)
            {
				i.interactWith(this);
            }
        }
    }

    #endregion

    #region Regular Methods
    public override void refresh()
	{
		if (refreshActive())
		{
			repairData();
			onItemPointChanged();
		}
    }

    public void onItemPointChanged()
    {
		switch (mainTarget.GetQualität())
		{
			case ItemSO.Qualität.gewöhnlich:
				ownMR.material = MaterialHandler.instance.gewöhnlichMat;
				break;
			case ItemSO.Qualität.hervorragend:
				ownMR.material = MaterialHandler.instance.hervorragendMat;
				break;
			case ItemSO.Qualität.episch:
				ownMR.material = MaterialHandler.instance.epischMat;
				break;
			case ItemSO.Qualität.legendär:
				ownMR.material = MaterialHandler.instance.legendärMat;
				break;
		}
    }

	private bool refreshActive()
    {
		bool result = targets.Count > 0;
		gameObject.SetActive(result);
		ownMR.gameObject.SetActive(result);
		return result;
	}

	#endregion

}
/*
	#region Variables
	public GameObject itemPoint;
	public float rotationSpeed;

	private bool itemvorhanden;
	public MeshRenderer mr;
	#endregion
	
	#region Unity Methods
	
    void Start()
    {
		onItemPointChanged();
    }

    void Update()
    {
        if(itemvorhanden)
        {
			itemPoint.transform.rotation = Quaternion.Euler(0f, itemPoint.transform.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
			Interactor i = other.gameObject.GetComponent<Interactor>();
			if(i != null)
            {
				i.collect(this);
            }
        }
    }

    #endregion

    #region Regular Methods
    public void onItemPointChanged()
    {
		refresh(hasActiveChild(itemPoint.transform));
		if(itemvorhanden)
        {
			PickUpInventoryItem ii = itemPoint.GetComponentInChildren<PickUpInventoryItem>();
			if (ii != null) {
				ItemSO i = ii.item;
				if (i != null)
				{
					switch (i.qualität)
					{
						case ItemSO.Qualität.gewöhnlich:
							mr.material = MaterialHandler.instance.gewöhnlichMat;
							break;
						case ItemSO.Qualität.hervorragend:
							mr.material = MaterialHandler.instance.hervorragendMat;
							break;
						case ItemSO.Qualität.episch:
							mr.material = MaterialHandler.instance.epischMat;
							break;
						case ItemSO.Qualität.legendär:
							mr.material = MaterialHandler.instance.legendärMat;
							break;
					}
				}
			}
        }
    }

	private void refresh(bool newEnabled)
    {
		itemvorhanden = newEnabled;
		gameObject.SetActive(newEnabled);
		itemPoint.SetActive(newEnabled);
	}

	private bool hasActiveChild(Transform t)
    {
		for (int i = 0; i < t.childCount; i++)
		{
			if (t.GetChild(i).gameObject.activeSelf == true)
			{
				return true;
			}
		}
		return false;
	}
#endregion*/
