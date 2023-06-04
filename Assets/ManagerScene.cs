using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public bool showCursor = true;


    void Update()
    {
        if (!showCursor)
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                Cursor.lockState = CursorLockMode.None; // Set cursor to free
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; // Set cursor to free
            }
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
