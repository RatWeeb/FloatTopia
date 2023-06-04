using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    // change this for all child floaters (total number)
    public float floaterCount = 6f;
    public float waterDrag = 2f;
    public float waterAngularDrag =2f;
    public bool isFloater;


    public Rigidbody rb;


    void Start()
    {
        if (isFloater)
        {
            // set rigid body equal to the rigidbody on the object
            rb = GetComponentInParent<Rigidbody>();
        }

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        /*(if(rb == null)
        {
            // set rigid body equal to the rigidbody on the object
            rb = GetComponentInParent<Rigidbody>();
        }*/
        // apply gravity at floater position (divide it among them)
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveHeightAtX(transform.position.x);
        // if fell underwater
        if(transform.position.y < waveHeight)
        {
            // calculates how fast should accel up
            float displacementMulti = Mathf.Clamp01(waveHeight-transform.position.y / depthBeforeSubmerged) * displacementAmount;
            // add upwards force in acceleration
            rb.AddForceAtPosition(new Vector3(0f,Mathf.Abs(Physics.gravity.y)* displacementMulti, 0f),transform.position , ForceMode.Acceleration);
            rb.AddForce(displacementMulti * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMulti * -rb.angularVelocity *  waterAngularDrag* Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
