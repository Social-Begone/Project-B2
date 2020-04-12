using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public bool isPlayerTurn = true;
    public float Timer = 3f;
    private float _Timer;

    private int EnemyHealth;
    private int EnemyArmour;

    private int PlayerArmour;

    void Start()
    {
        _Timer = Timer;
        gameObject.GetComponent<Player>().LoadME();
        Vector3 keepPos = new Vector3(0f,0f,0f);
        keepPos.x = SaveSystem.LoadPlayer().position[0];
        keepPos.y = SaveSystem.LoadPlayer().position[1];
        keepPos.z = SaveSystem.LoadPlayer().position[2];

        transform.position = keepPos;

        GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Text>().text = (gameObject.GetComponent<Player>().Health.ToString() + " HP");
        GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<Text>().text = gameObject.GetComponent<Player>().WeaponName;
        GameObject.FindGameObjectWithTag("PlayerArmour").GetComponent<Text>().text = gameObject.GetComponent<Player>().ArmourName;
        GameObject.FindGameObjectWithTag("PlayerWeaponStat").GetComponent<Text>().text = gameObject.GetComponent<Player>().WeaponLevel.ToString();
        GameObject.FindGameObjectWithTag("PlayerArmourStat").GetComponent<Text>().text = gameObject.GetComponent<Player>().ArmourLevel.ToString();

        int PlayerArmour = gameObject.GetComponent<Player>().ArmourLevel;
    }
    void Update()
    {
        _Timer -= Time.deltaTime;

        if(_Timer <= 0)
        {
            if(isPlayerTurn)
            {
                isPlayerTurn = false;
                EnemyHealth = int.Parse(GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<Text>().text.TrimEnd(' ', 'H', 'P'));
                EnemyArmour = int.Parse(GameObject.FindGameObjectWithTag("EnemyArmourStat").GetComponent<Text>().text);

                if (EnemyArmour > 0)
                {
                    EnemyArmour -= gameObject.GetComponent<Player>().WeaponLevel * Random.Range(1, 12);
                    if (EnemyArmour < 0)
                    {
                        EnemyHealth += EnemyArmour;
                        EnemyArmour = 0;
                    }
                }
                else
                {
                    EnemyHealth -= gameObject.GetComponent<Player>().WeaponLevel * Random.Range(1, 12);
                }

                if (EnemyHealth <= 0)
                {
                    gameObject.GetComponent<Player>().SaveME();
                    SceneManager.LoadScene("OverWorld");
                }
                GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<Text>().text = EnemyHealth.ToString() + " HP";
                GameObject.FindGameObjectWithTag("EnemyArmourStat").GetComponent<Text>().text = EnemyArmour.ToString();

            }
            else
            {
                isPlayerTurn = true;

                if (PlayerArmour > 0)
                {
                    PlayerArmour += int.Parse(GameObject.FindGameObjectWithTag("EnemyWeaponStat").GetComponent<Text>().text) * Random.Range(0, 6);
                    if (PlayerArmour < 0)
                    {
                        gameObject.GetComponent<Player>().HealthHandler(-PlayerArmour);
                        gameObject.GetComponent<Player>().SaveME();
                        PlayerArmour = 0;
                    }
                }
                else
                {
                    gameObject.GetComponent<Player>().HealthHandler(-(int.Parse(GameObject.FindGameObjectWithTag("EnemyWeaponStat").GetComponent<Text>().text) * Random.Range(0, 6)));
                    gameObject.GetComponent<Player>().SaveME();
                }

                GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Text>().text = gameObject.GetComponent<Player>().Health.ToString() + " HP";
                GameObject.FindGameObjectWithTag("PlayerArmourStat").GetComponent<Text>().text = PlayerArmour.ToString();
            }
            _Timer = Timer;
        }
    }
}
