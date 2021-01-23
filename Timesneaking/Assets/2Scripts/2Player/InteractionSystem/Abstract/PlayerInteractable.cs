using UnityEngine;

// -> probably [RequireComponent(typeof(Collider))]
public abstract class PlayerInteractable<T, U> : Interactable<T, U> where T : InteractionPlayer
{
    public override void interact(T interaction)
    {
        switch (interaction.collectAmountType) {
            case InteractionPlayer.CollectAmountType.one:
                doInteractionWithTarget(interaction, mainTarget);
                break;
            case InteractionPlayer.CollectAmountType.multi:
                for (int i = 0; i < interaction.multiAmount; i++)
                {
                    doInteractionWithTarget(interaction, targets[i]);
                }
                break;
            case InteractionPlayer.CollectAmountType.all:
                foreach (U target in targets)
                {
                    doInteractionWithTarget(interaction, target);
                }
                break;
        }
    }
    public override void tryAutoSelectTargets() //todo -> ganze liste ermitteln
    {
        if (mainTarget == null)
        {
            mainTarget = GetComponent<U>();
            if (mainTarget == null)
            {
                mainTarget = GetComponentInChildren<U>();
            }
        }
    }

    public abstract void doInteractionWithTarget(T interaction, U target);
}
