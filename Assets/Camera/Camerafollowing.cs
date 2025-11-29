using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollowing : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;

    void LateUpdate() // Smoother for cameras
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
