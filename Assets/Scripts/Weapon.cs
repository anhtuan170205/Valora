using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
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
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit: " + hit.collider.name);
            starterAssetsInputs.ShootInput(false);
        }
    }

}
