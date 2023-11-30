using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalSlider : MonoBehaviour
{
    public float
        min,
        max,
        value;
    private Transform
        background,
        fill;

    private Vector3 initialScale;
    private void Awake()
    {
        background = transform.Find("Background");
        fill = transform.Find("Fill");
        initialScale = fill.localScale;
    }

    void Update()
    {
        value = Mathf.Clamp(value, min, max);
        float percentage = (value - min) / (max - min);
        fill.localScale = new Vector3(initialScale.x, initialScale.y * percentage, initialScale.z);
        fill.localPosition = new Vector3(0, 0, initialScale.z / 2 * percentage - initialScale.z / 2);
    }
}
