using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GravityChanger : MonoBehaviour
{

    private GravityManager gm;
    [SerializeField]
    private Transform shootTransform;
    [SerializeField]
    private LayerMask shootLayer;

    private void Awake()
    {
        gm = GameObject.Find("Gravity Manager").GetComponent<GravityManager>();
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Shoot);
    }

    public void Shoot(ActivateEventArgs args) 
    {
        //Debug.Log("Clicked Sooot");
        Vector3? normal = CastRayAndGetNormal(shootTransform.position, shootTransform.forward, 100.0f);
        if (normal.HasValue)
        {
            gm.globalGravity = normal.Value * -4.91f;
        }
    }

    public Vector3? CastRayAndGetNormal(Vector3 origin, Vector3 direction, float maxDistance)
    {
        RaycastHit hitInfo;

        // Cast the ray
        if (Physics.Raycast(origin, direction, out hitInfo, maxDistance, shootLayer))
        {
            // Return the normal if the ray hits an object
            return hitInfo.normal;
        }

        // Return null if the ray doesn't hit anything
        return null;
    }

}
