
public class InteractionPlayer : Interaction
{
    public enum CollectAmountType { none, one, multi, all };

    public CollectAmountType collectAmountType = CollectAmountType.all;
    public int multiAmount = 2;

    public IPlayer player;
}
