using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript11c : MonoBehaviour
{
    public Transform target;
    

    void LateUpdate()
    {
        transform.position = target.position;
    }
}
