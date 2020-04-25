using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public int Health = 100;
    public int Hunger = 100;
    public int Stamina = 100;
    public int HealthMAX = 100;
    public int HungerMAX = 100;
    public int StaminaMAX = 100;
    public int Fish = 0;
    public int Wood = 0;

    public string BootName = "Bare Foot";
    public int BootLevel = 1;

    public string WeaponName = "Knuckles";
    public int WeaponLevel = 1;

    public string ArmourName = "Rags";
    public int ArmourLevel = 1;

    public int Strength = 10;

    public float TimeOfNightorDay = 800;
    public int DayCounter = 1;
    public bool isDay = true;

    public bool BoatExists = false;

    public void SaveME()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadME()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Health = data.Health;
        Hunger = data.Hunger;
        Stamina = data.Stamina;
        HealthMAX = data.HealthMAX;
        HungerMAX = data.HungerMAX;
        StaminaMAX = data.StaminaMAX;

        BootName = data.BootName;
        BootLevel = data.BootLevel;
        WeaponName = data.WeaponName;
        WeaponLevel = data.WeaponLevel;
        ArmourName = data.ArmourName;
        ArmourLevel = data.ArmourLevel;

        Strength = data.Strength;

        Fish = data.Fish;
        Wood = data.Wood;

        TimeOfNightorDay = data.TimeOfNightorDay;
        DayCounter = data.DayCounter;
        isDay = data.isDay;

        BoatExists = data.BoatExists;
}

    public void StaminaHandler(int stamina)
    {
        if (Stamina < 0 && stamina > 0)
            Stamina = 0;
        Stamina += stamina;
        if (Stamina > StaminaMAX)
            Stamina = StaminaMAX;
    }

    public void HealthHandler(int health)
    {
        Health += health;
        if (Health < 0 && !SceneManager.GetActiveScene().name.Equals("DeathScreen"))
        {
            SceneManager.LoadScene("DeathScreen");
        }
        if (Health > HealthMAX)
            Health = HealthMAX;
    }
    public void HungerHandler(int hunger)
    {
        if (Hunger < 0 && hunger > 0)
            Hunger = 0;
        Hunger += hunger;
        if (Hunger > HungerMAX)
            Hunger = HungerMAX;
    }
    public void StaminaMAXHandler(int staminaMAX)
    {
        StaminaMAX += staminaMAX;
    }
    public void HealthMAXHandler(int healthMAX)
    {
        HealthMAX += healthMAX;
    }
    public void HungerMAXHandler(int hungerMAX)
    {
        HungerMAX += hungerMAX;
    }
    public void StrengthHandler(int strength)
    {
        Strength += strength;
    }
    public void FishHandler(int fish)
    {
        Fish += fish;
    }
    public void WoodHandler(int wood)
    {
        Wood += wood;
    }
    public void BoatHandler(bool boatExists)
    {
        BoatExists = boatExists;
    }
    public void BootHandler(string bootName, int level)
    {
        BootName = bootName;
        BootLevel = level;
        SaveME();
    }
    public void WeaponHandler(string weaponName, int level)
    {
        WeaponName = weaponName;
        WeaponLevel = level;
        SaveME();
    }
    public void ArmourHandler(string armourName, int level)
    {
        ArmourName = armourName;
        ArmourLevel = level;
        SaveME();
    }

    public void DayCounterHandler(int dayCounter)
    {
        DayCounter += dayCounter;
        if (DayCounter < 0)
        {
            DayCounter = 1;
        }
    }
}
