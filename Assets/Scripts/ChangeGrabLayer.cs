using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGrabLayer : MonoBehaviour
{
    [SerializeField]
    private LayerMask
        grabbable,
        grabbed;

    public void Grabable()
    {
        int layerIndex = LayerMaskToLayerIndex(grabbable);
        //Debug.Log("Layer index for grabable: " + layerIndex);
        gameObject.layer = layerIndex;
    }

    public void Grabbed()
    {
        int layerIndex = LayerMaskToLayerIndex(grabbed);
        //Debug.Log("Layer index for grabbed: " + layerIndex);
        gameObject.layer = layerIndex;
    }

    private static int LayerMaskToLayerIndex(LayerMask layerMask)
    {
        int layerIndex = 0;
        int layer = layerMask.value;
        while (layer > 1)
        {
            layer = layer >> 1;
            layerIndex++;
        }
        return layerIndex;
    }
}
