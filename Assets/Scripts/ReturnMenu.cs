using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMenu : MonoBehaviour
{
    public void OverWorldCanvasReturner()
    {

        Component[] LocationMenu = GameObject.FindObjectsOfType<CanvasGroup>();
        
        foreach (Component component in LocationMenu)
        {
            if(component.tag != "UI")
            {
                component.GetComponent<CanvasGroup>().alpha = 0f;
                component.GetComponent<CanvasGroup>().blocksRaycasts = false;

            }
        }
        gameObject.GetComponent<CanvasGroup>().alpha = 1f;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
