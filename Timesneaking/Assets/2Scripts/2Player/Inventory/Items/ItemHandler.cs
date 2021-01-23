using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    #region Variables
    private ItemInterface itemInterface;
    #endregion

    #region Unity Methods	
	#endregion
	
	#region Regular Methods
	public void collectTo(InventoryBehaviour ib)
    {
        itemInterface = ItemInterface.factory_Item(ib);
        if (ib.add(itemInterface))
        {
            gameObject.SetActive(false);
        }
    }

    public ItemSO.Qualität GetQualität()
    {
        return ItemSO.Qualität.gewöhnlich;
    }
    #endregion

}
