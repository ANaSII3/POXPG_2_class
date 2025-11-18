using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM3 : MonoBehaviour
{
    public Transform target;
    private float smoothTime = 0.2f;
    private float lookAheadDistance = 2f;

    private Vector3 velocity = Vector3.zero;


    void LateUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        Vector3 targetPos = target.position + new Vector3(direction * lookAheadDistance, 0, -10);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
