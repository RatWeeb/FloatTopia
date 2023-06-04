using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Transform cloudsParent; 
    public Vector3 cloudMovementDirection = new Vector3(0f, 0f, -1f);
    public float cloudMovementSpeed = 1f; 
    public float offsetXSpeed = 0.5f; 

    public Material skyMaterial;
    private float currentOffsetX = 0f;
    public float cloudBoundary = -330f;

    void Start()
    {
    }

    void Update()
    {
        for (int i = 0; i < cloudsParent.childCount; i++)
        {
            Transform cloud = cloudsParent.GetChild(i);
            cloud.Translate(cloudMovementDirection * cloudMovementSpeed * Time.deltaTime);

            if (cloud.position.z < cloudBoundary) {
                Vector3 newPosition = cloud.position;
                newPosition.z = 300f;
                cloud.position = newPosition;
            }
        }
        

        // Update the X offset based on the time and speed
        currentOffsetX += offsetXSpeed * Time.deltaTime;

        // Clamp the offset value to the range [0, 1]
        currentOffsetX = Mathf.Repeat(currentOffsetX, 1f);

        // Update the material's offset property
        skyMaterial.mainTextureOffset = new Vector2(currentOffsetX, 0f);
    }
}
