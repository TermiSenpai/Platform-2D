using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed;

    private void FixedUpdate()
    {
        // Create new pos for camera
        Vector3 newPos = new Vector3(target.position.x, transform.position.y, -10f) ;
        // translate the camera with a smooth movement
        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
