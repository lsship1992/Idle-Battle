using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using static GameControll;
public class PersonBattleScript : MonoBehaviour
{
    public string name;
    public int id;
    public string rank;
    public int level;
    public int levelEvo;
    public string Class;
    public int Attack;
    public int Hp;
    public int Defens;
    public int Speed;
    public int idSlot;
    public float Attack_info = 0;
    public float Hp_info = 0;
    public float Defens_info = 0;
    public float Speed_info = 0;
    public int DamageReduction;
    public int CritDamage;
    public int CritChance;
    public int Evasion;
    public int Accuracy;
    public int DamageBonus;
    public int AntiCrit;
    public int Control;
    public int AntiControl;
    public int Treatment;
    public int Recovery;
    public string typePerson;
    public bool ReadiPerson = false;
    public Animator _Animator;
    public bool IsAttack;
    public Image HpFill;
    public float HpMax;
    public Text DamageText;
    public List<int> HpItem = new List<int>();
    public List<int> DefensItem = new List<int>();
    public List<int> SpeedItem = new List<int>();
    public List<int> AttackItem = new List<int>();
    public List<int> Hp_procItem = new List<int>();
    public List<int> Defens_procItem = new List<int>();
    public List<int> Speed_procItem = new List<int>();
    public List<int> Attack_procItem = new List<int>();
    public int bs;
    public string skill1;
    public string skill2;
    public string skill3;
    public string skill4Pasiv;
    public string skill5Pasiv;

    public string skill1Resiver;
    public string skill2Resiver;
    public string skill3Resiver;
    public string skill4PasivResiver;
    public string skill5PasivResiver;

    public string skill1Play;
    public string skill2Play;
    public string skill3Play;


    public List<String> Debuf = new List<String>();
    public List<String> Buffs = new List<String>();
    

    public int snat;
    public int krovotichenie;
    public int Yad;
    public bool Molchanie;
    public bool Rabstvo;

    public float Attack_infoNoDebuf = 0;
    public float Hp_infoNoDebuf = 0;
    public float Defens_infoNoDebuf = 0;
    public float Speed_infoNoDebuf = 0;

    private void FixedUpdate()
    {
        _Animator.SetBool("isAttack", IsAttack);
        HpFill.fillAmount = Hp_info / HpMax;
        
        
        
    }
    private void Update()
    {
        if (typePerson == "Enemy")
        {
            Debug.Log("Херня");
            if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
            {
                Debug.Log("Херня");
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().LevelEnemyRound.text = $"Уровень боса: {level}";
            }
        }
    }

    private void Start()
    {
        if (typePerson == "UserPerson")
        {
            try
            {
                ClientSend.SearchSkillPerson(Convert.ToInt32(skill1), "skill1", idSlot);
            }
            catch
            {

            }
            try
            {
                ClientSend.SearchSkillPerson(Convert.ToInt32(skill2), "skill2", idSlot);
            }
            catch
            {

            }
            try
            {
                ClientSend.SearchSkillPerson(Convert.ToInt32(skill3), "skill3", idSlot);
            }
            catch
            {

            }
            try
            {
                ClientSend.SearchSkillPerson(Convert.ToInt32(skill4Pasiv), "skill4Passiv", idSlot);
            }
            catch
            {

            }
            try
            {
                ClientSend.SearchSkillPerson(Convert.ToInt32(skill5Pasiv), "skill5Passiv", idSlot);
            }
            catch
            {

            }
        }
        else if (typePerson == "Enemy")
        {
            try
            {
                ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill1), "skill1", idSlot);

            }
            catch
            {

            }
            
