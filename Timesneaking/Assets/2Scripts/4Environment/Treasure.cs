using UnityEngine;

public class Treasure<T> : PlayerInteractable<T, Object> where T : InteractionPlayer
{
	public enum OpenCloseState { open, closed }
	#region Variables
	public Animator anim;
	public bool recloseable = false;
	public float openclosetime = 10f;
	public UnityEngine.Events.UnityEvent onOpen;
	public UnityEngine.Events.UnityEvent onClose;

	private OpenCloseState state = OpenCloseState.closed;
	private bool isOpeningClosing = false;

	#endregion

	#region Unity Methods


	#endregion

	#region Regular Methods
	public override void interact(T ev) 
	{
		if (!isOpeningClosing) {
			switch (state)
			{
				case OpenCloseState.open:
					if (recloseable)
					{
						onClose.Invoke();
						toggleState();
					}
					break;
				case OpenCloseState.closed:
					onOpen.Invoke();
					toggleState();
					break;
			}
		}
    }

	private void toggleState()
    {
		state = (state == OpenCloseState.open ? OpenCloseState.closed : OpenCloseState.open);
		isOpeningClosing = true;
		Invoke("isOpeningClosingCallback", openclosetime);
	}

	public void isOpeningClosingCallback()
    {
		isOpeningClosing = false;
	}

	public void defaultOpen()
    {
		anim.Play("Open");
	}

	public void defaultClose()
    {
		anim.Play("Close");
	}

    public override void doInteractionWithTarget(T interaction, Object target)
    {
		//interact wird überschrieben
	}
	#endregion

}
