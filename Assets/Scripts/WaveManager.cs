using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    // stuff to simulate waves (change it soon using a sin wave (FOR NOW))
    public float amplitude = 0.2f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;
    public float heightOffset = -0.2f;

    private Transform player;

    // Update is called once per frame
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object");
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
        transform.position = new Vector3(player.position.x, 0, player.position.z);
    }
    // gives wave height at a given X value
    public float GetWaveHeightAtX(float x)
    {
        // y = sin(x/k)
          return (amplitude * Mathf.Sin(x/length + offset)) + heightOffset;
    }

}
