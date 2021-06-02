﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject objLight;
    public GameObject ramdomSkill;
    public Enemy[] enemys;

    [Header("是否顯示隨機技能")]
    public bool autoShowSkill;
    [Header("是否自動開門")]
    public bool autoOpenDoor;
    [Header("復活介面")]
    public GameObject panelRevival;
    [Header("主選單")]
    public GameObject mainMenu;

    [Header("關卡是否生大王")]
    public  bool insBoss ;
    [Header("關卡6是否通關")]
    public static bool bl_6 = false;
    [Header("關卡11是否通關")]
    public static bool bl_11 = false;
    [Header("關卡16是否通關")]
    public static bool bl_16 = false;

    public Player player;
    public Animator door;
    public Image imgCross;


    protected virtual void Start()
    {
        door = GameObject.Find("木頭門").GetComponent<Animator>();
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();

        player = FindObjectOfType<Player>();

        insBoss = false;

        if (autoShowSkill) ShowSkill();
        if (autoOpenDoor) Invoke("Opendoor", 6);
    }

    /// <summary>
    /// 是否通關
    /// </summary>
    protected virtual void IsPass()
    {
        enemys = FindObjectsOfType<Enemy>();

        if (enemys.Length == 0 && insBoss == false)
        {
            Pass();
            return;
        }
    }

    private void Update()
    {
        IsPass();
    }

    /// <summary>
    /// 下一關
    /// </summary>
    public IEnumerator NextLevel()
    {
        AsyncOperation async;

        if (SceneManager.GetActiveScene().name.Contains("魔王1"))
        {
            async = SceneManager.LoadSceneAsync(2);               // 切換場景到 主選單(關卡編號0)
            bl_6 = true;
        }
        else if (SceneManager.GetActiveScene().name.Contains("魔王2"))
        {
            async = SceneManager.LoadSceneAsync(2);
            bl_11 = true;
        }
        else if (SceneManager.GetActiveScene().name.Contains("魔王3"))
        {
            async = SceneManager.LoadSceneAsync(2);
            bl_16 = true;
        }
        else
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            async = SceneManager.LoadSceneAsync(index + 1);        // 切換場景到下一關(關卡編號+1)
        }

        async.allowSceneActivation = false;

        for (int i = 0; i < 100; i++)                              // 過場動畫
        {
            imgCross.color += new Color(1, 1, 1, 0.01f);
            yield return new WaitForSeconds(0.001f);
        }

        async.allowSceneActivation = true;
    }

    /// <summary>
    /// 顯示復活
    /// </summary>
    public IEnumerator ShowRevival()
    {
        panelRevival.SetActive(true);

        for (int i = 5; i > 0; i--)
        {
            panelRevival.transform.GetChild(1).GetComponent<Text>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    /// <summary>
    /// 關閉復活
    /// </summary>
    public void CloseRevival()
    {
        StopCoroutine(ShowRevival());
        panelRevival.SetActive(false);
    }

    /// <summary>
    /// 過關
    /// </summary>
    public void Pass()
    {
        Opendoor();

        Item[] coins = FindObjectsOfType<Item>();

        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].pass = true;
        }
    }

    public void ShowMenu()// 選單按鈕
    {
        Time.timeScale = 0;
        mainMenu.SetActive(true);
    }

    public void MainMenu()// 回主選單
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void ResumeGame() // 繼續遊戲
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowSkill() // 顯示抽技能
    {
        ramdomSkill.SetActive(true);
    }

    private void Opendoor() //開門
    {
        objLight.SetActive(true);
        door.SetTrigger("開門觸發");
    }

}
