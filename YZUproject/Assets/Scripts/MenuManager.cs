﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("玩家資料")]
    public PlayerDate data;
    [Header("選擇關卡畫面")]
    public GameObject chooseLevel;
    [Header("關卡6按鈕")]
    public Button btn6;
    [Header("關卡11按鈕")]
    public Button btn11;
    [Header("關卡16按鈕")]
    public Button btn16;
    [Header("詳細資訊畫面")]
    public GameObject valueDetail;
    [Header("武器區塊")]
    public GameObject weaponArea;
    [Header("寵物區塊")]
    public GameObject petArea;

    [Header("玩家數值")]
    public Text[] playerValue;
    [Header("玩家武器")]
    public GameObject[] weapon;
    [Header("玩家寵物")]
    public GameObject[] pet;

    [Header("金幣群組")]
    public Text[] coin;
    [Header("鑽石群組")]
    public Text[] jewel;

    [Header("設定畫面退出按鈕")]
    public Button[] setExit;
    [Header("設定畫面")]
    public GameObject[] setPanel;

    [Header("武器按鈕")]
    public Button[] weaponBtn;
    [Header("武器按鈕全部照片")]
    public Sprite[] weaponBtn_allimg;
    [Header("武器取消按鈕")]
    public Button[] weaponExit;
    [Header("武器畫面")]
    public GameObject[] weaponPanel;

    [Header("武器使用按鈕")]
    public Button[] weaponUse_Btn;
    [Header("武器使用全部照片")]
    public Sprite[] weaponUse_allimg;
    [Header("武器使用中圖片")]
    public Image[] weaponUse_Img;

    [Header("武器等級文字")]
    public Text[] weaponLevel_text;
    [Header("武器傷害文字")]
    public Text[] weaponDamage_text;
    [Header("武器升級按鈕")]
    public Button[] weaponUp_Btn;
    [Header("武器升級條")]
    public Image[] weaponUp_Bar;
    [Header("武器碎片文字")]
    public Text[] weaponChip_Text;

    [Header("人員素材按鈕")]
    public Button[] soueceBtn;
    [Header("人員素材退出按鈕")]
    public Button[] soueceExit;
    [Header("人員素材畫面")]
    public GameObject[] soursePanel;

    [Header("天賦按鈕")]
    public Button[] talentBtn;
    [Header("天賦畫面")]
    public GameObject[] talentPanel;
    [Header("天賦數值")]
    public Text[] talentValue;

    private GameObject ps;          // 粒子

    private Button valueDetailBtn;  // 詳細資訊按鈕
    private Button setButton1;      // 設定按鈕
    private Button setButton2;
    private Button setButton3;
    private Button setButton4;
    private Button lowButton1;      // 下方選單按鈕
    private Button lowButton2;
    private Button lowButton3;
    private Button lowButton4;
    private Button atkButton;       // 選擇武器的按鈕
    private Button petButton;       // 選擇寵物的按鈕

    private Player player;
    private DrawTalent draw;

    private Image atkBtn_img;       // 選擇武器的按鈕的圖片
    private Image petBtn_img;       // 選擇寵物的按鈕的圖片
    private Text atkValue;          // 裝備 攻擊力數值
    private Text hpValue;           // 裝備 生命數值
    private Text name;              // 玩家名稱
    private bool isDetail;

    private void Start()
    {
        // *********************** //
        data.WeaponAttack = data.ownWeapons[0].damage;
        data.cd = data.ownWeapons[0].cd;
        data.ownWeapons[0].level = 1;
        data.ownWeapons[1].level = 1;
        data.ownWeapons[2].level = 1;
        data.ownWeapons[3].level = 1;
        data.ownWeapons[4].level = 1;
        data.ownWeapons[5].level = 1;
        data.ownWeapons[6].level = 1;
        data.ownWeapons[7].level = 1;
        data.ownWeapons[8].level = 1;

        // *********************** //
        setButton1 = GameObject.Find("設定按鈕0").GetComponent<Button>();
        setButton2 = GameObject.Find("設定按鈕1").GetComponent<Button>();
        setButton3 = GameObject.Find("設定按鈕2").GetComponent<Button>();
        setButton4 = GameObject.Find("設定按鈕3").GetComponent<Button>();
        lowButton1 = GameObject.Find("商城下方按鈕").GetComponent<Button>();
        lowButton2 = GameObject.Find("裝備下方按鈕").GetComponent<Button>();
        lowButton3 = GameObject.Find("關卡下方按鈕").GetComponent<Button>();
        lowButton4 = GameObject.Find("天賦下方按鈕").GetComponent<Button>();
        atkButton = GameObject.Find("武器按鈕").GetComponent<Button>();
        petButton = GameObject.Find("寵物按鈕").GetComponent<Button>();
        valueDetailBtn = GameObject.Find("詳細資訊按鈕").GetComponent<Button>();
        hpValue = GameObject.Find("生命值").GetComponent<Text>();
        atkValue = GameObject.Find("攻擊力").GetComponent<Text>();
        name = GameObject.Find("玩家名稱").GetComponent<Text>();
        atkBtn_img = atkButton.GetComponent<Image>();
        petBtn_img = petButton.GetComponent<Image>();
        ps = GameObject.Find("選單粒子效果");

        player = FindObjectOfType<Player>();
        draw = FindObjectOfType<DrawTalent>();

        isDetail = false;

        Updatedata();
        Allowbtn();
        ClickButton();
    }

    public void Updatedata() //更新數值
    {
        for (int i = 0; i < coin.Length; i++)  // 金幣更新
        {
            int index = i;
            coin[index].text = data.PlayerCoin.ToString("F0");
        }

        for (int i = 0; i < jewel.Length; i++)  // 鑽石更新
        {
            int index = i;
            jewel[index].text = data.PlayerJewel.ToString("F0");
        }

        for (int i = 0; i < weaponBtn.Length; i++)  // 裝備 武器照片抓資料
        {
            int index = i;
            weaponUse_Img[index] = weaponBtn[index].GetComponent<Image>();
        }

        for (int i = 0; i < weaponChip_Text.Length; i++) // 裝備 武器碎片數量更新
        {
            int index = i;
            weaponChip_Text[index].text = data.weaponChips[index].count + "/ 30";
        }

        for (int i = 0; i < weaponUp_Bar.Length; i++)    // 裝備 武器 升級條更新
        {
            int index = i;
            weaponUp_Bar[index].fillAmount = (float)data.weaponChips[index].count / 30;
        }

        for (int i = 0; i < weaponUp_Btn.Length; i++)    // 裝備 武器 升級按鈕控制
        {
            int index = i;
            if (data.weaponChips[index].count >= 10)
            {
                weaponUp_Btn[index].interactable = true;
            }
            else if (data.weaponChips[index].count < 10)
            {
                weaponUp_Btn[index].interactable = false;
            }
        }

        for (int i = 0; i < weaponLevel_text.Length; i++)  // 裝備 武器 等級文字更新
        {
            int index = i;
            weaponLevel_text[index].text = "Lv." + data.ownWeapons[index].level;
        }

        for (int i = 0; i < weaponDamage_text.Length; i++)
        {
            int index = i;
            weaponDamage_text[index].text = "傷害 : " + data.ownWeapons[i].damage;
        }

        talentValue[0].text = "天賦生命增加 + " + draw.hpValue.ToString("F0");
        talentValue[1].text = "天賦攻擊增加 + " + draw.atkValue.ToString("F0");
        talentValue[2].text = "天賦爆擊增加 + " + draw.criticalValue.ToString("F0");
        talentValue[3].text = "天賦跑速增加 + " + draw.speedValue.ToString("F0");
        talentValue[4].text = "天賦減傷增加 + " + draw.armorValue.ToString("F0");
        talentValue[5].text = "天賦回復增加 + " + draw.rehpValue.ToString("F0");

        float atk = data.attack + data.WeaponAttack + data.CriticalAttack;
        atkValue.text = atk.ToString();
        hpValue.text = data.hp.ToString("F0");
        name.text = data.name + "の裝備";

        Player.hp = player.data.hp;
        Player.hpMax = player.data.hpMax;
        Player.attack = player.data.attack;
        Player.attack_WP = player.data.WeaponAttack;
        Player.cd = player.data.cd;
        Player.criticalAttack = player.data.CriticalAttack;
        Player.speed = player.data.speed;
        Player.rehp = player.data.rehp;
    }

    private void Allowbtn() // 激活按鈕
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

    private void ClickButton() // 點擊按鈕
    {
        lowButton1.onClick.AddListener(NoShowParticle);
        lowButton2.onClick.AddListener(NoShowParticle);
        lowButton4.onClick.AddListener(NoShowParticle);
        lowButton3.onClick.AddListener(ShowParticle);

        atkButton.onClick.AddListener(ShowWeaponArea);
        petButton.onClick.AddListener(ShowPetArea);

        setButton1.onClick.AddListener(() => { ShowSetPanel(0); });
        setButton2.onClick.AddListener(() => { ShowSetPanel(1); });
        setButton3.onClick.AddListener(() => { ShowSetPanel(2); });
        setButton4.onClick.AddListener(() => { ShowSetPanel(3); });

        valueDetailBtn.onClick.AddListener(ShowValueDetail);

        for (int i = 0; i < setExit.Length; i++)  // 退出設定按鈕
        {
            int index = i;
            setExit[index].onClick.AddListener(() => { NoShowSetPanel(index); });
        }

        for (int i = 0; i < weaponBtn.Length; i++)  // 武器按鈕
        {
            int index = i;
            weaponBtn[index].onClick.AddListener(() => { ShowWeaponPanel(index); });
            weaponExit[index].onClick.AddListener(() => { NoShowWeaponPanel(index); });
            weaponUse_Btn[index].onClick.AddListener(() => { UseWeapon(index); });
        }

        for (int i = 0; i < soueceBtn.Length; i++)  // 人員素材按鈕
        {
            int index = i;
            soueceBtn[index].onClick.AddListener(() => { ShowSourcePanel(index); });
            soueceExit[index].onClick.AddListener(() => { NoShowSourcePanel(index); });
        }

        for (int i = 0; i < talentBtn.Length; i++)  // 天賦按鈕
        {
            int index = i;
            talentBtn[index].onClick.AddListener(() => { ShowTalentPanel(index); });
        }

        for (int i = 0; i < weaponUp_Btn.Length; i++)
        {
            int index = i;
            weaponUp_Btn[index].onClick.AddListener(() => { WeaponLevelUp(index); });
        }
    }

    public void LoadLevel() // 切換場景
    {
        data.hp = data.hpMax;
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// 關卡按鈕
    /// </summary>
    /// <param name="i">關卡號碼</param>
    private void ButtonOfLevel(int i)
    {
        SceneManager.LoadSceneAsync(i);
        chooseLevel.SetActive(false);
    }

    public void Level7() // 關卡7按鈕
    {
        ButtonOfLevel(7);
    }

    public void Level13() // 關卡13按鈕
    {
        ButtonOfLevel(13);
    }

    public void Level19() // 關卡19按鈕
    {
        ButtonOfLevel(19);
    }

    public void ShowLevelChoose() // 開啟選擇關卡畫面
    {

        chooseLevel.SetActive(true);
    }

    public void NoShowLevelChoose() // 關閉選擇關卡畫面
    {
        chooseLevel.SetActive(false);
    }

    private void ShowWeaponArea() // 開啟武器區域畫面
    {
        petArea.SetActive(false);
        weaponArea.SetActive(true);
    }

    private void ShowPetArea() // 開啟寵物區域畫面
    {
        weaponArea.SetActive(false);
        petArea.SetActive(true);
    }

    private void ShowParticle() // 開啟粒子系統
    {
        ps.SetActive(true);
    }

    private void NoShowParticle() // 關閉粒子系統
    {
        ps.SetActive(false);
    }

    private void ShowSetPanel(int i) // 顯示設定畫面
    {
        setPanel[i].SetActive(true);
        lowButton1.interactable = false;
        lowButton2.interactable = false;
        lowButton3.interactable = false;
        lowButton4.interactable = false;
    }

    private void NoShowSetPanel(int i) // 關閉設定畫面
    {
        setPanel[i].SetActive(false);
        lowButton1.interactable = true;
        lowButton2.interactable = true;
        lowButton3.interactable = true;
        lowButton4.interactable = true;
    }

    private void ShowSourcePanel(int i) // 開啟人素材員畫面
    {
        soursePanel[i].SetActive(true);
    }

    private void NoShowSourcePanel(int i) // 關閉人員素材畫面
    {
        soursePanel[i].SetActive(false);
    }

    private void ShowWeaponPanel(int i) // 顯示武器畫面
    {
        weaponPanel[i].SetActive(true);
        lowButton1.interactable = false;
        lowButton2.interactable = false;
        lowButton3.interactable = false;
        lowButton4.interactable = false;
    }

    private void NoShowWeaponPanel(int i) // 不顯示武器畫面
    {
        weaponPanel[i].SetActive(false);
        lowButton1.interactable = true;
        lowButton2.interactable = true;
        lowButton3.interactable = true;
        lowButton4.interactable = true;
    }

    private void ShowTalentPanel(int i)  // 顯示天賦畫面
    {
        for (int j = 0; j < talentPanel.Length; j++)
        {
            talentPanel[j].SetActive(false);
        }
        talentPanel[i].SetActive(true);
    }

    private void ShowValueDetail()  // 開關詳細資訊
    {
        playerValue[0].text = data.hp.ToString("F0");
        float PV_atk = data.attack + data.CriticalAttack + data.WeaponAttack;
        playerValue[1].text = PV_atk.ToString("F0");
        playerValue[2].text = data.speed.ToString("F0");
        playerValue[3].text = data.armor.ToString("F2") + " %";
        playerValue[4].text = data.rehp.ToString("F2") + " /s";
        playerValue[5].text = data.cd.ToString("F1") + " /s";

        isDetail = !isDetail;
        if (isDetail)
        {
            valueDetail.SetActive(true);
        }
        else
        {
            valueDetail.SetActive(false);
        }
    }

    private void UseWeapon(int i)  // 選擇武器
    {
        for (int j = 0; j < weaponUp_Btn.Length; j++)
        {
            if (data.ownWeapons[j].owned == true)
            {
                weaponUse_Img[j].sprite = weaponBtn_allimg[j];
            }
        }
        atkBtn_img.sprite = weaponBtn_allimg[i];
        weaponUse_Img[i].sprite = weaponUse_allimg[i];
        Player.bullet = weapon[i];
        data.WeaponAttack = data.ownWeapons[i].damage;
        data.cd = data.ownWeapons[i].cd;
        Updatedata();
        weaponPanel[i].SetActive(false);
        lowButton1.interactable = true;
        lowButton2.interactable = true;
        lowButton3.interactable = true;
        lowButton4.interactable = true;
    }

    private void WeaponLevelUp(int i)  // 武器升級
    {
        data.weaponChips[i].count -= 10;
        data.ownWeapons[i].level++;
        data.ownWeapons[i].damage += 10;
        Updatedata();
    }

}
