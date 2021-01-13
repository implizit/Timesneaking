using UnityEngine;

public class InventoryItem: Interactable
{
	#region Variables
	public ItemSO item;
    #endregion

    #region Regular Methods
    public override void interact()
    {
        base.interact();

        PickUp();
    }

    private void PickUp()
    {
        if (Inventory.instance.add(this))
        {
            gameObject.SetActive(false);
        }
    }
    #endregion

    #region Unity Methods

	
	#endregion
}
