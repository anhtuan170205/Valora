using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private int weaponDamage = 50;
    StarterAssetsInputs starterAssetsInputs;
    private const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Start()
    {
        muzzleFlash.Stop();
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
        animator.Play(SHOOT_STRING,0,0f);
        starterAssetsInputs.shoot = false;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Health health = hit.collider.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("Hit " + hit.collider.name);
                health.Damage(weaponDamage); 
            }
        }
    }

}
