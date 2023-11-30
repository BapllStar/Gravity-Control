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

    [SerializeField]
    private PhysicalSlider slider;

    [SerializeField]
    private float
        fireRate,
        lastFireTime;

    private void Awake()
    {
        gm = GameObject.Find("Gravity Manager").GetComponent<GravityManager>();
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Shoot);
        slider.max = fireRate;
    }

    private void Update()
    {
        slider.value = Time.time - lastFireTime;
    }

    public void Shoot(ActivateEventArgs args) 
    {
        if(Time.time >= lastFireTime + fireRate)
        {
            lastFireTime = Time.time;
            //Debug.Log("Clicked Sooot");
            Vector3? normal = CastRayAndGetNormal(shootTransform.position, shootTransform.forward, 100.0f);
            if (normal.HasValue)
            {
                gm.globalGravity = normal.Value * -gm.globalGravity.magnitude;
            }
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
