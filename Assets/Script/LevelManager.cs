using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("經驗值")]
    public Image imgExp;
    [Header("文字等級")]
    public TextMeshProUGUI textLv;
    [Header("文字經驗值")]
    public TextMeshProUGUI textExp;
    [Header("升級面板")]
    public GameObject goLvUp;
    [Header("技能1-3")]
    public GameObject[] goSkillUI;

    /// <summary>
    /// 0 吸取經驗
    /// 1 攻擊
    /// 2 間隔
    /// 3 血量
    /// 4 速度
    /// </summary>
    [Header("技能資料陣列")]
    public DataSkill[] dataSkills;

    public List<DataSkill> randomSkill = new List<DataSkill>();

    private int lv = 1;
    private float exp = 0;

    public float[] expNeeds = { 100, 200, 300 };
    private void Start()
    {
        //AddExp(50);
        for (int i = 0; i < 10; i++)
        {
            print($"<color=#ff6699>i的值:{i}</color>");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print($"<color=#6699ff>{collision.name}</color>");

        if (collision.name.Contains("經驗球"))
        {
            collision.GetComponent<ExpSystem>().enabled = true;
        }
    }
    public void AddExp(float exp)
    {
        this.exp += exp;
        if (this.exp > expNeeds[lv - 1])
        {
            this.exp -= expNeeds[lv - 1];
            lv++;
            textLv.text = lv.ToString();
            LevelUp();
        }
        textExp.text = this.exp + "/" + expNeeds[lv - 1];
        imgExp.fillAmount = this.exp / expNeeds[lv - 1];
    }
    private void LevelUp()
    {
        goLvUp.SetActive(true);
        Time.timeScale = 0;

        print(dataSkills[4].skillLv);
        //x.lv<5為條件&#xff1a;挑出所有等級小於5的技能
        randomSkill = dataSkills.Where(Skill => Skill.skillLv < 5).ToList();
        //為重新排序，數字夠大即可達到隨機效果。
        randomSkill = randomSkill.OrderBy(Skill => Random.Range(0, 999)).ToList();

        for (int i = 0; i < 3; i++)
        {
            goSkillUI[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
            goSkillUI[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillDescription;
            goSkillUI[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "Lv." + randomSkill[i].skillLv;
            goSkillUI[i].transform.Find("技能圖示").GetComponent<Image>().sprite = randomSkill[i].skillPicture;
        }
    }

    //此方法在腳本那選擇打開按下後會執行下方的程式
    [ContextMenu("產生經驗值需求資料")]
    private void ExpNeeds()
    {
        expNeeds = new float[100];
        for (int i = 0; i < 100; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

    public void ClickSkillButton(int indexSkill)
    {
        //print($"<color=$6699ff>點擊技能編號：{indexSkill}</color>");
        randomSkill[indexSkill].skillLv++;
        goLvUp.SetActive(false);
        Time.timeScale = 1f;

        if (randomSkill[indexSkill].nameSkill == "技能吸取經驗值範圍Data") UpdateExpRange();
        if (randomSkill[indexSkill].nameSkill == "技能武器攻擊力Data") UpdateAttack();
        if (randomSkill[indexSkill].nameSkill == "技能武器間隔Data") UpdateInterval();
        if (randomSkill[indexSkill].nameSkill == "技能玩家血量Data") UpdatePlayerHp();
        if (randomSkill[indexSkill].nameSkill == "技能移動速度Data") UpdateMoveSpeed();
    }

    [Header("企鵝吸經驗碰撞器")]
    public CircleCollider2D playerExpRange;
    private void UpdateExpRange()
    {
        int lv = dataSkills[0].skillLv - 1;
        playerExpRange.radius = dataSkills[0].skillValues[lv];
    }
    [Header("武器斧頭")]
    public WeaponSystem weaponSystemApex;
    private void UpdateAttack()
    {
        int lv = dataSkills[1].skillLv - 1;
        weaponSystemApex.attack = dataSkills[1].skillValues[lv];
    }
    private void UpdateInterval()
    {
        int lv = dataSkills[2].skillLv - 1;
        weaponSystemApex.inverval = dataSkills[2].skillValues[lv];
        weaponSystemApex.Restart();
    }
    [Header("玩家資料")]
    public DataBasic dataBasic;
    private void UpdatePlayerHp()
    {
        int lv = dataSkills[3].skillLv - 1;
        dataBasic.hp = dataSkills[3].skillValues[lv];
    }
    [Header("企鵝：控制系統")]
    public PlayerCollder controlSystem;
    private void UpdateMoveSpeed()
    {
        int lv = dataSkills[4].skillLv - 1;
        controlSystem.moveSpeed = dataSkills[4].skillValues[lv];
    }
}
