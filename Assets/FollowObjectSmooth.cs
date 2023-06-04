using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectSmooth : MonoBehaviour
{
    public float speed = 2.5f;
    public float minDis;
    public Transform target;


    // Update is called once per frame
    void Update()
    {
        if (minDis < Vector3.Distance(target.position, new Vector3(transform.position.x, target.position.y, transform.position.z)))
        {
            Vector3 targetPos = target.position;
            float smooth = 1.0f - Mathf.Pow(0.5f, Time.deltaTime * speed);
            transform.position = Vector3.Lerp(transform.position, targetPos, smooth);

        }
    }
}
