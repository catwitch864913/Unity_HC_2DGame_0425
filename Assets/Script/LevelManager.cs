using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("�g���")]
    public Image imgExp;
    [Header("��r����")]
    public TextMeshProUGUI textLv;
    [Header("��r�g���")]
    public TextMeshProUGUI textExp;
    [Header("�ɯŭ��O")]
    public GameObject goLvUp;
    [Header("�ޯ�1-3")]
    public GameObject[] goSkillUI;

    /// <summary>
    /// 0 �l���g��
    /// 1 ����
    /// 2 ���j
    /// 3 ��q
    /// 4 �t��
    /// </summary>
    [Header("�ޯ��ư}�C")]
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
            print($"<color=#ff6699>i����:{i}</color>");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print($"<color=#6699ff>{collision.name}</color>");

        if (collision.name.Contains("�g��y"))
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
        //x.lv<5������&#xff1a;�D�X�Ҧ����Ťp��5���ޯ�
        randomSkill = dataSkills.Where(Skill => Skill.skillLv < 5).ToList();
        //�����s�ƧǡA�Ʀr���j�Y�i�F���H���ĪG�C
        randomSkill = randomSkill.OrderBy(Skill => Random.Range(0, 999)).ToList();

        for (int i = 0; i < 3; i++)
        {
            goSkillUI[i].transform.Find("�ޯ�W��").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
            goSkillUI[i].transform.Find("�ޯ�y�z").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillDescription;
            goSkillUI[i].transform.Find("�ޯ൥��").GetComponent<TextMeshProUGUI>().text = "Lv." + randomSkill[i].skillLv;
            goSkillUI[i].transform.Find("�ޯ�ϥ�").GetComponent<Image>().sprite = randomSkill[i].skillPicture;
        }
    }

    //����k�b�}������ܥ��}���U��|����U�誺�{��
    [ContextMenu("���͸g��ȻݨD���")]
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
        //print($"<color=$6699ff>�I���ޯ�s���G{indexSkill}</color>");
        randomSkill[indexSkill].skillLv++;
        goLvUp.SetActive(false);
        Time.timeScale = 1f;

        if (randomSkill[indexSkill].nameSkill == "�ޯ�l���g��Ƚd��Data") UpdateExpRange();
        if (randomSkill[indexSkill].nameSkill == "�ޯ�Z�������OData") UpdateAttack();
        if (randomSkill[indexSkill].nameSkill == "�ޯ�Z�����jData") UpdateInterval();
        if (randomSkill[indexSkill].nameSkill == "�ޯ઱�a��qData") UpdatePlayerHp();
        if (randomSkill[indexSkill].nameSkill == "�ޯಾ�ʳt��Data") UpdateMoveSpeed();
    }

    [Header("���Z�l�g��I����")]
    public CircleCollider2D playerExpRange;
    private void UpdateExpRange()
    {
        int lv = dataSkills[0].skillLv - 1;
        playerExpRange.radius = dataSkills[0].skillValues[lv];
    }
    [Header("�Z�����Y")]
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
    [Header("���a���")]
    public DataBasic dataBasic;
    private void UpdatePlayerHp()
    {
        int lv = dataSkills[3].skillLv - 1;
        dataBasic.hp = dataSkills[3].skillValues[lv];
    }
    [Header("���Z�G����t��")]
    public PlayerCollder controlSystem;
    private void UpdateMoveSpeed()
    {
        int lv = dataSkills[4].skillLv - 1;
        controlSystem.moveSpeed = dataSkills[4].skillValues[lv];
    }
}
