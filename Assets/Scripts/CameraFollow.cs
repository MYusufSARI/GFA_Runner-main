using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 offset = new Vector3(0, 2f, -7);

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
