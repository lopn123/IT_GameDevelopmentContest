using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraMove : MonoBehaviour
{
    private Vector3 pos;
    private float speed = 0.5f;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;

        v.x += 10f * Mathf.Sin(Time.time * speed);

        transform.position = v;
    }
}
