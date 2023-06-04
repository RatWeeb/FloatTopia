using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(player.position, new Vector3(transform.position.x, player.position.y, transform.position.z)) > 30f)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        }
        
    }
}
