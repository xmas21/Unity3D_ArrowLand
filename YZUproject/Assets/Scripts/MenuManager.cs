﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    #region 欄位
    [Header("玩家資料")]
    public PlayerDate data;
    [Header("購買攻擊力畫面")]
    public GameObject BuyPanelAttack;
    [Header("購買生命力畫面")]
    public GameObject BuyPanelHp;
    [Header("沒錢畫面")]
    public GameObject PanelNoMoney;
    [Header("選擇關卡畫面")]
    public GameObject chooseLevel;
    [Header("生命等級")]
    public Text hpLevel;
    [Header("攻擊力等級")]
    public Text attackLevel;
    [Header("關卡6按鈕")]
    public Button btn6;
    [Header("關卡11按鈕")]
    public Button btn11;
    [Header("關卡16按鈕")]
    public Button btn16;

    [Header("武器1畫面")]
    public GameObject weapon1;
    [Header("武器2畫面")]
    public GameObject weapon2;
    [Header("武器3畫面")]
    public GameObject weapon3;
    [Header("武器4畫面")]
    public GameObject weapon4;
    [Header("武器5畫面")]
    public GameObject weapon5;
    [Header("武器6畫面")]
    public GameObject weapon6;
    [Header("沒錢買武器畫面")]
    public GameObject Nomoney;


    [Header("武器2按鈕")]
    public Button btnwpn2;
    [Header("武器3按鈕")]
    public Button btnwpn3;
    [Header("武器4按鈕")]
    public Button btnwpn4;
    [Header("武器5按鈕")]
    public Button btnwpn5;
    [Header("武器6按鈕")]
    public Button btnwpn6;


    public Text coin1;
    public Text coin2;
    public Text coin3;
    public Text coin4;
    public Text jewel1;
    public Text jewel2;
    public Text jewel3;
    public Text jewel4;

    private Player player;


    int a = 1;
    int b = 1;
    #endregion



    private void Start()
    {
        player = FindObjectOfType<Player>();
        data.hp = data.hpMax;
        Updatedata();
        Allowbtn();
    }


    /// <summary>
    /// 切換場景
    /// </summary>
    public void LoadLevel()
    {
        data.hp = data.hpMax;
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// 鑽石買生命
    /// </summary>
    public void BuyHp()
    {
        data.hpMax += 500;
        data.hp = data.hpMax;
    }

    /// <summary>
    /// 鑽石買攻擊力
    /// </summary>
    public void BuyAtk()
    {
        data.attack += 50;
    }

    /// <summary>
    /// 金幣買生命
    /// </summary>
    public void BuyHP()
    {
        data.PlayerCoin -= 100;
        a++;
        data.hpMax += 50;
        hpLevel.text = "lv. " + a;
        data.hp = data.hpMax;
        NoShowPanelHP();
        Updatedata();
    }

    /// <summary>
    /// 金幣買攻擊力
    /// </summary>
    public void BuyATK()
    {
        data.PlayerCoin -= 100;
        b++;
        attackLevel.text = "lv. " + b;
        data.attack += 10;
        NoShowPanelATK();
        Updatedata();
    }

    /// <summary>
    /// 金幣買生命畫面
    /// </summary>
    public void ShowPanelHP()
    {

        if (data.PlayerCoin > 100)
        {
            BuyPanelHp.SetActive(true);
        }
        else
        {
            ShowPanelNoMoney();
        }

    }

    /// <summary>
    /// 金幣購買攻擊力畫面
    /// </summary>
    public void ShowPanelATK()
    {

        if (data.PlayerCoin > 100)
        {

            BuyPanelAttack.SetActive(true);
        }
        else
        {
            ShowPanelNoMoney();
        }

    }

    /// <summary>
    /// 沒錢畫面
    /// </summary>
    public void ShowPanelNoMoney()
    {
        PanelNoMoney.SetActive(true);
    }

    /// <summary>
    /// 關閉HP畫面
    /// </summary>
    public void NoShowPanelHP()
    {
        BuyPanelHp.SetActive(false);
    }

    /// <summary>
    /// 關閉攻擊力畫面
    /// </summary>
    public void NoShowPanelATK()
    {
        BuyPanelAttack.SetActive(false);
    }

    /// <summary>
    /// 關閉沒錢畫面
    /// </summary>
    public void NoShowPanelNoMoney()
    {
        PanelNoMoney.SetActive(false);
    }

    /// <summary>
    /// 更新資訊
    /// </summary>
    private void Updatedata()
    {
        coin1.text = data.PlayerCoin.ToString();
        coin2.text = data.PlayerCoin.ToString();
        coin3.text = data.PlayerCoin.ToString();
        coin4.text = data.PlayerCoin.ToString();
        jewel1.text = data.PlayerJewel.ToString();
        jewel2.text = data.PlayerJewel.ToString();
        jewel3.text = data.PlayerJewel.ToString();
        jewel4.text = data.PlayerJewel.ToString();
    }

    /// <summary>
    /// 選擇關卡
    /// </summary>
    public void LevelChoose()
    {
        chooseLevel.SetActive(true);
    }

    /// <summary>
    /// 關閉選擇關卡畫面
    /// </summary>
    public void NoShowLevelChoose()
    {
        chooseLevel.SetActive(false);
    }

    /// <summary>
    /// 關卡1按鈕
    /// </summary>
    public void Level1()
    {
        ButtonOfLevel(1);
    }

    /// <summary>
    /// 關卡7按鈕
    /// </summary>
    public void Level6()
    {
        ButtonOfLevel(7);
    }

    /// <summary>
    /// 關卡13按鈕
    /// </summary>
    public void Level11()
    {
        ButtonOfLevel(13);
    }

    /// <summary>
    /// 關卡19按鈕
    /// </summary>
    public void Level16()
    {
        ButtonOfLevel(19);
    }

    /// <summary>
    /// 關卡按鈕
    /// </summary>
    /// <param name="i">關卡號碼</param>
    private void ButtonOfLevel(int i)
    {
        AsyncOperation async;
        async = SceneManager.LoadSceneAsync(i);
        chooseLevel.SetActive(false);
    }

    /// <summary>
    /// 激活按鈕
    /// </summary>
    private void Allowbtn()
    {
        if (LevelManager.bl_6 == true)
        {
            btn6.interactable = true;
        }
        if (LevelManager.bl_11 == true)
        {
            btn11.interactable = true;
        }
        if (LevelManager.bl_16 == true)
        {
            btn16.interactable = true;
        }
    }

    /// <summary>
    /// 開啟武器1畫面
    /// </summary>
    public void ShowWeapon1()
    {
        weapon1.SetActive(true);
    }

    /// <summary>
    /// 開啟武器2畫面
    /// </summary>
    public void ShowWeapon2()
    {
        weapon2.SetActive(true);
    }

    /// <summary>
    /// 開啟武器3畫面
    /// </summary>
    public void ShowWeapon3()
    {
        weapon3.SetActive(true);
    }

    /// <summary>
    /// 開啟武器4畫面
    /// </summary>
    public void ShowWeapon4()
    {
        weapon4.SetActive(true);
    }

    /// <summary>
    /// 開啟武器5畫面
    /// </summary>
    public void ShowWeapon5()
    {
        weapon5.SetActive(true);
    }

    /// <summary>
    /// 開啟武器6畫面
    /// </summary>
    public void ShowWeapon6()
    {
        weapon6.SetActive(true);
    }

    /// <summary>
    /// 關閉武器1畫面
    /// </summary>
    public void NoShowWeapon1()
    {
        weapon1.SetActive(false);
    }

    /// <summary>
    /// 關閉武器2畫面
    /// </summary>
    public void NoShowWeapon2()
    {
        weapon2.SetActive(false);
    }

    /// <summary>
    /// 關閉武器3畫面
    /// </summary>
    public void NoShowWeapon3()
    {
        weapon3.SetActive(false);
    }

    /// <summary>
    /// 關閉武器4畫面
    /// </summary>
    public void NoShowWeapon4()
    {
        weapon4.SetActive(false);
    }

    /// <summary>
    /// 關閉武器5畫面
    /// </summary>
    public void NoShowWeapon5()
    {
        weapon5.SetActive(false);
    }

    /// <summary>
    /// 關閉武器6畫面
    /// </summary>
    public void NoShowWeapon6()
    {
        weapon6.SetActive(false);
    }

    /// <summary>
    /// 買武器2
    /// </summary>
    public void BuyWeapon2()
    {
        if (data.PlayerCoin > 500)
        {
            data.PlayerCoin -= 500;
            btnwpn2.interactable = true;
        }
        else
        {
            NoMoney();
        }
    }

    /// <summary>
    /// 買武器3
    /// </summary>
    public void BuyWeapon3()
    {
        if (data.PlayerCoin > 1000)
        {
            data.PlayerCoin -= 1000;
            btnwpn3.interactable = true;
        }
        else
        {
            NoMoney();
        }
    }

    /// <summary>
    /// 買武器4
    /// </summary>
    public void BuyWeapon4()
    {
        if (data.PlayerCoin > 1500)
        {
            data.PlayerCoin -= 1500;
            btnwpn4.interactable = true;
        }
        else
        {
            NoMoney();
        }
    }

    /// <summary>
    /// 買武器5
    /// </summary>
    public void BuyWeapon5()
    {
        if (data.PlayerCoin > 3000)
        {
            data.PlayerCoin -= 3000;
            btnwpn5.interactable = true;
        }
        else
        {
            NoMoney();
        }
    }

    /// <summary>
    /// 買武器6
    /// </summary>
    public void BuyWeapon6()
    {
        if (data.PlayerCoin > 5000)
        {
            data.PlayerCoin -= 5000;
            btnwpn6.interactable = true;
        }
        else
        {
            NoMoney();
        }
    }

    /// <summary>
    /// 沒錢買武器
    /// </summary>
    private void NoMoney()
    {
        Nomoney.SetActive(true);
    }

    /// <summary>
    /// 關閉沒錢買武器畫面
    /// </summary>
    public void NoShowNoMoney()
    {
        Nomoney.SetActive(false);
        NoShowWeapon1();
        NoShowWeapon2();
        NoShowWeapon3();
        NoShowWeapon4();
        NoShowWeapon5();
        NoShowWeapon6();
    }

    /// <summary>
    /// 使用武器1
    /// </summary>
    public void UseWeapon1()
    {
        GameObject weapon1 = Instantiate(Resources.Load("武器1", typeof(GameObject))) as GameObject;
    }

    /// <summary>
    /// 使用武器2
    /// </summary>
    public void UseWeapon2()
    {
        GameObject weapon1 = Instantiate(Resources.Load("武器2", typeof(GameObject))) as GameObject;
    }

    /// <summary>
    /// 使用武器3
    /// </summary>
    public void UseWeapon3()
    {
        GameObject weapon1 = Instantiate(Resources.Load("武器3", typeof(GameObject))) as GameObject;
    }

    /// <summary>
    /// 使用武器4
    /// </summary>
    public void UseWeapon4()
    {
        GameObject weapon1 = Instantiate(Resources.Load("武器4", typeof(GameObject))) as GameObject;
    }

    /// <summary>
    /// 使用武器5
    /// </summary>
    public void UseWeapon5()
    {
        GameObject weapon1 = Instantiate(Resources.Load("武器5", typeof(GameObject))) as GameObject;
    }

    /// <summary>
    /// 使用武器6
    /// </summary>
    public void UseWeapon6()
    {
        GameObject weapon1 = Instantiate(Resources.Load("武器6", typeof(GameObject))) as GameObject;
    }


}
