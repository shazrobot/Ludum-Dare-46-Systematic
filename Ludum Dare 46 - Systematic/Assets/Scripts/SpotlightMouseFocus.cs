using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpotlightMouseFocus : MonoBehaviour
{
    public Light spotlight;
    public Camera Camera;
    public Ray ray;
    public RaycastHit hit;
    public Color regularColour;
    public Color IncompatibleColour;
    public Color CompatibleColour;
    public Material TargetingMaterial;
    public bool Lock;


    // Update is called once per frame
    void FixedUpdate()
    {
        Lock = false;
        TargetingMaterial.DisableKeyword("_EMISSION");
        Color SpotColour = regularColour;
        Vector3 WorldPoint = Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000));

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            WorldPoint = hit.point;
            //Debug.Log(hit.collider.name);
            if (hit.collider.name == "Person")
            {
                WorldPoint = hit.transform.position;
                if (hit.collider.gameObject.GetComponent<PersonManager>().Compatible)
                {
                    FindObjectOfType<SoundManager>().Play("Positive");
                    SpotColour = CompatibleColour;
                    TargetingMaterial.EnableKeyword("_EMISSION");
                }
                else
                {
                    FindObjectOfType<SoundManager>().Play("Negative");
                    SpotColour = IncompatibleColour;
                }
                Lock = true;
            }
        }

        Vector3 Direction = WorldPoint - spotlight.transform.position;
        //Debug.Log(WorldPoint);

        spotlight.transform.rotation = Quaternion.LookRotation(Direction);
        spotlight.color = SpotColour;

        
    }
}
