using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leavebunker : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().LoadME();
    }
    public void LeaveBunker()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SaveME();
        SceneManager.LoadScene("OverWorld");
    }
}
