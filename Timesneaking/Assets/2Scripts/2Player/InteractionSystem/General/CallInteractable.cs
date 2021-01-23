using UnityEngine;

public class CallInteractable<T, U> : Interactable<T, U> where T : Interaction
{
	public Interactable<T, U> other;

    public override void interact(T ev)
    {
        other.interact(ev);
    }

    public override void tryAutoSelectTargets()
    {
        //interact wird überschrieben
    }
}
