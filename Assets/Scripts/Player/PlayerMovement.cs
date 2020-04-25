using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int MoveSpeed = 20;
    public Vector3 target;

    private string CurrentLocation = "Nowhere";
    private string targetLocation = "Nowhere";
    private bool ArriveOnce = true;
    private GameObject HubEvent;

    private GameObject OverWorldMenu;
    private GameObject LocationMenu;

    void Start()
    {
        gameObject.GetComponent<Player>().LoadME();
        MoveSpeed = 20 + 2 * gameObject.GetComponent<Player>().BootLevel;
        gameObject.GetComponent<Player>().HealthHandler(0);
        target.x = SaveSystem.LoadPlayer().position[0];
        target.y = SaveSystem.LoadPlayer().position[1];
        target.z = SaveSystem.LoadPlayer().position[2];
        transform.position = target;

        CurrentLocation = WhereAmI();

        GameObject.FindGameObjectWithTag("PlayerPosText").GetComponent<Text>().text = CurrentLocation;

        HubEvent = GameObject.FindGameObjectWithTag("MapMarkerHandler");

        OverWorldMenu = GameObject.FindGameObjectWithTag("CanvasOverWorld");
        OverWorldMenu.GetComponent<CanvasGroup>().alpha = 1f;
        OverWorldMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Update()
    {
        float step = MoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        CurrentLocation = WhereAmI();
        GameObject.FindGameObjectWithTag("PlayerPosText").GetComponent<Text>().text = CurrentLocation;

        if (CurrentLocation == targetLocation && ArriveOnce)
        {
            ArriveOnce = false;

            GameObject[] places = GameObject.FindGameObjectsWithTag(CurrentLocation);
            foreach (GameObject _places in places)
            {
                if (_places.GetComponent<Canvas>() != null && _places.tag != "UI")
                {
                    OverWorldMenu = GameObject.FindGameObjectWithTag("CanvasOverWorld");
                    OverWorldMenu.GetComponent<CanvasGroup>().alpha = 0f;
                    OverWorldMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    LocationMenu = _places;
                    LocationMenu.GetComponent<CanvasGroup>().alpha = 1f;
                    LocationMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }
        }
    }

    public void WalkHere(string Tag)
    {
        targetLocation = Tag;
        ArriveOnce = true;

        ThisIsAPlace[] finder = FindObjectsOfType<ThisIsAPlace>();
        
        foreach (ThisIsAPlace aPlace in finder)
        {
            if (aPlace.tag == Tag)
            {
                target = aPlace.GetComponent<RectTransform>().position;
            }
        }
    }

    public string WhereAmI()
    {
        string HereIAm = "Nowhere";
        ThisIsAPlace[] finder = FindObjectsOfType<ThisIsAPlace>();

        foreach (ThisIsAPlace _finder in finder)
        {
            var finder2 = _finder.GetComponent<RectTransform>();
            if (finder2.position.y > transform.position.y - 1)
                if (finder2.position.y < transform.position.y + 1)
                    if (finder2.position.x > transform.position.x - 1)
                        if (finder2.position.x < transform.position.x + 1)
                            if (finder2.position == transform.position)
                                    HereIAm = _finder.tag;
        }
        return HereIAm;
    }
}