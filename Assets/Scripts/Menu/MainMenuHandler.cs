using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public Button ContinueButton;
    public Player player;
    void Start()
    {
        if(SaveSystem.LoadPlayer() == null)
        {
            Color edit = new Color(0f, 0f, 0f, 0f);
            ContinueButton.GetComponent<Button>().interactable = false;
            ContinueButton.GetComponent<Button>().colors.normalColor.Equals(edit);
        }
    }
    
    public void MenuContinueGame()
    {
        LoadScene();
    }

    public void MenuNewGame()
    {
        player.SaveME();
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("OverWorld");
    }
}
