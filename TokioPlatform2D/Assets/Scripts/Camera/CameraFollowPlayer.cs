using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;

    private void FixedUpdate()
    {
        // Create new pos for camera
        Vector3 newPos = new Vector3(target.position.x, transform.position.y, -10f) ;
        // translate the camera with a smooth movement
        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);               
    }
}
