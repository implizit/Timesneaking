using UnityEngine;

public class Collectable : MonoBehaviour
{
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
			Inventory i = other.gameObject.GetComponent<Inventory>();
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
			InventoryItem ii = itemPoint.GetComponentInChildren<InventoryItem>();
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
	#endregion

}
