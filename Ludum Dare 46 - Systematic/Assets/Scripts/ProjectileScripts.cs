using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScripts : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Person")
        {
            collision.gameObject.GetComponent<PersonManager>().Hit();
        }
    }

}
