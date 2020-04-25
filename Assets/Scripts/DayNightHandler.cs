using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightHandler : MonoBehaviour
{
    public int DayLength = 600;
    public int NightLength = 1200;
    private GameObject Timer;

    void Start()
    {
        Timer = GameObject.FindGameObjectWithTag("Player");
        GameObject.FindGameObjectWithTag("DayCounterText").GetComponent<Text>().text = ("DAY " + Timer.GetComponent<Player>().DayCounter);

        if (!Timer.GetComponent<Player>().isDay)
        {
            gameObject.GetComponentInParent<CanvasGroup>().alpha = 1f;
        }    
    }

    void Update()
    {
        Timer.GetComponent<Player>().TimeOfNightorDay -= Time.deltaTime;
        if(Timer.GetComponent<Player>().TimeOfNightorDay <= 0)
            if (Timer.GetComponent<Player>().isDay)
            {
                Timer.GetComponent<Player>().TimeOfNightorDay = NightLength;
                Timer.GetComponent<Player>().isDay = false;
                gameObject.GetComponentInParent<CanvasGroup>().alpha = 1f;
            }
            else
            {
                Timer.GetComponent<Player>().TimeOfNightorDay = DayLength;
                Timer.GetComponent<Player>().isDay = true;
                Timer.GetComponent<Player>().DayCounterHandler(1);
                GameObject.FindGameObjectWithTag("DayCounterText").GetComponent<Text>().text = ("DAY " + Timer.GetComponent<Player>().DayCounter);
                gameObject.GetComponentInParent<CanvasGroup>().alpha = 0f;
            }
    }
}
