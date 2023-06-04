using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ShipMovement playerMovement;

    private ParticleSystem ps;

    void Awake()
    {
        StartCoroutine(LateAwake());
    }

    IEnumerator LateAwake()
    {
        yield return null;
        playerMovement = GetComponentInParent<ShipMovement>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement != null)
        {
            if (playerMovement.isMoving)
            {
                    ps.Play();
            }
            else
            {
                ps.Stop();
            }
        }
    }
}
