using UnityEngine;

public class Interactor : MonoBehaviour
{
	#region Variables
	public KeyCode keyCodeInteraction = KeyCode.E;
	public LayerMask InteractionMask;
	public float maxInteractionDistance = 10f;

    //public float InteractionDistanceRadius;

	[SerializeField] private Player player;
	InteractionPlayer interactionPlayer; 
	#endregion

	#region Unity Methods

	void Start()
    {
        if(player == null)
        {
			enabled = false;
        }
		else
        {
			interactionPlayer = new InteractionPlayer();
			interactionPlayer.collectAmountType = InteractionPlayer.CollectAmountType.all;
			interactionPlayer.player = player;
		}
    }

    void Update()
    {
		if(enabled)
        {
			if(Input.GetKey(keyCodeInteraction))
            {
				doInteraction();
            }
        }
		else
		{
			//die Frage ist, ob if(enabled) notwendig ist
			Debug.Log("if enabled ist notwendig");
		}
	}

	#endregion

	#region Regular Methods
	private void doInteraction()
	{
		Ray ray = player.getMainCamera().ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, maxInteractionDistance, InteractionMask))
		//if (Physics.SphereCast(ray, InteractionDistanceRadius, out hit, maxInteractionDistance, InteractionMask))
		{
			if (hit.distance <= maxInteractionDistance)
			{
				Interactable<InteractionPlayer, ItemHandler> i = hit.collider.gameObject.GetComponent<Interactable<InteractionPlayer, ItemHandler>>();
				interactWith(i);
			}
		}
	}

	public void interactWith(Interactable<InteractionPlayer, ItemHandler> i)
    {
		if (i != null)
		{
			i.interact(interactionPlayer);
		}
		/*else
		{
			collect(hit.collider.gameObject.GetComponent<CollectStation>());
		}*/
	}

	/*public void collect(CollectStation col)
	{
		if (col != null)
		{
			Interactable interactable = col.itemPoint.GetComponentInChildren<Interactable>();
			if (interactable != null)
			{
				interactable.interact(interactionEvent);
				col.onItemPointChanged();
			}
		}
	}*/
	#endregion

}
