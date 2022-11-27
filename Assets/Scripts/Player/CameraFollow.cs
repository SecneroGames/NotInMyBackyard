using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform follow;

    void Update()
    {
        transform.position = new Vector3
        (follow.transform.position.x,follow.transform.position.y,follow.transform.position.z);
    }
}
