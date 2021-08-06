using UnityEngine;
using System;

public enum FiringMode
{
    Single,
    FullAuto,
}

[Serializable]
public class GunData
{
    public string type;
    public string name;
    public Vector2 recoil;
    public float effectiveDistance;
    public float rateOfFire;
    public float timeBetweenFire;
    public float muzzleVelocity;
    public float ergonomics;
    public float reloadTime;

    public GameObject ammo;
    public int ammoPerFire;
    public int numberOfAmmoInMagazine;
    public int magazineSize;
    public int numberOfAmmo;
    public int maxiumOfAmmo;
}
