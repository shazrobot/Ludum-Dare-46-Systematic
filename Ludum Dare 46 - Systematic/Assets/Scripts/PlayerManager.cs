using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public SpotlightMouseFocus spotlightMechanism;
    public GameObject FireSource;
    public Rigidbody TemplateProjectile;
    public float ProjectileSpeed;

    private void FireCapsule(Vector3 Destination)
    {
        Rigidbody Projectile = Instantiate(TemplateProjectile) as Rigidbody;
        Projectile.transform.SetParent(TemplateProjectile.transform.parent, false);
        Projectile.transform.position = FireSource.transform.position;
        Projectile.gameObject.SetActive(true);
        Projectile.AddForce(ProjectileSpeed*(Destination - Projectile.transform.position));

        //Destination
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            if (spotlightMechanism.Lock)
            {
                Debug.Log("Fire");
                FireCapsule(spotlightMechanism.hit.transform.position);
            }
        }
    }
}
