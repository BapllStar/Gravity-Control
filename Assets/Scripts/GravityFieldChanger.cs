using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFieldChanger : MonoBehaviour
{
    [SerializeField]
    private Vector3 gravityChange;
    private GravityManager gm;

    private void Awake()
    {
        gm = GameObject.Find("Gravity Manager").GetComponent<GravityManager>();
    }

        private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gm.globalGravity = gravityChange;
        }
    }


}
