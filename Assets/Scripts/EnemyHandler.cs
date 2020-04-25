using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHandler : MonoBehaviour
{
    private Text PlayerCurrentPos;
    private Player player;

    public int EncounterMax;
    public int EncounterMin;
    private float Timer;

    void Start()
    {
        Timer = Random.Range(EncounterMin, EncounterMax);
        PlayerCurrentPos = GameObject.FindGameObjectWithTag("PlayerPosText").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (PlayerCurrentPos.text == "Nowhere")
            if (player.isDay)
                Timer -= Time.deltaTime;
            else
                Timer -= Time.deltaTime * 3;
        if(Timer <= 0)
        {
            GameObject.FindObjectOfType<Player>().SaveME();
            SceneManager.LoadScene("EnemyEncounter");
            Timer = Random.Range(EncounterMin, EncounterMax);
        }
    }
}
