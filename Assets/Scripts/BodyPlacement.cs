using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPlacement : MonoBehaviour
{
    [SerializeField]
    private Transform
        head,
        lHand,
        rHand;

    [SerializeField]
    private float
        headWeight,
        rHandWeight,
        lHandWeight;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, head.position - transform.position, Color.red);
        Debug.DrawRay(transform.position, lHand.position - transform.position, Color.blue);
        Debug.DrawRay(transform.position, rHand.position - transform.position, Color.blue);
        Debug.DrawRay(head.position, lHand.position - head.position, Color.green);
        Debug.DrawRay(head.position, rHand.position - head.position, Color.green);
        Debug.DrawRay(transform.position, transform.parent.parent.parent.position - transform.position, Color.cyan);
        float yScale = head.localPosition.y/2;
        transform.localScale = new Vector3(transform.localScale.x, yScale, transform.localScale.z);
        Vector3 newPos = 
            (
                NoYAxis(head.localPosition) * headWeight
                + NoYAxis(lHand.localPosition) * lHandWeight
                + NoYAxis(rHand.localPosition) * rHandWeight
            )
            / (headWeight + rHandWeight + lHandWeight) 
            + Vector3.up * yScale
            ;
        transform.localPosition = newPos;
    }

    private Vector3 NoYAxis (Vector3 original)
    {
        return new Vector3(original.x, 0, original.z);
    }
}
