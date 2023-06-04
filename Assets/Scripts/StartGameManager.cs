using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    public GameObject[] boatPrefabs;
    public float[] boatSpeed;
    public float[] boatTurnSpeed;

    private GameObject player;
    private int[] wrongRotIndexes = new int[] { 2, 3, 4 };

    // Update is called once per frame
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    public void ChooseBoat(int index)
    {
        // spawn things
        GameObject boat = Instantiate(boatPrefabs[index], player.transform.position, player.transform.rotation);
        boat.transform.parent = player.transform;
        // check if has wrong rot
        for(int i = 0; i < wrongRotIndexes.Length; i++)
        {
            if (wrongRotIndexes[i] == index)
            {
                boat.transform.Rotate(new Vector3(0f, 90f, 0f));
                break;
            }
        }
        // transfer data speed onto player
        ShipMovement sM = player.GetComponent<ShipMovement>();
        sM.moveSpeed = boatSpeed[index];
        sM.rotSpeed = boatTurnSpeed[index];
        sM.SetSound(player.GetComponentInChildren<AudioSource>());

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;

    }

}
