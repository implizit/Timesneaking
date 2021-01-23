using UnityEngine;

public class AutomaticShootHandler<T> : GunShootHandler<T> where T : GunShootData
{
    private float timeSinceLastShoot = 0f;

    public override void FireUpdate(bool shoot)
    {
        if(timeSinceLastShoot <= weapon.minTimeBtw2Shoots)
        {
            timeSinceLastShoot += Time.deltaTime;
        }
        if (shoot && timeSinceLastShoot >= weapon.minTimeBtw2Shoots)
        {
            timeSinceLastShoot = 0f;
            doOneShoot();
        }
    }
}
