using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable<T, U> : MonoBehaviour where T : Interaction
{
    public List<U> targets /*{ get; private set; }*/ = new List<U>();
    public U mainTarget { get => mainTarget; set => setMainTarget(value); }

    public abstract void interact(T interaction);
    public abstract void tryAutoSelectTargets();

    public void setMainTarget(U value)
    {
        mainTarget = value;
    }

    public virtual void refresh()
    {
        repairData();
        tryAutoSelectTargets();
        repairData();
    }

    public virtual void repairData()
    {
        if(mainTarget != null && targets.Count < 1)
        {
            targets.Add(mainTarget);
        }
        if(mainTarget == null && targets.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if(targets[i] != null)
                {
                    mainTarget = targets[i];
                    break;
                }
            }
        }
    }

}
