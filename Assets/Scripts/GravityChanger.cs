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

    [SerializeField]
    private AudioSource audioSource;

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
            audioSource.Play(0);
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
            /* // Return the normal if the ray hits an object
             List<Vector3> directions = new List<Vector3>();
             directions.Add(Vector3.up);
             directions.Add(-Vector3.up);
             directions.Add(Vector3.forward);
             directions.Add(-Vector3.forward);
             directions.Add(Vector3.right);
             directions.Add(-Vector3.right);

             List<float> dots = new List<float>();
             for (int i = 0; i < directions.Count; i++)
                 {
                     dots.Add(Vector3.Dot(hitInfo.normal, directions[i]));
                     Debug.Log("Dot " + i + ": " +  Vector3.Dot(hitInfo.normal, directions[i]));
                 }
             List<float> unsortedDots = dots;
             dots.Sort();
             float topValue = dots[dots.Count - 1];
             Debug.Log("Top Value: " + topValue);
             unsortedDots.IndexOf(topValue);
             foreach (float dot in unsortedDots)
             {
                 Debug.Log(dot);
             }

             Vector3 newNormal = directions[unsortedDots.IndexOf(topValue)];

             Debug.Log(newNormal.ToString());*/

            Quaternion initialRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            // Get the Euler angles from the initial rotation
            Vector3 eulerAngles = initialRotation.eulerAngles;
            eulerAngles = new Vector3(Mathf.Round(eulerAngles.x / 90) * 90, Mathf.Round(eulerAngles.y / 90) * 90, Mathf.Round(eulerAngles.z / 90) * 90);

            // Output the Euler angles (optional)
            Debug.Log("Euler Angles: " + eulerAngles);

            // Convert Euler angles back to a Quaternion
            Quaternion rotation = Quaternion.Euler(eulerAngles);
            Vector3 newdirection = rotation * Vector3.up;

            return newdirection;
        }

        // Return null if the ray doesn't hit anything
        return null;
    }

}
