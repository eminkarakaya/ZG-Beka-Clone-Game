using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public enum Tasks
{
    killZombies,
    move,
    destroyTower,
    plantBomb
}
public class GameManager : Singleton<GameManager>
{
    public Text killCountTxt;
    bool soundBool;
    public AudioClip helicopterSound;
    public List<AudioClip> startSounds;
    [HideInInspector] public int killCount;
    public float tahliyeSuresi;
    public Text tahliyeText;
    public GameObject winCanvas;
    public Image winCanvasPanel;
    public float endWaitTime;
    public int kazanilacakMalzeme;
    public int kazanilacakMetal;
    public float waveAralik;
    public List<GameObject> wave;
    int whichWave;
    int zombieCount;
    [Serializable] public class TaskClass : UnityEvent{}    
    public List<TaskClass> taskClasses;
    [SerializeField] private int _tempIndex;
    public int tempIndex
    {
        get => _tempIndex;
        set
        {
            if(value != 0)
            {
                _tempIndex = value;
            }
        }
    }
    [SerializeField] private int _index;
    public int index{
        get => _index;
        set
        {
            if(value == 0)
            {
                tempIndex = _index;
                _index = 0;
            }
            else
            {
                _tempIndex = value;
                _index = value;
            }
        }
    }
    void Start()
    {   
        Health.KillEvent += Death;
        AudioSource.PlayClipAtPoint(startSounds[UnityEngine.Random.Range(0,startSounds.Count)],Camera.main.transform.position);
        tahliyeText.gameObject.SetActive(false);
        winCanvasPanel = winCanvasPanel.GetComponent<Image>();
        // allZombiesArray = GameObject.FindObjectsOfType<Enemy>();
        // for (int i = 0; i < allZombiesArray.Length; i++)
        // {
        //     allZombiesList.Add(allZombiesArray[i]);
        // }
        StartCoroutine(Create());
    }
    void Update()
    {
        taskClasses[index].Invoke();
    }
    public void Death()
    {
        GameManager.Instance.killCount++;
        killCountTxt.text = GameManager.Instance.killCount.ToString();
    }
    public void CreateZombie(Vector3 pos, GameObject prefab)
    {
        var zombie = Instantiate(prefab,pos,Quaternion.identity);
        zombieCount--;
    }
    IEnumerator Create()
    {
        wave[whichWave].SetActive(true);
        for (int i = 0; i < wave[whichWave].transform.childCount; i++)
        {
            wave[whichWave].transform.GetChild(i).parent = null;
        }        
        if(whichWave < wave.Count-1)
        {
            whichWave++;
        }
        yield return new WaitForSeconds(waveAralik);
        StartCoroutine(Create());
    }
    public void EndGame()
    {
        winCanvas.SetActive(true);
        endWaitTime -= Time.deltaTime;
        if(endWaitTime <= 0)
            SceneManager.LoadScene(2);
    }
    public void Tahliye()
    {
        if(soundBool == false)
        {
            AudioSource.PlayClipAtPoint(helicopterSound,Camera.main.transform.position);
            soundBool = true;
        }

        tahliyeText.gameObject.SetActive(true);
        tahliyeSuresi -= Time.deltaTime;
        tahliyeText.text = "Tahliye Ediliyor .. " + tahliyeSuresi.ToString();
        if(tahliyeSuresi <= 0)
        {
            tahliyeText.gameObject.SetActive(false);
            EndGame();
        }
    }
}
