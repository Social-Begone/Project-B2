using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [NonSerialized]
    public float SaveTime;

    // Player Stats
    public int Health, HealthMAX;
    
    public int Hunger, HungerMAX;
    
    public int Stamina, StaminaMAX;
    
    public int Strength;


    // Equipment
    public string BootName;
    public int BootLevel;

    public string WeaponName;
    public int WeaponLevel;

    public string ArmourName;
    public int ArmourLevel;

    // Miscellaneous Inventory
    public int Fish;
    public int Wood;


    // World Information
    public float[] Position;

    public float InGameTime;
    public int DayCount;
    public bool IsDay;

    public bool BoatExists;


    public PlayerData() {
        var home = GameObject.FindGameObjectWithTag("Home");
        Position = new[] { 
            home.transform.position.x,
            home.transform.position.y,
            home.transform.position.z
        };
    }


    public PlayerData (Player player)
    {
        SaveTime = Time.fixedTime;

        // Player Stats
        Health = player.Health;
        HealthMAX = player.HealthMAX;
        
        Hunger = player.Hunger;
        HungerMAX = player.HungerMAX;
        
        Stamina = player.Stamina;
        StaminaMAX = player.StaminaMAX;

        Strength = player.Strength;


        // Equipment
        BootName = player.BootName;
        BootLevel = player.BootLevel;
        
        WeaponName = player.WeaponName;
        WeaponLevel = player.WeaponLevel;
        
        ArmourName = player.ArmourName;
        ArmourLevel = player.ArmourLevel;


        // Miscellaneous Inventory
        Fish = player.Fish;
        Wood = player.Wood;


        // World Information
        Position = new[] {
            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z
        };

        InGameTime = player.TimeOfNightorDay;
        DayCount = player.DayCounter;
        IsDay = player.isDay;

        BoatExists = player.BoatExists;
    }

}
