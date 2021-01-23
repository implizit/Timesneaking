using UnityEngine;

public abstract class AbstractShootHandler<T> where T : IWeaponShootData
{

    public T weapon { get => weapon; set => setWeapon(value); }

    public abstract void FireUpdate(bool shoot);

    public void setWeapon(T value)
    {
        weapon = value;
    }

}
