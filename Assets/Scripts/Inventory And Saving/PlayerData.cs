using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Health;
    public int Hunger;
    public int Stamina;
    public int HealthMAX;
    public int HungerMAX;
    public int StaminaMAX;

    public float[] position;

    public string BootName;
    public int BootLevel;

    public string WeaponName;
    public int WeaponLevel;

    public string ArmourName;
    public int ArmourLevel;

    public int Strength;

    public int Fish;
    public int Wood;

    public float TimeOfNightorDay;
    public int DayCounter;
    public bool isDay;

    public bool BoatExists;

    public PlayerData (Player player)
    {
        Health = player.Health;
        Hunger = player.Hunger;
        Stamina = player.Stamina;
        HealthMAX = player.HealthMAX;
        HungerMAX = player.HungerMAX;
        StaminaMAX = player.StaminaMAX;

        BootName = player.BootName;
        BootLevel = player.BootLevel;
        WeaponName = player.WeaponName;
        WeaponLevel = player.WeaponLevel;
        ArmourName = player.ArmourName;
        ArmourLevel = player.ArmourLevel;

        Strength = player.Strength;

        Fish = player.Fish;
        Wood = player.Wood;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        TimeOfNightorDay = player.TimeOfNightorDay;
        DayCounter = player.DayCounter;
        isDay = player.isDay;

        BoatExists = player.BoatExists;
    }
}
