using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class MenuManager : Singleton<MenuManager>
{
    public Text altinText;
    public Text malzemeText;
    public Text metalText;
    [HideInInspector]public int altin;
    [HideInInspector]public int malzeme;
    [HideInInspector]public int metal;

    void Start()
    {
        altinText.text = PlayerPrefs.GetInt("Altin").ToString();
        malzemeText.text = PlayerPrefs.GetInt("Malzeme").ToString();
    }
    public void SetAltin(int x)
    {
        altin += x;
        PlayerPrefs.SetInt("Altin" , altin);
        altinText.text = altin.ToString();
    }
    public void SetMalzeme(int x)
    {
        malzeme += x;
        PlayerPrefs.SetInt("Malzeme" , malzeme);
        malzemeText.text = malzeme.ToString();
    }
    public void SetMetal(int x)
    {
        altin += x;
        PlayerPrefs.SetInt("Metal" , metal);
        metalText.text = metal.ToString();
    }
    public void AttackButton()
    {
        SceneManager.LoadScene(1);
    }

}
