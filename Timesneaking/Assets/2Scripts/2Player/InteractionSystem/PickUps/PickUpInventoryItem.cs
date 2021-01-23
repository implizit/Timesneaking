using UnityEngine;

public class PickUpInventoryItem<T, U> : PlayerInteractable<T, U> where T: InteractionPlayer where U : ItemHandler
{
    //public ItemSO item;


    /*public override void interact(T interaction)
    {
        tryAutoSelectTarget();
        if(mainTarget != null)
        {
            mainTarget.collect(interaction.player.getInventory());
        }
    }*/

    public override void doInteractionWithTarget(T interaction, U target)
    {
        target.collectTo(interaction.player.getInventory());
    }
}