            try
            {
                ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill2), "skill2", idSlot);
            }
            catch
            {

            }
            try
            {
                ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill3), "skill3", idSlot);
            }
            catch
            {

            }
            try
            {
                ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill4Pasiv), "skill4Passiv", idSlot);
            }
            catch
            {

            }
            try
            {
                ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill5Pasiv), "skill5Passiv", idSlot);
            }
            catch
            {

            }
        }
        DamageText.gameObject.SetActive(false);
        _Animator = GetComponent<Animator>();
        if (typePerson == "UserPerson")
        {
            ClientSend.SearchItemPersonBattle(id, idSlot, "UserPerson");
            //UpdateLevelDef();



        }
        else if (typePerson == "Enemy")
        {
            if (GameControll.instance.PvePanel.activeSelf)
            {
                ClientSend.SearchItemPersonBattle(id, idSlot, "Enemy");
            }
            else
            {
                UpdateLevelDef();

            }
        }
        if (name == "King")
        {
            //gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2();
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[0];
            //gameObject.GetComponent<Image>().sprite = GameControll.instance.AvatarPerson[0];

        }
        else if (name == "The villain with the whip")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
                
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[5];

        }
        else if (name == "Genos")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[2];

        }
        else if (name == "Tatsumaki Tornado")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[8];

        }
        else if (name == "Isamu the Cruel Emperor")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[4];

        }
        else if (name == "Suiryu")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[7];

        }
        else if (name == "Bad Steel Bat")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[6];

        }
        else if (name == "The master in a Tshirt")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[3];

        }
        else if (name == "Kamikaze Atomic Samurai")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[1];

        }
        else if (name == "Asta")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[9];

        }
        else if (name == "Noel Silver")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[13];

        }
        else if (name == "Yami Sukehiro")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[18];

        }
        else if (name == "Yuno")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[17];

        }
        else if (name == "William Wanjins")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[10];

        }
        else if (name == "Mereoleon The Crimson Lion")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[12];

        }
        else if (name == "Fana")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[14];

        }
        else if (name == "Finral Rollcase")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[15];

        }

        else if (name == "Julius Novochrono")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[16];

        }
        else if (name == "Zora Ideare")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[11];

        }
        else if (name == "Gomo gomo zek")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Genrysay Yamamoto")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Retsu Unohana")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Syuhey Hisagi")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Chad")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kenpachi Zaraki")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Djushiro Ikitake")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Byakuya Kuchiki")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Yumichka")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Sandji Komamura")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Yuriu Isida")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Rangiku Matsumoto")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Ikkaku Maderame")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Gin")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Hirako")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Aizen")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Grimjou")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Soy-Fon")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Ichigo Kurasaki")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kento Nanami")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kigusaki Nabora")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Zenin Maki")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Yuta Okkotsu")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Todji Fushigura")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Djogo")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Suguru Geto")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Todo Ayo")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kusumi Miva")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Ryomen Sukuna")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Satoru Godjo")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Mahito")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Hanami")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Itadori Yudji")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Beng")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Satoru")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Sonik")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "May Mask")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Garo")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Prujinyashii Us")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Maskitnaya Jenshina")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Fushigura Megumia")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Panda")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Rengoku")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Sanemi")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Tomioka")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Nezuko")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Tandjiro")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Susamaru")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Zenitsu")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Mudzan")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Gyutaro")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Inoske")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Shinobu Kocho")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Toketu")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Gyumey")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kokushibo")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Tengen")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kaygaku")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Reve")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Gordon")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kaiser")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Zarget Demon")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Gosh")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Langris")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Lack")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Vanika")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Doroti")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Nomu")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Shoto")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Tokoyame")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Tsuyu")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Dabi")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Bakugo")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Uraraka")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Gran Torino")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "All might")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Izuki Midoriya")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Himiko Toga")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Muskular")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kirishima")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Staratel")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Shtein")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Momo Yayorozu")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Minoru Mineta")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Mitsuki")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kakashi")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Orochimaru")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Obito")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Naruto")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Jiraya")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kavaki")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Boruto")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Mifune")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Sasuke")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Sarada")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Madara")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Kurenay")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Sakura")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Gaara")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Hashirama")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Tsunade")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }
        else if (name == "Itachi")
        {
            if (typePerson == "Enemy")
            {
                DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
            }
            _Animator.runtimeAnimatorController = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AnimatorPerson[19];

        }

    }
    
    public bool CheckHp()
    {
        if (Hp_info <= 0)
        {

            if (typePerson == "UserPerson")
            {
                if (GameControll.instance.PvePanel.activeSelf)
                {
                    Debug.Log("Смерть перса пвп");
                    foreach (var item in GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonidListSlot.ToList())
                    {
                        Debug.Log("Итем = " +  item + " слот " + idSlot);
                        if (item == idSlot)
                        {
                            Debug.Log("Нальная трещина");
                            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().UserPersonidListSlot.Remove(item);
                        }
                    }
                    foreach (var item in GameControll.instance.PvePanel.GetComponent<PvePanelScript>().ListSpeedPersonUser.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "UserPerson")
                        {
                            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().ListSpeedPersonUser.Remove(item);
                        }
                    }
                    foreach (var item in GameControll.instance.PvePanel.GetComponent<PvePanelScript>().AllPersonSpeed.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "UserPerson")
                        {
                            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().AllPersonSpeed.Remove(item);
                        }
                    }
                    Destroy(gameObject);
                }
                else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
                {
                    foreach (var item in GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonidListSlot.ToList())
                    {
                        if (item == idSlot)
                        {
                            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().UserPersonidListSlot.Remove(item);
                        }
                    }
                    foreach (var item in GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().ListSpeedPersonUser.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "UserPerson")
                        {
                            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().ListSpeedPersonUser.Remove(item);
                        }
                    }
                    foreach (var item in GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().AllPersonSpeed.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "UserPerson")
                        {
                            GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().AllPersonSpeed.Remove(item);
                        }
                    }
                    Destroy(gameObject);

                }
                else
                {
                    foreach (var item in GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonidListSlot.ToList())
                    {
                        if (item == idSlot)
                        {
                            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().UserPersonidListSlot.Remove(item);
                        }
                    }
                    foreach (var item in GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "UserPerson")
                        {
                            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.Remove(item);
                        }
                    }
                    foreach (var item in GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AllPersonSpeed.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "UserPerson")
                        {
                            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AllPersonSpeed.Remove(item);
                        }
                    }
                    Destroy(gameObject);
                }

            }
            else if (typePerson == "Enemy")
            {
                if (GameControll.instance.PvePanel.activeSelf)
                {
                    Debug.Log("Смерть врага пвп");
                    foreach (var item in GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonidListSlot.ToList())
                    {
                        if (item == idSlot)
                        {
                            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().EnemyPersonidListSlot.Remove(item);
                        }
                    }
                    foreach (var item in GameControll.instance.PvePanel.GetComponent<PvePanelScript>().ListSpeedPersonEnemy.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "Enemy")
                        {
                            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().ListSpeedPersonEnemy.Remove(item);

                        }
                    }
                    foreach (var item in GameControll.instance.PvePanel.GetComponent<PvePanelScript>().AllPersonSpeed.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "Enemy")
                        {
                            GameControll.instance.PvePanel.GetComponent<PvePanelScript>().AllPersonSpeed.Remove(item);

                        }
                    }
                    Destroy(gameObject);
                }
                else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
                {
                    level++;
                    try
                    {
                        ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill1), "skill1", idSlot);

                    }
                    catch
                    {

                    }

                    try
                    {
                        ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill2), "skill2", idSlot);
                    }
                    catch
                    {

                    }
                    try
                    {
                        ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill3), "skill3", idSlot);
                    }
                    catch
                    {

                    }
                    try
                    {
                        ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill4Pasiv), "skill4Passiv", idSlot);
                    }
                    catch
                    {

                    }
                    try
                    {
                        ClientSend.SearchSkillPersonEnemy(Convert.ToInt32(skill5Pasiv), "skill5Passiv", idSlot);
                    }
                    catch
                    {

                    }
                    UpdateLevelDef();

                }
                else
                {
                    foreach (var item in GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.ToList())
                    {
                        if (item == idSlot)
                        {
                            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().EnemyPersonidListSlot.Remove(item);
                        }
                    }
                    foreach (var item in GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonEnemy.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "Enemy")
                        {
                            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonEnemy.Remove(item);

                        }
                    }
                    foreach (var item in GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AllPersonSpeed.ToList())
                    {
                        if (item.idSlot == idSlot && item.typePerson == "Enemy")
                        {
                            GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().AllPersonSpeed.Remove(item);

                        }
                    }
                    Destroy(gameObject);
                }
            }
            return true;
            /*
            if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonEnemyPlay.Count == 0 && GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUserPlay.Count == 0)
            {
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUserPlay = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.ToList();
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonEnemyPlay = GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonEnemy.ToList();
            }
            */
        }
        else
        {
            return false;
        }
    }
    public void UpdateLevelDef()
    {

        Debug.Log(typePerson);

        Attack_info = 0;
        Hp_info = 0;
        Defens_info = 0;
        Speed_info = 0;
        float _attack = Attack;
        float _hp = Hp;
        float _defens = Defens;
        float _speed = Speed;

        for (int i = 0; i < levelEvo + 1; i++)
        {

            if (i == 1)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
            }
            else if (i == 2)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
            }
            else if (i == 3)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 4)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 5)
            {
                _hp = _hp * 1.5f;
                _attack = _attack * 1.4f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 6)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 7)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 8)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 9)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
            else if (i == 10)
            {
                _hp = _hp * 1.3f;
                _attack = _attack * 1.2f;
                _defens = _defens + 150;
                _speed = _speed + 50;
            }
        }

        for (int i = 0; i < level; i++)
        {
            if (i < 50)
            {
                _attack = _attack * 1.045f;
                _hp = _hp * 1.044f;
                _defens = _defens * 1.021f;
                _speed = _speed * 1.021f;
            }
            else if (i >= 50 && i < 80)
            {
                _attack = _attack * 1.035f;
                _hp = _hp * 1.034f;
                _defens = _defens * 1.015f;
                _speed = _speed * 1.021f;
            }
            else if (i >= 80 && i < 100)
            {
                _attack = _attack * 1.03f;
                _hp = _hp * 1.03f;
                _defens = _defens * 1.015f;
                _speed = _speed * 1.015f;
            }
            else if (i >= 100 && i < 150)
            {
                _attack = _attack * 1.02f;
                _hp = _hp * 1.02f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 150 && i < 200)
            {
                _attack = _attack * 1.02f;
                _hp = _hp * 1.02f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 200 && i < 250)
            {
                _attack = _attack * 1.01f;
                _hp = _hp * 1.01f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 250 && i < 300)
            {
                _attack = _attack * 1.008f;
                _hp = _hp * 1.007f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 300 && i < 340)
            {
                _attack = _attack * 1.007f;
                _hp = _hp * 1.006f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 340 && i < 380)
            {
                _attack = _attack * 1.006f;
                _hp = _hp * 1.005f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 380 && i < 420)
            {
                _attack = _attack * 1.004f;
                _hp = _hp * 1.003f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 420 && i < 460)
            {
                _attack = _attack * 1.003f;
                _hp = _hp * 1.002f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 460 && i < 500)
            {
                _attack = _attack * 1.002f;
                _hp = _hp * 1.002f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }
            else if (i >= 500 && i <= 520)
            {
                _attack = _attack * 1.001f;
                _hp = _hp * 1.001f;
                _defens = _defens * 1.011f;
                _speed = _speed * 1.011f;
            }

        }
        if (typePerson == "UserPerson")
        {
            if (AttackItem.Count != 0)
            {
                foreach (int a in AttackItem)
                {
                    if (a != 0)
                        _attack = _attack + a;
                }
            }
            if (HpItem.Count != 0)
            {
                foreach (int a in HpItem)
                {
                    if (a != 0)
                        _hp = _hp + a;
                }
            }
            if (DefensItem.Count != 0)
            {
                foreach (int a in DefensItem)
                {
                    if (a != 0)
                        _defens = _defens + a;
                }
            }
            if (SpeedItem.Count != 0)
            {
                foreach (int a in SpeedItem)
                {
                    if (a != 0)
                        _speed = _speed + a;
                }
            }
            if (Attack_procItem.Count != 0)
            {
                foreach (int a in Attack_procItem)
                {
                    if (a != 0)
                    {
                        _attack = _attack * (100 + a) / 100;
                    }
                }
            }
            if (Hp_procItem.Count != 0)
            {
                foreach (int a in Hp_procItem)
                {
                    if (a != 0)
                    {

                        _hp = _hp * (100 + a) / 100;

                    }
                }
            }
            if (Defens_procItem.Count != 0)
            {
                foreach (int a in Defens_procItem)
                {
                    if (a != 0)
                    {

                        _defens = _defens * (100 + a) / 100;

                    }
                }
            }
            if (Speed_procItem.Count != 0)
            {
                foreach (int a in Speed_procItem)
                {
                    if (a != 0)
                    {

                        _speed = _speed * (100 + a) / 100;

                    }
                }
            }
            
            Debug.Log("Тест");
            Attack_info = _attack;
            Hp_info = _hp;
            
            Defens_info = _defens;
            Speed_info = _speed;
            Defens_infoNoDebuf = _defens;

        }
        else if (typePerson == "Enemy")
        {
            if (GameControll.instance.PvePanel.activeSelf)
            {
                if (AttackItem.Count != 0)
                {
                    foreach (int a in AttackItem)
                    {
                        if (a != 0)
                            _attack = _attack + a;
                    }
                }
                if (HpItem.Count != 0)
                {
                    foreach (int a in HpItem)
                    {
                        if (a != 0)
                            _hp = _hp + a;
                    }
                }
                if (DefensItem.Count != 0)
                {
                    foreach (int a in DefensItem)
                    {
                        if (a != 0)
                            _defens = _defens + a;
                    }
                }
                if (SpeedItem.Count != 0)
                {
                    foreach (int a in SpeedItem)
                    {
                        if (a != 0)
                            _speed = _speed + a;
                    }
                }
                if (Attack_procItem.Count != 0)
                {
                    foreach (int a in Attack_procItem)
                    {
                        if (a != 0)
                        {
                            _attack = _attack * (100 + a) / 100;
                        }
                    }
                }
                if (Hp_procItem.Count != 0)
                {
                    foreach (int a in Hp_procItem)
                    {
                        if (a != 0)
                        {

                            _hp = _hp * (100 + a) / 100;

                        }
                    }
                }
                if (Defens_procItem.Count != 0)
                {
                    foreach (int a in Defens_procItem)
                    {
                        if (a != 0)
                        {

                            _defens = _defens * (100 + a) / 100;

                        }
                    }
                }
                if (Speed_procItem.Count != 0)
                {
                    foreach (int a in Speed_procItem)
                    {
                        if (a != 0)
                        {

                            _speed = _speed * (100 + a) / 100;

                        }
                    }
                }

                Debug.Log("Тест");
                
                Attack_info = _attack;
                Hp_info = _hp;

                Defens_info = _defens;
                Speed_info = _speed;
                Defens_infoNoDebuf = _defens;
            }
            else
            {
                Attack_info = _attack;
                Hp_info = _hp;
                Defens_info = _defens;
                Speed_info = _speed;
                Attack_infoNoDebuf = _attack;
                Speed_infoNoDebuf = _speed;
                Hp_infoNoDebuf = _hp;
                Defens_infoNoDebuf = _defens;
            }
            
        }
        
        //Пасив скилы

        

        if (skill4PasivResiver != "")
        {
            string[] server_info = skill4PasivResiver.Split(',');
            Debug.Log(server_info[33]);
            Debug.Log(Convert.ToInt32(server_info[9]));
            try
            {
                if (Convert.ToInt32(server_info[9]) != 0)
                {
                    _attack = _attack * (100 + Convert.ToInt32(server_info[9])) / 100;
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[10]) != 0)
                {
                    DamageBonus = DamageBonus + Convert.ToInt32(server_info[10]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[11]) != 0)
                {
                    _speed = _speed * (100 + Convert.ToInt32(server_info[11])) / 100;
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[28]) != 0)
                {
                    _hp = _hp * (100 + Convert.ToInt32(server_info[11])) / 100;
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[31]) != 0)
                {
                    DamageReduction = DamageReduction + Convert.ToInt32(server_info[31]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[32]) != 0)
                {
                    CritDamage = CritDamage + Convert.ToInt32(server_info[32]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[33]) != 0)
                {
                    CritChance = CritChance + Convert.ToInt32(server_info[33]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[34]) != 0)
                {
                    Debug.Log(server_info[34]);
                    Evasion = Evasion + Convert.ToInt32(server_info[34]);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
            try
            {
                if (Convert.ToInt32(server_info[35]) != 0)
                {
                    Accuracy = Accuracy + Convert.ToInt32(server_info[35]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[36]) != 0)
                {
                    AntiCrit = AntiCrit + Convert.ToInt32(server_info[36]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[37]) != 0)
                {
                    Control = Control + Convert.ToInt32(server_info[37]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[38]) != 0)
                {
                    AntiControl = AntiControl + Convert.ToInt32(server_info[38]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[39]) != 0)
                {
                    Recovery = Recovery + Convert.ToInt32(server_info[39]);
                }
            }
            catch
            {

            }
            Attack_info = _attack;
            Speed_info = _speed;
            Hp_info = _hp;
            Attack_infoNoDebuf = _attack;
            Speed_infoNoDebuf = _speed;
            Hp_infoNoDebuf = _hp;
        }
        if (skill5PasivResiver != "")
        {
            string[] server_info = skill5PasivResiver.Split(',');
            try
            {
                if (Convert.ToInt32(server_info[9]) != 0)
                {
                    _attack = _attack * (100 + Convert.ToInt32(server_info[9])) / 100;
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[10]) != 0)
                {
                    DamageBonus = DamageBonus + Convert.ToInt32(server_info[10]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[11]) != 0)
                {
                    _speed = _speed * (100 + Convert.ToInt32(server_info[11])) / 100;
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[28]) != 0)
                {
                    _hp = _hp * (100 + Convert.ToInt32(server_info[11])) / 100;
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[31]) != 0)
                {
                    DamageReduction = DamageReduction + Convert.ToInt32(server_info[31]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[32]) != 0)
                {
                    CritDamage = CritDamage + Convert.ToInt32(server_info[32]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[33]) != 0)
                {
                    CritChance = CritChance + Convert.ToInt32(server_info[33]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[34]) != 0)
                {
                    Evasion = Evasion + Convert.ToInt32(server_info[34]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[35]) != 0)
                {
                    Accuracy = Accuracy + Convert.ToInt32(server_info[35]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[36]) != 0)
                {
                    AntiCrit = AntiCrit + Convert.ToInt32(server_info[36]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[37]) != 0)
                {
                    Control = Control + Convert.ToInt32(server_info[37]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[38]) != 0)
                {
                    AntiControl = AntiControl + Convert.ToInt32(server_info[38]);
                }
            }
            catch
            {

            }
            try
            {
                if (Convert.ToInt32(server_info[39]) != 0)
                {
                    Recovery = Recovery + Convert.ToInt32(server_info[39]);
                }
            }
            catch
            {

            }
            Attack_info = _attack;
            Speed_info = _speed;
            Hp_info = _hp;
            Attack_infoNoDebuf = _attack;
            Speed_infoNoDebuf = _speed;
            Hp_infoNoDebuf = _hp;
        }
        bs = (int)((Attack_info / 2) + (Hp_info / 2) + (Defens_info * 2.5f) + (Speed_info * 6.4f));
        HpMax = _hp;
        Attack_info = _attack;
        Speed_info = _speed;
        Hp_info = _hp;
        Attack_infoNoDebuf = _attack;
        Speed_infoNoDebuf = _speed;
        Hp_infoNoDebuf = _hp;
        Defens_info = _defens;
        Defens_infoNoDebuf = _defens;
        if (typePerson == "UserPerson")
        {
            skill1Play = skill1Resiver;
            skill2Play = skill2Resiver;
            skill3Play = skill3Resiver;
            if (GameControll.instance.PvePanel.activeSelf)
            {
                GameControll.instance.PvePanel.GetComponent<PvePanelScript>().ListSpeedPersonUser.Add(new PersonSearchSpeed(idSlot, Speed_info, "UserPerson", Attack_info, Hp_info, bs));

            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
            {
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().ListSpeedPersonUser.Add(new PersonSearchSpeed(idSlot, Speed_info, "UserPerson", Attack_info, Hp_info, bs));
            }
            else
            {
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonUser.Add(new PersonSearchSpeed(idSlot, Speed_info, "UserPerson", Attack_info, Hp_info, bs));
            }
        }
        else if (typePerson == "Enemy")
        {
            skill1Play = skill1Resiver;
            skill2Play = skill2Resiver;
            skill3Play = skill3Resiver;
            if (GameControll.instance.PvePanel.activeSelf)
            {
                GameControll.instance.PvePanel.GetComponent<PvePanelScript>().ListSpeedPersonEnemy.Add(new PersonSearchSpeed(idSlot, Speed_info, "Enemy", Attack_info, Hp_info, bs));
            }
            else if (GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.activeSelf == true)
            {
                GameControll.instance.KlanUser.GetComponent<KlanUser>().kvestKlan.GetComponent<CvestCklan>().BattlePanel.GetComponent<BattleKvestKlan>().ListSpeedPersonEnemy.Add(new PersonSearchSpeed(idSlot, Speed_info, "Enemy", Attack_info, Hp_info, bs));
            }
            else
            {
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().ListSpeedPersonEnemy.Add(new PersonSearchSpeed(idSlot, Speed_info, "Enemy", Attack_info, Hp_info, bs));
            }
        }
        ReadiPerson = true;

        /*
        Attack_info = _attack + Item[0].GetComponent<SelectItemScript>().attack + Item[1].GetComponent<SelectItemScript>().attack + Item[2].GetComponent<SelectItemScript>().attack + Item[3].GetComponent<SelectItemScript>().attack + Item[4].GetComponent<SelectItemScript>().attack + Item[5].GetComponent<SelectItemScript>().attack + Item[6].GetComponent<SelectItemScript>().attack + Item[7].GetComponent<SelectItemScript>().attack + Item[8].GetComponent<SelectItemScript>().attack + Item[9].GetComponent<SelectItemScript>().attack;
        Hp_info = _hp + Item[0].GetComponent<SelectItemScript>().hp + Item[1].GetComponent<SelectItemScript>().hp + Item[2].GetComponent<SelectItemScript>().hp + Item[3].GetComponent<SelectItemScript>().hp + Item[4].GetComponent<SelectItemScript>().hp + Item[5].GetComponent<SelectItemScript>().hp + Item[6].GetComponent<SelectItemScript>().hp + Item[7].GetComponent<SelectItemScript>().hp + Item[7].GetComponent<SelectItemScript>().hp + Item[8].GetComponent<SelectItemScript>().hp + Item[9].GetComponent<SelectItemScript>().hp;
        Defens_info = _defens + Item[0].GetComponent<SelectItemScript>().defens + Item[1].GetComponent<SelectItemScript>().defens + Item[2].GetComponent<SelectItemScript>().defens + Item[3].GetComponent<SelectItemScript>().defens + Item[4].GetComponent<SelectItemScript>().defens + Item[5].GetComponent<SelectItemScript>().defens + Item[6].GetComponent<SelectItemScript>().defens + Item[7].GetComponent<SelectItemScript>().defens + Item[8].GetComponent<SelectItemScript>().defens + Item[9].GetComponent<SelectItemScript>().defens;
        Speed_info = _speed + Item[0].GetComponent<SelectItemScript>().speed + Item[1].GetComponent<SelectItemScript>().speed + Item[2].GetComponent<SelectItemScript>().speed + Item[3].GetComponent<SelectItemScript>().speed + Item[4].GetComponent<SelectItemScript>().speed + Item[5].GetComponent<SelectItemScript>().speed + Item[6].GetComponent<SelectItemScript>().speed + Item[7].GetComponent<SelectItemScript>().speed + Item[8].GetComponent<SelectItemScript>().speed + Item[9].GetComponent<SelectItemScript>().speed;
        //Подсчет процента атаки
        Attack_info = Attack_info * (100 + Item[0].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[1].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[2].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[3].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[4].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[5].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[6].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[7].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        Attack_info = Attack_info * (100 + Item[8].GetComponent<SelectItemScript>()._attack_Proc) / 100;
        //Подсчет процента хп
        Hp_info = Hp_info * (100 + Item[0].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[1].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[2].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[3].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[4].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[5].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[6].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[7].GetComponent<SelectItemScript>()._hp_proc) / 100;
        Hp_info = Hp_info * (100 + Item[8].GetComponent<SelectItemScript>()._hp_proc) / 100;
        //Подсчет процента Защиты
        Defens_info = Defens_info * (100 + Item[0].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[1].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[2].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[3].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[4].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[5].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[6].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[7].GetComponent<SelectItemScript>().defens_proc) / 100;
        Defens_info = Defens_info * (100 + Item[8].GetComponent<SelectItemScript>().defens_proc) / 100;
        //Подсчет процента Скорости
        Speed_info = Speed_info * (100 + Item[0].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[1].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[2].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[3].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[4].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[5].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[6].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[7].GetComponent<SelectItemScript>().speed_proc) / 100;
        Speed_info = Speed_info * (100 + Item[8].GetComponent<SelectItemScript>().speed_proc) / 100;



        silaText.text = $"{(BigInteger)((Attack_info / 2) + (Hp_info / 2) + (Defens_info * 2.5f) + (Speed_info * 6.4f))}";
        */
    }
    public void UpdateBuf()
    {
        float attack = Attack_infoNoDebuf;
        float speed = Speed_infoNoDebuf;
        float defens = Defens_infoNoDebuf;
        float hp = Hp_infoNoDebuf;
        foreach (var a in Buffs.ToList())
        {
            string[] server_info = a.Split(',');
            //Атака
            if (server_info[0] == "AttackActivBoost")
            {
                if (Convert.ToInt32(server_info[2]) != 0)
                {
                    Attack_info = attack * (100 + Convert.ToInt32(server_info[1])) / 100;
                    string str = a;
                    string[] debug = str.Split(',');
                    Buffs.Remove(a);
                    Buffs.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");
                }
            }
            else
            {
                Buffs.Remove(a);
            }
            if (server_info[0] == "SpeedActivBoost")
            {
                if (Convert.ToInt32(server_info[2]) != 0)
                {
                    Speed_info = speed * (100 + Convert.ToInt32(server_info[1])) / 100;
                    string str = a;
                    string[] debug = str.Split(',');
                    Buffs.Remove(a);
                    Buffs.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");
                }
            }
            else
            {
                Buffs.Remove(a);
            }
            if (server_info[0] == "HpActivBoost")
            {
                if (Convert.ToInt32(server_info[2]) != 0)
                {
                    Hp_info = hp * (100 + Convert.ToInt32(server_info[1])) / 100;
                    string str = a;
                    string[] debug = str.Split(',');
                    Buffs.Remove(a);
                    Buffs.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");
                }
            }
            else
            {
                Buffs.Remove(a);
            }
            if (server_info[0] == "DefensActivBoost")
            {
                if (Convert.ToInt32(server_info[2]) != 0)
                {
                    Defens_info = defens * (100 + Convert.ToInt32(server_info[1])) / 100;
                    string str = a;
                    string[] debug = str.Split(',');
                    Buffs.Remove(a);
                    Buffs.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");
                }
            }
            else
            {
                Buffs.Remove(a);
            }
        }
    }
}
