using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubEvent : MonoBehaviour
{
    private int DidAction = 0;
    public GameObject BoatPreFab;
    public Transform HarbourFirePoint;
    public void DoActionAt(string marker)
    {

        var _Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (marker == "Home")
        {
            DidAction = 34;
        }
        if (marker == "CookFish")
        {
            if (_Player.Fish > 0)
            {
                DidAction = -5;
                _Player.HungerHandler(40);
                _Player.FishHandler(-1);
            }
        }
        if (marker == "Fishing")
        {
            if (_Player.Stamina > 0)
            {
                _Player.FishHandler(1);
                DidAction = -20;
            }
        }
        if (marker == "Woods")
        {
            if (_Player.Stamina > 0)
            {
                _Player.WoodHandler(5);
                DidAction = -20;
            }
        }
        if (marker == "Harbour")
        {
            if (_Player.BoatExists)
            {
                Transform finder = GameObject.FindGameObjectWithTag("RadioTowerBoat").transform;

                var boat = Instantiate(BoatPreFab, HarbourFirePoint.position, HarbourFirePoint.rotation);
                boat.GetComponent<BoatMovement>().target = finder.position;


                DidAction = -20;
            }
        }
        if (marker == "HarbourBuildBoat")
        {
            if (_Player.Wood >= 1000)
            {
                _Player.WoodHandler(-1000);
                _Player.BoatHandler(true);
                DidAction = -140;
            }
        }
        if (marker == "Bunker")
        {
            _Player.SaveME();
            SceneManager.LoadScene("Bunker");
        }
        if (DidAction != 0)
        {
            _Player.StaminaHandler(DidAction);
            DidAction = 0;
        }
        if (marker == "Nowhere")
        {
            GameObject.FindGameObjectWithTag("CanvasOverWorld").GetComponent<ReturnMenu>().OverWorldCanvasReturner();
        }
    }
}
