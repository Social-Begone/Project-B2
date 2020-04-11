using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenHandler : MonoBehaviour
{
    private float Timer = 1f;
    void Update()
    {
        Timer -= Time.deltaTime;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Health = -1000;
        if (Timer > 0f)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SaveME();
        
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
