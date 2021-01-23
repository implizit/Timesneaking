using UnityEngine;

public class GunShootData : IWeaponShootData
{
	public IPlayer playerObjects;

	public Transform RayStartPoint;
	public float range = 500;
	public LayerMask shootLayerMask;

	public string shootAudioName = "Shoot";
	public ParticleSystem psFirePoint;
	public ParticleSystem psImpact;

	public int damage = 1;
	public float minTimeBtw2Shoots = 1000f;
}
