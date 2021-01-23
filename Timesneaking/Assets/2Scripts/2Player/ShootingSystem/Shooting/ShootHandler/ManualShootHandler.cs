using UnityEngine;

public class ManualShootHandler<T> : GunShootHandler<T> where T : GunShootData
{
    private float timeSinceLastShoot = 0f;
    private bool wasShooting;
    public override void FireUpdate(bool shoot)
    {
        if (timeSinceLastShoot <= weapon.minTimeBtw2Shoots)
        {
            timeSinceLastShoot += Time.deltaTime;
        }
        if (shoot && !wasShooting && timeSinceLastShoot >= weapon.minTimeBtw2Shoots)
        {
            timeSinceLastShoot = 0f;
            doOneShoot();
        }

        wasShooting = shoot;
    }
}
