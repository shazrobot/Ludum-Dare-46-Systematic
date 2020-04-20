﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public SpotlightMouseFocus spotlightMechanism;
    public GameObject FireSource;
    public Rigidbody TemplateProjectile;
    public float ProjectileSpeed;

    public List<Rigidbody> Projectiles;
    public List<GameObject> CompatiblePeople;
    public List<GameObject> IncompatiblePeople;

    public int CitizensRequired;
    public Text NumRemainingIndicator;
    public Vector3 DropPoint;
    public int SpawnOffset;

    void Start()
    {
        UpdateObjective();
    }

    public void UpdateObjective()
    {
        NumRemainingIndicator.text = string.Format("{0}", (CitizensRequired - CompatiblePeople.Count));
    }
    private void FireCapsule(Vector3 Destination)
    {
        Rigidbody Projectile = Instantiate(TemplateProjectile) as Rigidbody;
        Projectile.transform.SetParent(TemplateProjectile.transform.parent, false);
        Projectile.transform.position = FireSource.transform.position;
        Projectile.gameObject.SetActive(true);
        Projectile.AddForce(ProjectileSpeed*(Destination - Projectile.transform.position));

        Projectiles.Add(Projectile);
    }

    public void DropCitizens()
    {
        int i = 0;
        foreach (GameObject Citizen in CompatiblePeople)
        {
            Citizen.transform.position = DropPoint+new Vector3(0, i* SpawnOffset, 0);
            Citizen.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Citizen.SetActive(true);
            i++;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (spotlightMechanism.Lock)
            {
                FireCapsule(spotlightMechanism.hit.transform.position);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Person")
        {
            if (collision.gameObject.GetComponent<PersonManager>().Netted)
            {
                collision.gameObject.GetComponent<PersonManager>().Collected();
                if (collision.gameObject.GetComponent<PersonManager>().Compatible)
                {
                    CompatiblePeople.Add(collision.gameObject);
                }
                UpdateObjective();
            }
        }

        if (collision.gameObject.name == "DumpButton")
        {
            DropCitizens();
        }
    }
}