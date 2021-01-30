using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiggle : MonoBehaviour
{
    public float shake_intensity;
    public Vector3 originPosition;

    public bool isShaking = true;

    void Start()
    {
        originPosition = transform.position;
    }

    void Update()
    {
        if (isShaking)
        {
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
        }
    }
}
