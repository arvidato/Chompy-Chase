using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraX : MonoBehaviour
{

    public Transform cameraTransform;

    void Update()
    {
        transform.position = new Vector3(cameraTransform.position.x, transform.position.y, transform.position.z);
    }
}
