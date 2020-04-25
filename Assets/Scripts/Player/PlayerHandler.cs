using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    private GameObject player;
    public int HungerPerTimer = 1;
    public int StaminaPerTimer = 1;
    public int HungerDamagePerTimer = 10;
    public int StaminaDamagePerTimer = 5;
    public int HealthRegen = 10;
    public float Timer = 20;
    private float _Timer;

    private Text FishText;
    private Text HealthText;
    private Text StaminaText;
    private Text HungerText;
    void Start()
    {
        _Timer = Timer;
        player = GameObject.FindGameObjectWithTag("Player");

        FishText = GameObject.FindGameObjectWithTag("FishCounter").GetComponent<Text>();
        HealthText = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Text>();
        StaminaText = GameObject.FindGameObjectWithTag("PlayerStamina").GetComponent<Text>();
        HungerText = GameObject.FindGameObjectWithTag("PlayerHunger").GetComponent<Text>();
    }

    void Update()
    {
        _Timer -= Time.deltaTime;
        if(_Timer <= 0)
        {
            _Timer = Timer;

            if (player.GetComponent<Player>().Hunger > 0)
                player.GetComponent<Player>().HungerHandler(-HungerPerTimer);
            else
                player.GetComponent<Player>().HealthHandler(-HungerDamagePerTimer);


            if (player.GetComponent<Player>().Stamina < 0)
                player.GetComponent<Player>().HealthHandler(-StaminaDamagePerTimer);
            else
                player.GetComponent<Player>().StaminaHandler(-StaminaPerTimer);


            if (player.GetComponent<Player>().Stamina > 0 && player.GetComponent<Player>().Hunger > 0)
                player.GetComponent<Player>().HealthHandler(HealthRegen);

        }

        FishText.text = "Fish: " + player.GetComponent<Player>().Fish.ToString();
        HealthText.text = player.GetComponent<Player>().Health.ToString() + " HP";
        StaminaText.text = "ST: " + player.GetComponent<Player>().Stamina.ToString();
        HungerText.text = "HU: " + player.GetComponent<Player>().Hunger.ToString();

    }
}
