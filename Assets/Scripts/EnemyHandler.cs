using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHandler : MonoBehaviour
{
    private Text PlayerCurrentPos;

    public int EncounterMax;
    public int EncounterMin;
    private float Timer;

    void Start()
    {
        Timer = Random.Range(EncounterMin, EncounterMax);
        PlayerCurrentPos = GameObject.FindGameObjectWithTag("PlayerPosText").GetComponent<Text>();
    }

    void Update()
    {
        if (PlayerCurrentPos.text == "Nowhere")
            Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            GameObject.FindObjectOfType<Player>().SaveME();
            SceneManager.LoadScene("EnemyEncounter");
            Timer = Random.Range(EncounterMin, EncounterMax);
        }
    }
}
