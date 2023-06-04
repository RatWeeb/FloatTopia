using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class PickerManager : MonoBehaviour
{
    public TMP_Text displayText;
    public TMP_Text statsText;
    public string[] boatNames;
    [TextArea(15, 20)]
    public string[] boatStats;
    public RawImage displayImage;
    public Texture[] images;
    
    public AudioSource startSound;

    private int currentIndex;
    private GameObject ChoosePanel;
    private StartGameManager startGame;
    private ManagerScene manageScene;

    // Update is called once per frame
    void Start()
    {
        startGame = GameObject.Find("GameManager").GetComponent<StartGameManager>();
        manageScene = GameObject.Find("GameManager").GetComponent<ManagerScene>();
        ChoosePanel = GameObject.Find("ChoosePanel");
        UpdateValues();
    }

    public void Traverse(bool forward)
    {
        if (forward)
        {
            // move forward if can
            if(currentIndex < boatNames.Length - 1)
            {
                currentIndex++;
                UpdateValues();
            }
        }
        else
        {
            // move back if can
            if (currentIndex > 0)
            {
                currentIndex--;
                UpdateValues();
            }
        }
    }

    public void UpdateValues()
    {
        displayImage.texture = images[currentIndex];
        displayText.text = boatNames[currentIndex];
        statsText.text = boatStats[currentIndex];
    }

    public void Select()
    {
        startGame.ChooseBoat(currentIndex);
        ChoosePanel.SetActive(false);
        manageScene.showCursor = false;
    }

}
