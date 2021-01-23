using UnityEngine;

public abstract class GunShootHandler<T> : AbstractShootHandler<T> where T : GunShootData 
{
    #region Variables
    #endregion

    #region Unity Methods

	#endregion
	
	#region Regular Methods
	protected void doOneShoot()
    {
		Ray ray =  weapon.playerObjects.getMainCamera().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, weapon.range, weapon.shootLayerMask))
        {
            if (Physics.Raycast(weapon.RayStartPoint.position, (weapon.RayStartPoint.position - hit.collider.gameObject.transform.position), out RaycastHit hit2, weapon.range, weapon.shootLayerMask))
            {
                AudioManager.instance.Play(weapon.shootAudioName);
                //weapon.psFirePoint.Play();
            }
        }
        else
        {

        }

    }
	#endregion
	
}
