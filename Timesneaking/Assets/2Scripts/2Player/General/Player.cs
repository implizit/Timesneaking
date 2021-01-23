using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public Camera mainCamera;
    public InventoryBehaviour inventory;
    public Schnellzugriff schnellzugriff;
    public Camera getMainCamera()
    {
        return mainCamera;
    }

    public InventoryBehaviour getInventory()
    {                             
        return inventory;
    }

    public Schnellzugriff GetSchnellzugriff()
    {
        return schnellzugriff;
    }
}
