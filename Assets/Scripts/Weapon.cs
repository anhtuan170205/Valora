using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private int weaponDamage = 50;
    StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }
    private void Update()
    {
        if (starterAssetsInputs.shoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Health health = hit.collider.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("Hit " + hit.collider.name);
                health.Damage(weaponDamage); 
            }
            starterAssetsInputs.ShootInput(false);
        }
    }

}
