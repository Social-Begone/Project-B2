using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private GameObject player;
    public int HungerPerTimer = 1;
    public int HungerDamagePerTimer = 10;
    public int StaminaDamagePerTimer = 5;
    public int HealthRegen = 10;
    public float Timer = 20;
    private float _Timer;
    void Start()
    {
        _Timer = Timer;
        player = GameObject.FindGameObjectWithTag("Player");
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

            if (player.GetComponent<Player>().Stamina > 0 && player.GetComponent<Player>().Hunger > 0)
                player.GetComponent<Player>().HealthHandler(HealthRegen);

        }
    }
}
