using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 150f;
    public float rotSpeed = 15f;
    public bool isMoving = false;
    public TMP_Text speedDisplay;

    private float horiInput;
    public AudioSource motor;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentSpeed);
        // get horizontal input
        horiInput = Input.GetAxisRaw("Horizontal");
        // this is a value from -1 to 1 (-1 is pressing a and 1 is pressing d, 0 is nothing)
        if (horiInput != 0)
        {
            transform.Rotate(new Vector3(0f, horiInput * rotSpeed, 0f) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) && transform.position.y < 1f)
        {
            currentSpeed += (moveSpeed/60) * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, moveSpeed / 20);
            speedDisplay.text = (int)currentSpeed + " Knots";
            isMoving = true;
            rb.AddForce(transform.forward * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.W))
        {
            
            isMoving = true;
            PlaySound(true);
        }
        else
        {
            currentSpeed -= (moveSpeed/20) * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, moveSpeed / 20);
            speedDisplay.text = (int)currentSpeed + " Knots";
            PlaySound(false);
            isMoving= false;
        }

        
        


    }

    void PlaySound(bool play)
    {
        if (motor != null)
        {
            if (play)
            {
                if(!motor.isPlaying)
                motor.Play();
            }
            else
            {
                motor.Stop();
            }
        }
    }

    public void SetSound(AudioSource sound)
    {
        motor = sound;
    }

}
