using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonManager : MonoBehaviour
{
    public MeshRenderer Visor;
    public Material IncompatibleColour;
    public Material CompatibleColour;
    public GameObject Net;
    public bool Netted = false;
    public bool Compatible;

    void Start()
    {
        Net.SetActive(false);
        Netted = false;
    }

    public void Hit()
    {
        Net.SetActive(true);
        Netted = true;
        if(Compatible)
        {
            Visor.material = CompatibleColour;
        }
        else
        {
            Visor.material = IncompatibleColour;
        }
        
    }

    public void Collected()
    {
        this.gameObject.SetActive(false);
    }
}
