using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.GetComponent<Player>().Fish <= 0)
            GameObject.FindGameObjectWithTag("CookFishButton").GetComponent<Button>().interactable = false;
        else
            GameObject.FindGameObjectWithTag("CookFishButton").GetComponent<Button>().interactable = true;

        if (player.GetComponent<Player>().BoatExists)
        {
            GameObject.FindGameObjectWithTag("SailButton").GetComponent<Button>().interactable = true;
            GameObject.FindGameObjectWithTag("BuildBoatButton").GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("SailButton").GetComponent<Button>().interactable = false;
            if (player.GetComponent<Player>().Wood >= 1000)
                GameObject.FindGameObjectWithTag("BuildBoatButton").GetComponent<Button>().interactable = true;
        }
            
    }
}
