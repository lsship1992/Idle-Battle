using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

using static GameControll;
public class cvestControlScript : MonoBehaviour
{
    public GameObject AutoBattle;
    public bool BattleStart = false;
    public List<GameObject> UserPersonSpavn = new List<GameObject>();
    public List<GameObject> EnemyPersonSpavn = new List<GameObject>();
    public GameObject UserPersonPrefab;
    public GameObject Boss;
    public GameObject Vboi;
    public int Level;
    public int Raund = 0;
    public int MaxRaund = 1;
    public Text levelText;
    public Text raundText;
    public List<int> UserPersonidListSlot = new List<int>();
    public List<int> EnemyPersonidListSlot = new List<int>();
    [SerializeField] public List<PersonSearchSpeed> ListSpeedPersonUser = new List<PersonSearchSpeed>();
    [SerializeField] public List<PersonSearchSpeed> ListSpeedPersonEnemy = new List<PersonSearchSpeed>();
    
    [SerializeField] public List<PersonSearchSpeed> AllPersonSpeed = new List<PersonSearchSpeed>();
    public bool CheckGoPersonUser;
    public bool CheckGoPersonEnemy;
    public bool RoundStart = false;
    public int levelPerson = 1;
    [SerializeField] public List<RuntimeAnimatorController> AnimatorPerson = new List<RuntimeAnimatorController>();
    public GameObject lozzeBoos;
    public GameObject WinBoos;
    public GameObject WinNagrandaFather;
    public GameObject WinNagrandaPrefab;
    public List<Sprite> SpriteNagrad = new List<Sprite>();

    IEnumerator UdarBattleIenumerator()
    {
        if (ListSpeedPersonUser.Count > 0 && ListSpeedPersonEnemy.Count > 0) //Проверяем что у врага и игрока есть персонажи
        {
            
            yield return new WaitForSeconds(1);
            foreach (var a in AllPersonSpeed.ToList()) //Перебираем персонажей игрока и варага
            {
                bool check = false;
                float _speed = 5;
                bool stan = false;
                bool molchanie = false;
                bool SetHill = false;
                bool rabstvo = false;
                List<int> personAllAttack = new List<int>();
                if (a.typePerson == "UserPerson")
                {
                    if (UserPersonidListSlot.Contains(a.idSlot))
                    {
                        foreach (var b in UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.ToList())
                        {
                            string[] server_info = b.Split(',');
                            if (server_info[0] == "Stan")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    stan = true;
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");

                                }
                                else
                                {
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                }
                            }
                            if (server_info[0] == "Silence")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    stan = true;
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");

                                }
                                else
                                {
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                }
                            }
                            if (server_info[0] == "Slavery")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    rabstvo = true;
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");

                                }
                                else
                                {
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                }
                            }
                        }
                        if (stan == false)
                        {
                            if (rabstvo == true)
                            {

                                bool kritDamageAll = false;
                                int idSlotAll = 0;
                                try
                                {
                                    float damage = 0;
                                    float attackUser = UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Attack_info;
                                    int EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                    while (EnemyClildSlot == a.idSlot)
                                    {
                                        EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                    }

                                    PersonBattleScript vrag = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>();
                                    float DefensEnemy = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Defens_info;
                                    damage = (attackUser * attackUser / (attackUser + DefensEnemy));
                                    bool kritDamage = false;
                                    int randYklon = UnityEngine.Random.Range(0, 100);
                                    //Уклонение
                                    if (randYklon > 0 && randYklon < vrag.Evasion)
                                    {
                                        //точность
                                        int randTocnost = UnityEngine.Random.Range(0, 100);
                                        if (randTocnost > 0 && randTocnost < UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Accuracy)
                                        {
                                            //Шанс крита и крит урон
                                            int randKrit = UnityEngine.Random.Range(0, 100);
                                            if (randKrit > 0 && randKrit < UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                            {
                                                int randNoKrit = UnityEngine.Random.Range(0, 100);
                                                if (randNoKrit > 0 && randNoKrit < UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                                {
                                                    Debug.Log("Не Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                }
                                                else
                                                {
                                                    Debug.Log("Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                    kritDamage = true;
                                                }

                                            }
                                            else
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }



                                        }
                                        else
                                        {
                                            damage = 0;
                                        }
                                    }
                                    else
                                    {
                                        //Шанс крита и крит урон
                                        int randKrit = UnityEngine.Random.Range(0, 100);
                                        if (randKrit > 0 && randKrit < UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                        {
                                            int randNoKrit = UnityEngine.Random.Range(0, 100);
                                            if (randNoKrit > 0 && randNoKrit < UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }
                                            else
                                            {
                                                Debug.Log("Крит");
                                                //Доп урон
                                                damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                kritDamage = true;
                                            }

                                        }
                                        else
                                        {
                                            Debug.Log("Не Крит");
                                            //Доп урон
                                            damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                            //Уменьшение урона
                                            damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                        }
                                    }

                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                    bool c = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                    if (c)
                                    {
                                        Debug.Log("Смерть персонажа");
                                    }
                                    check = true;
                                    if (kritDamage == false)
                                    {
                                        Debug.Log("Желтый");
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                        kritDamageAll = false;
                                        idSlotAll = EnemyClildSlot;
                                    }
                                    else
                                    {
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.red;
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                        Debug.Log("Красный");
                                        kritDamageAll = true;
                                        idSlotAll = EnemyClildSlot;
                                    }
                                    if (personAllAttack.Count > 0)
                                    {


                                        Vector3 target = new Vector3(UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x + 0.4f, UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                        Debug.Log("Хуита1");




                                    }
                                    else
                                    {

                                        Vector3 target = new Vector3(UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x + 0.4f, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                        Debug.Log("Хуита3");




                                    }




                                }
                                catch (Exception ex)
                                {
                                    Debug.LogException(ex);
                                    check = false;
                                }
                                if (check)
                                {
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = true;
                                    yield return new WaitForSeconds(1.25f);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = false;
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, UserPersonSpavn[a.idSlot].transform.position, _speed);
                                    try
                                    {
                                        if (personAllAttack.Count > 0)
                                        {
                                            foreach (var AttackEnemy in personAllAttack)
                                            {
                                                UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                            }
                                        }
                                        else
                                        {
                                            UserPersonSpavn[idSlotAll].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                        }


                                    }
                                    catch
                                    {

                                    }

                                    check = false;
                                }
                            }
                            else if (molchanie == false)
                            {
                                bool kritDamageAll = false;
                                int idSlotAll = 0;
                                try
                                {
                                    float damage = 0;
                                    float attackUser = UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Attack_info;
                                    int EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                    PersonBattleScript vrag = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>();
                                    float DefensEnemy = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Defens_info;
                                    damage = (attackUser * attackUser / (attackUser + DefensEnemy));
                                    if (UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill1Play != "")
                                    {
                                        Debug.Log("Скил 1");
                                        string[] server_info = UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill1Play.Split(',');
                                        if (server_info[27] == "Attack")
                                        {
                                            damage = damage * (100 + Convert.ToInt32(server_info[3])) / 100;
                                            bool Dead = false;
                                            
                                            //Цель Противник с ниже % ХП
                                            if (server_info[25] == "2" || Convert.ToInt32(server_info[25]) == 2)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in ListSpeedPersonEnemy)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            //Цель Противник с высшей атакой
                                            else if (server_info[25] == "3" || Convert.ToInt32(server_info[25]) == 3)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in ListSpeedPersonEnemy)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Противник с высшим БС
                                            else if (server_info[25] == "4" || Convert.ToInt32(server_info[25]) == 4)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in ListSpeedPersonEnemy)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.bs).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Персонаж на против
                                            else if (server_info[25] == "7" || Convert.ToInt32(server_info[25]) == 7)
                                            {
                                                personAllAttack.Clear();
                                                if (EnemyPersonSpavn[a.idSlot].transform.GetChild(0) != null)
                                                {
                                                    EnemyClildSlot = a.idSlot;
                                                }
                                                else
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count)];
                                                }

                                            }
                                            //Цель Случайный персонаж
                                            else if (server_info[25] == "8" || Convert.ToInt32(server_info[25]) == 8)
                                            {
                                                personAllAttack.Clear();
                                                EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];

                                            }
                                            //Цель Случайные персонажи в количеств N 
                                            else if (server_info[25] == "9" || Convert.ToInt32(server_info[25]) == 9)
                                            {
                                                personAllAttack.Clear();
                                                List<int> deleteId = new List<int>();
                                                foreach (int g in EnemyPersonidListSlot)
                                                {
                                                    deleteId.Add(g);
                                                }

                                                for (int i = 0; i < Convert.ToInt32(server_info[40]); i++)
                                                {

                                                    int Enemy = deleteId[UnityEngine.Random.Range(0, deleteId.Count)];
                                                    Debug.Log(Enemy);
                                                    if (!personAllAttack.Contains(Enemy))
                                                    {
                                                        personAllAttack.Add(Enemy);
                                                        deleteId.Remove(Enemy);
                                                    }
                                                    else
                                                    {

                                                    }
                                                }

                                            }
                                            //Цель горизонтальный ряд - верхний строй
                                            else if (server_info[25] == "10" || Convert.ToInt32(server_info[25]) == 10)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель горизонтальный ряд - средний строй
                                            else if (server_info[25] == "11" || Convert.ToInt32(server_info[25]) == 11)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Противники по горизонтали 
                                            else if (server_info[25] == "12" || Convert.ToInt32(server_info[25]) == 12)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Всех персонажей 
                                            else if (server_info[25] == "13" || Convert.ToInt32(server_info[25]) == 13)
                                            {
                                                personAllAttack.Clear();
                                                foreach (int g in EnemyPersonidListSlot)
                                                {
                                                    personAllAttack.Add(g);
                                                }
                                            }
                                            //Цель Передний ряд
                                            else if (server_info[25] == "14" || Convert.ToInt32(server_info[25]) == 14)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Средний ряд
                                            else if (server_info[25] == "15" || Convert.ToInt32(server_info[25]) == 15)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Задний ряд 
                                            else if (server_info[25] == "16" || Convert.ToInt32(server_info[25]) == 16)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Два передних ряда 
                                            else if (server_info[25] == "17" || Convert.ToInt32(server_info[25]) == 17)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (EnemyPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Два задних ряда
                                            else if (server_info[25] == "18" || Convert.ToInt32(server_info[25]) == 18)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            for (int i = 0; i < Convert.ToInt32(server_info[4]); i++)
                                            {
                                                try
                                                {
                                                    if (personAllAttack.Count > 0)
                                                    {
                                                        foreach (var AttackEnemy in personAllAttack)
                                                        {
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                            bool c = EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                            if (c)
                                                            {
                                                                //Dead = true;
                                                                Debug.Log("Смерть персонажа");
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                        bool c = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                        if (c)
                                                        {
                                                            Dead = true;
                                                            Debug.Log("Смерть персонажа");
                                                        }
                                                    }

                                                }
                                                catch
                                                {

                                                }


                                            }
                                            int RandomBuffDebuf = 99;
                                            if (personAllAttack.Count > 0)
                                            {
                                                foreach (var AttackEnemy in personAllAttack)
                                                {

                                                    //Кровотечение
                                                    Debug.Log(server_info[19]);
                                                    if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Яд
                                                    if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Стан
                                                    if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }

                                                    //Молчание
                                                    if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Рабство
                                                    if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                }
                                            }
                                            else if (Dead == false)
                                            {
                                                //Кровотечение
                                                Debug.Log(server_info[19]);
                                                if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Яд
                                                if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Стан
                                                if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }

                                                //Молчание
                                                if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Рабство
                                                if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                            }



                                        }
                                        else if (server_info[27] == "Hill")
                                        {
                                            if (server_info[25] == "5" || Convert.ToInt32(server_info[25]) == 5)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            else if (server_info[25] == "1" || Convert.ToInt32(server_info[25]) == 1)
                                            {
                                                EnemyClildSlot = a.idSlot;
                                            }
                                            else if (server_info[25] == "6" || Convert.ToInt32(server_info[25]) == 6)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            if (server_info[3] != null && Convert.ToInt32(server_info[3]) != 0)
                                            {

                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[3])) / 100;
                                                if (UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }
                                                if ((hill + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                                Debug.Log("Зеленый");

                                            }
                                            else if (server_info[15] != null && Convert.ToInt32(server_info[15]) != 0)
                                            {
                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[15])) / 100;
                                                if (UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }

                                                if ((hill + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                            }
                                            //повышение атаки
                                            int RandomBuffDebuf = 10;
                                            if (server_info[41] != "" || server_info[41] != null || Convert.ToInt32(server_info[41]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"AttackActivBoost,{server_info[41]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //повышение урона
                                            if (server_info[42] != "" || server_info[42] != null || Convert.ToInt32(server_info[42]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"YronActivBoost,{server_info[42]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение скорости
                                            if (server_info[43] != "" || server_info[43] != null || Convert.ToInt32(server_info[43]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"SpeedActivBoost,{server_info[43]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }

                                            //Повышение ХП 
                                            if (server_info[44] != "" || server_info[44] != null || Convert.ToInt32(server_info[44]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"HpActivBoost,{server_info[44]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение защиты
                                            if (server_info[45] != "" || server_info[45] != null || Convert.ToInt32(server_info[45]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"DefensActivBoost,{server_info[45]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            SetHill = true;
                                            Debug.Log(SetHill);
                                        }
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill1Play = "";
                                    }
                                    else if (UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill2Play != "")
                                    {
                                        Debug.Log("Скил 2");
                                        string[] server_info = UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill2Play.Split(',');
                                        if (server_info[27] == "Attack")
                                        {
                                            Debug.Log("Хуита");
                                            damage = damage * (100 + Convert.ToInt32(server_info[3])) / 100;
                                            bool Dead = false;
                                            //Цель Противник с ниже % ХП
                                            if (server_info[25] == "2" || Convert.ToInt32(server_info[25]) == 2)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            //Цель Противник с высшей атакой
                                            else if (server_info[25] == "3" || Convert.ToInt32(server_info[25]) == 3)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Противник с высшим БС
                                            else if (server_info[25] == "4" || Convert.ToInt32(server_info[25]) == 4)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.bs).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Персонаж на против
                                            else if (server_info[25] == "7" || Convert.ToInt32(server_info[25]) == 7)
                                            {
                                                personAllAttack.Clear();
                                                if (EnemyPersonSpavn[a.idSlot].transform.GetChild(0) != null)
                                                {
                                                    EnemyClildSlot = a.idSlot;
                                                }
                                                else
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Случайный персонаж
                                            else if (server_info[25] == "8" || Convert.ToInt32(server_info[25]) == 8)
                                            {
                                                personAllAttack.Clear();
                                                EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];

                                            }
                                            //Цель Случайные персонажи в количеств N 
                                            else if (server_info[25] == "9" || Convert.ToInt32(server_info[25]) == 9)
                                            {
                                                personAllAttack.Clear();
                                                List<int> deleteId = new List<int>();
                                                foreach (int g in EnemyPersonidListSlot)
                                                {
                                                    deleteId.Add(g);
                                                }

                                                for (int i = 0; i < Convert.ToInt32(server_info[40]); i++)
                                                {

                                                    int Enemy = deleteId[UnityEngine.Random.Range(0, deleteId.Count)];
                                                    Debug.Log(Enemy);
                                                    if (!personAllAttack.Contains(Enemy))
                                                    {
                                                        personAllAttack.Add(Enemy);
                                                        deleteId.Remove(Enemy);
                                                    }
                                                    else
                                                    {

                                                    }
                                                }

                                            }
                                            //Цель горизонтальный ряд - верхний строй
                                            else if (server_info[25] == "10" || Convert.ToInt32(server_info[25]) == 10)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель горизонтальный ряд - средний строй
                                            else if (server_info[25] == "11" || Convert.ToInt32(server_info[25]) == 11)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Противники по горизонтали 
                                            else if (server_info[25] == "12" || Convert.ToInt32(server_info[25]) == 12)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Всех персонажей 
                                            else if (server_info[25] == "13" || Convert.ToInt32(server_info[25]) == 13)
                                            {
                                                personAllAttack.Clear();
                                                foreach (int g in EnemyPersonidListSlot)
                                                {
                                                    personAllAttack.Add(g);
                                                }
                                            }
                                            //Цель Передний ряд
                                            else if (server_info[25] == "14" || Convert.ToInt32(server_info[25]) == 14)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Средний ряд
                                            else if (server_info[25] == "15" || Convert.ToInt32(server_info[25]) == 15)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Задний ряд 
                                            else if (server_info[25] == "16" || Convert.ToInt32(server_info[25]) == 16)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Два передних ряда 
                                            else if (server_info[25] == "17" || Convert.ToInt32(server_info[25]) == 17)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (EnemyPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Два задних ряда
                                            else if (server_info[25] == "18" || Convert.ToInt32(server_info[25]) == 18)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            for (int i = 0; i < Convert.ToInt32(server_info[4]); i++)
                                            {
                                                try
                                                {
                                                    if (personAllAttack.Count > 0)
                                                    {
                                                        foreach (var AttackEnemy in personAllAttack)
                                                        {
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                            bool c = EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                            if (c)
                                                            {
                                                                //Dead = true;
                                                                Debug.Log("Смерть персонажа");
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                        bool c = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                        if (c)
                                                        {
                                                            Dead = true;
                                                            Debug.Log("Смерть персонажа");
                                                        }
                                                    }

                                                }
                                                catch
                                                {

                                                }

                                            }
                                            if (personAllAttack.Count > 0)
                                            {
                                                foreach (var AttackEnemy in personAllAttack)
                                                {
                                                    int RandomBuffDebuf = 99;
                                                    //Кровотечение
                                                    Debug.Log(server_info[19]);
                                                    if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Яд
                                                    if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Стан
                                                    if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }

                                                    //Молчание
                                                    if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Рабство
                                                    if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                }
                                            }
                                            else if (Dead == false)
                                            {
                                                int RandomBuffDebuf = 99;
                                                //Кровотечение
                                                Debug.Log(server_info[19]);
                                                if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Яд
                                                if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Стан
                                                if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }

                                                //Молчание
                                                if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Рабство
                                                if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                            }



                                        }
                                        else if (server_info[27] == "Hill")
                                        {
                                            if (server_info[25] == "5" || Convert.ToInt32(server_info[25]) == 5)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            else if (server_info[25] == "1" || Convert.ToInt32(server_info[25]) == 1)
                                            {
                                                EnemyClildSlot = a.idSlot;
                                            }
                                            else if (server_info[25] == "6" || Convert.ToInt32(server_info[25]) == 6)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            if (server_info[3] != null && Convert.ToInt32(server_info[3]) != 0)
                                            {
                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[3])) / 100;
                                                if (UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }
                                                if ((hill + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                                Debug.Log("Зеленый");

                                            }
                                            else if (server_info[15] != null && Convert.ToInt32(server_info[15]) != 0)
                                            {
                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[15])) / 100;
                                                if (UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }

                                                if ((hill + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                            }
                                            //повышение атаки
                                            int RandomBuffDebuf = 10;
                                            if (server_info[41] != "" || server_info[41] != null || Convert.ToInt32(server_info[41]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"AttackActivBoost,{server_info[41]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //повышение урона
                                            if (server_info[42] != "" || server_info[42] != null || Convert.ToInt32(server_info[42]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"YronActivBoost,{server_info[42]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение скорости
                                            if (server_info[43] != "" || server_info[43] != null || Convert.ToInt32(server_info[43]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"SpeedActivBoost,{server_info[43]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }

                                            //Повышение ХП 
                                            if (server_info[44] != "" || server_info[44] != null || Convert.ToInt32(server_info[44]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"HpActivBoost,{server_info[44]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение защиты
                                            if (server_info[45] != "" || server_info[45] != null || Convert.ToInt32(server_info[45]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"DefensActivBoost,{server_info[45]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            SetHill = true;
                                            Debug.Log(SetHill);
                                        }
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill2Play = "";

                                    }
                                    else if (UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill3Play != "")
                                    {
                                        string[] server_info = UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill3Play.Split(',');
                                        Debug.Log("Скил 3");
                                        if (server_info[27] == "Attack")
                                        {
                                            Debug.Log("Хуита");
                                            damage = damage * (100 + Convert.ToInt32(server_info[3])) / 100;
                                            bool Dead = false;
                                            //Цель Противник с ниже % ХП
                                            if (server_info[25] == "2" || Convert.ToInt32(server_info[25]) == 2)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            //Цель Противник с высшей атакой
                                            else if (server_info[25] == "3" || Convert.ToInt32(server_info[25]) == 3)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Противник с высшим БС
                                            else if (server_info[25] == "4" || Convert.ToInt32(server_info[25]) == 4)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.bs).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Персонаж на против
                                            else if (server_info[25] == "7" || Convert.ToInt32(server_info[25]) == 7)
                                            {
                                                personAllAttack.Clear();
                                                if (EnemyPersonSpavn[a.idSlot].transform.GetChild(0) != null)
                                                {
                                                    EnemyClildSlot = a.idSlot;
                                                }
                                                else
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Случайный персонаж
                                            else if (server_info[25] == "8" || Convert.ToInt32(server_info[25]) == 8)
                                            {
                                                personAllAttack.Clear();
                                                EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];

                                            }
                                            //Цель Случайные персонажи в количеств N 
                                            else if (server_info[25] == "9" || Convert.ToInt32(server_info[25]) == 9)
                                            {
                                                personAllAttack.Clear();
                                                List<int> deleteId = new List<int>();
                                                foreach (int g in EnemyPersonidListSlot)
                                                {
                                                    deleteId.Add(g);
                                                }

                                                for (int i = 0; i < Convert.ToInt32(server_info[40]); i++)
                                                {

                                                    int Enemy = deleteId[UnityEngine.Random.Range(0, deleteId.Count)];
                                                    Debug.Log(Enemy);
                                                    if (!personAllAttack.Contains(Enemy))
                                                    {
                                                        personAllAttack.Add(Enemy);
                                                        deleteId.Remove(Enemy);
                                                    }
                                                    else
                                                    {

                                                    }
                                                }

                                            }
                                            //Цель горизонтальный ряд - верхний строй
                                            else if (server_info[25] == "10" || Convert.ToInt32(server_info[25]) == 10)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель горизонтальный ряд - средний строй
                                            else if (server_info[25] == "11" || Convert.ToInt32(server_info[25]) == 11)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Противники по горизонтали 
                                            else if (server_info[25] == "12" || Convert.ToInt32(server_info[25]) == 12)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Всех персонажей 
                                            else if (server_info[25] == "13" || Convert.ToInt32(server_info[25]) == 13)
                                            {
                                                personAllAttack.Clear();
                                                foreach (int g in EnemyPersonidListSlot)
                                                {
                                                    personAllAttack.Add(g);
                                                }
                                            }
                                            //Цель Передний ряд
                                            else if (server_info[25] == "14" || Convert.ToInt32(server_info[25]) == 14)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Средний ряд
                                            else if (server_info[25] == "15" || Convert.ToInt32(server_info[25]) == 15)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Задний ряд 
                                            else if (server_info[25] == "16" || Convert.ToInt32(server_info[25]) == 16)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (EnemyPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Два передних ряда 
                                            else if (server_info[25] == "17" || Convert.ToInt32(server_info[25]) == 17)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (EnemyPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Два задних ряда
                                            else if (server_info[25] == "18" || Convert.ToInt32(server_info[25]) == 18)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (EnemyPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (EnemyPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            for (int i = 0; i < Convert.ToInt32(server_info[4]); i++)
                                            {
                                                try
                                                {
                                                    if (personAllAttack.Count > 0)
                                                    {
                                                        foreach (var AttackEnemy in personAllAttack)
                                                        {
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                            EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                            bool c = EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                            if (c)
                                                            {
                                                                //Dead = true;
                                                                Debug.Log("Смерть персонажа");
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                        bool c = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                        if (c)
                                                        {
                                                            Dead = true;
                                                            Debug.Log("Смерть персонажа");
                                                        }
                                                    }

                                                }
                                                catch
                                                {

                                                }

                                            }
                                            if (personAllAttack.Count > 0)
                                            {
                                                foreach (var AttackEnemy in personAllAttack)
                                                {
                                                    int RandomBuffDebuf = 99;
                                                    //Кровотечение
                                                    Debug.Log(server_info[19]);
                                                    if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Яд
                                                    if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Стан
                                                    if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }

                                                    //Молчание
                                                    if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Рабство
                                                    if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (EnemyPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                                    EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                }
                                            }
                                            else if (Dead == false)
                                            {
                                                int RandomBuffDebuf = 99;
                                                //Кровотечение
                                                Debug.Log(server_info[19]);
                                                if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Яд
                                                if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Стан
                                                if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }

                                                //Молчание
                                                if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Рабство
                                                if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                            }



                                        }
                                        else if (server_info[27] == "Hill")
                                        {
                                            if (server_info[25] == "5" || Convert.ToInt32(server_info[25]) == 5)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            else if (server_info[25] == "1" || Convert.ToInt32(server_info[25]) == 1)
                                            {
                                                EnemyClildSlot = a.idSlot;
                                            }
                                            else if (server_info[25] == "6" || Convert.ToInt32(server_info[25]) == 6)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            if (server_info[3] != null && Convert.ToInt32(server_info[3]) != 0)
                                            {
                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[3])) / 100;
                                                if (UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }
                                                if ((hill + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                                Debug.Log("Зеленый");

                                            }
                                            else if (server_info[15] != null && Convert.ToInt32(server_info[15]) != 0)
                                            {
                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[15])) / 100;
                                                if (UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }

                                                if ((hill + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                            }
                                            //повышение атаки
                                            int RandomBuffDebuf = 10;
                                            if (server_info[41] != "" || server_info[41] != null || Convert.ToInt32(server_info[41]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"AttackActivBoost,{server_info[41]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //повышение урона
                                            if (server_info[42] != "" || server_info[42] != null || Convert.ToInt32(server_info[42]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"YronActivBoost,{server_info[42]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение скорости
                                            if (server_info[43] != "" || server_info[43] != null || Convert.ToInt32(server_info[43]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"SpeedActivBoost,{server_info[43]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }

                                            //Повышение ХП 
                                            if (server_info[44] != "" || server_info[44] != null || Convert.ToInt32(server_info[44]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"HpActivBoost,{server_info[44]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение защиты
                                            if (server_info[45] != "" || server_info[45] != null || Convert.ToInt32(server_info[45]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"DefensActivBoost,{server_info[45]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            SetHill = true;
                                            Debug.Log(SetHill);
                                        }
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill3Play = "";

                                    }
                                    else
                                    {
                                        bool kritDamage = false;
                                        int randYklon = UnityEngine.Random.Range(0, 100);
                                        //Уклонение
                                        if (randYklon > 0 && randYklon < vrag.Evasion)
                                        {
                                            //точность
                                            int randTocnost = UnityEngine.Random.Range(0, 100);
                                            if (randTocnost > 0 && randTocnost < UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Accuracy)
                                            {
                                                //Шанс крита и крит урон
                                                int randKrit = UnityEngine.Random.Range(0, 100);
                                                if (randKrit > 0 && randKrit < UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                                {
                                                    int randNoKrit = UnityEngine.Random.Range(0, 100);
                                                    if (randNoKrit > 0 && randNoKrit < EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                                    {
                                                        Debug.Log("Не Крит");
                                                        //Доп урон
                                                        damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                        //Уменьшение урона
                                                        damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                    }
                                                    else
                                                    {
                                                        Debug.Log("Крит");
                                                        //Доп урон
                                                        damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                        //Уменьшение урона
                                                        damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                        damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                        kritDamage = true;
                                                    }

                                                }
                                                else
                                                {
                                                    Debug.Log("Не Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                }



                                            }
                                            else
                                            {
                                                damage = 0;
                                            }
                                        }
                                        else
                                        {
                                            //Шанс крита и крит урон
                                            int randKrit = UnityEngine.Random.Range(0, 100);
                                            if (randKrit > 0 && randKrit < UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                            {
                                                int randNoKrit = UnityEngine.Random.Range(0, 100);
                                                if (randNoKrit > 0 && randNoKrit < EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                                {
                                                    Debug.Log("Не Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                }
                                                else
                                                {
                                                    Debug.Log("Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                    kritDamage = true;
                                                }

                                            }
                                            else
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }
                                        }

                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                        bool c = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                        if (c)
                                        {
                                            Debug.Log("Смерть персонажа");
                                        }
                                        check = true;
                                        if (kritDamage == false)
                                        {
                                            Debug.Log("Желтый");
                                            EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                            EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                            EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                            kritDamageAll = false;
                                            idSlotAll = EnemyClildSlot;
                                        }
                                        else
                                        {
                                            EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.red;
                                            EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                            EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                            Debug.Log("Красный");
                                            kritDamageAll = true;
                                            idSlotAll = EnemyClildSlot;
                                        }
                                    }
                                    if (personAllAttack.Count > 0)
                                    {
                                        Vector3 target = new Vector3(EnemyPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x - 0.4f, EnemyPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, EnemyPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                    }
                                    else
                                    {
                                        if (SetHill == false)
                                        {
                                            Vector3 target = new Vector3(EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x - 0.4f, EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                            UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                            check = true;
                                        }
                                        else if (SetHill == true && a.idSlot == EnemyClildSlot)
                                        {
                                            check = true;
                                        }
                                        else
                                        {
                                            Vector3 target = new Vector3(UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x - 0.4f, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                            UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                            check = true;
                                            Debug.Log("Хуита4");
                                        }

                                    }




                                }
                                catch (Exception ex)
                                {
                                    Debug.LogException(ex);
                                    check = false;
                                }
                                if (check)
                                {

                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = true;
                                    yield return new WaitForSeconds(1.25f);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = false;
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, UserPersonSpavn[a.idSlot].transform.position, _speed);
                                    try
                                    {
                                        if (personAllAttack.Count > 0)
                                        {
                                            foreach (var AttackEnemy in personAllAttack)
                                            {
                                                EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                            }
                                        }
                                        else
                                        {
                                            EnemyPersonSpavn[idSlotAll].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                        }


                                    }
                                    catch
                                    {

                                    }

                                    check = false;
                                }
                            }
                            else
                            {
                                bool kritDamageAll = false;
                                int idSlotAll = 0;
                                try
                                {
                                    float damage = 0;
                                    float attackUser = UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Attack_info;
                                    int EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                    PersonBattleScript vrag = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>();
                                    float DefensEnemy = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Defens_info;
                                    damage = (attackUser * attackUser / (attackUser + DefensEnemy));
                                    bool kritDamage = false;
                                    int randYklon = UnityEngine.Random.Range(0, 100);
                                    //Уклонение
                                    if (randYklon > 0 && randYklon < vrag.Evasion)
                                    {
                                        //точность
                                        int randTocnost = UnityEngine.Random.Range(0, 100);
                                        if (randTocnost > 0 && randTocnost < UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Accuracy)
                                        {
                                            //Шанс крита и крит урон
                                            int randKrit = UnityEngine.Random.Range(0, 100);
                                            if (randKrit > 0 && randKrit < UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                            {
                                                int randNoKrit = UnityEngine.Random.Range(0, 100);
                                                if (randNoKrit > 0 && randNoKrit < EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                                {
                                                    Debug.Log("Не Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                }
                                                else
                                                {
                                                    Debug.Log("Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                    damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                    kritDamage = true;
                                                }

                                            }
                                            else
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }



                                        }
                                        else
                                        {
                                            damage = 0;
                                        }
                                    }
                                    else
                                    {
                                        //Шанс крита и крит урон
                                        int randKrit = UnityEngine.Random.Range(0, 100);
                                        if (randKrit > 0 && randKrit < UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                        {
                                            int randNoKrit = UnityEngine.Random.Range(0, 100);
                                            if (randNoKrit > 0 && randNoKrit < EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }
                                            else
                                            {
                                                Debug.Log("Крит");
                                                //Доп урон
                                                damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                kritDamage = true;
                                            }

                                        }
                                        else
                                        {
                                            Debug.Log("Не Крит");
                                            //Доп урон
                                            damage = damage * (100 + UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                            //Уменьшение урона
                                            damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                        }
                                    }

                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                    bool c = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                    if (c)
                                    {
                                        Debug.Log("Смерть персонажа");
                                    }
                                    check = true;
                                    if (kritDamage == false)
                                    {
                                        Debug.Log("Желтый");
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                        kritDamageAll = false;
                                        idSlotAll = EnemyClildSlot;
                                    }
                                    else
                                    {
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.red;
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                        Debug.Log("Красный");
                                        kritDamageAll = true;
                                        idSlotAll = EnemyClildSlot;
                                    }
                                    if (personAllAttack.Count > 0)
                                    {


                                        Vector3 target = new Vector3(EnemyPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x - 0.4f, EnemyPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, EnemyPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                        Debug.Log("Хуита1");




                                    }
                                    else
                                    {

                                        Vector3 target = new Vector3(EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x - 0.4f, EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                        Debug.Log("Хуита3");




                                    }




                                }
                                catch (Exception ex)
                                {
                                    Debug.LogException(ex);
                                    check = false;
                                }
                                if (check)
                                {

                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = true;
                                    yield return new WaitForSeconds(1.25f);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = false;
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, UserPersonSpavn[a.idSlot].transform.position, _speed);
                                    try
                                    {
                                        if (personAllAttack.Count > 0)
                                        {
                                            foreach (var AttackEnemy in personAllAttack)
                                            {
                                                EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                            }
                                        }
                                        else
                                        {
                                            EnemyPersonSpavn[idSlotAll].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                        }


                                    }
                                    catch
                                    {

                                    }

                                    check = false;
                                }
                            }

                        }
                    }
                    
                    



                }
                else if (a.typePerson == "Enemy")
                {
                    if (EnemyPersonidListSlot.Contains(a.idSlot))
                    {
                        foreach (var b in EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.ToList())
                        {
                            string[] server_info = b.Split(',');
                            if (server_info[0] == "Stan")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    stan = true;
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");

                                }
                                else
                                {
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                }
                            }
                            if (server_info[0] == "Silence")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    stan = true;
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");

                                }
                                else
                                {
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                }
                            }
                            if (server_info[0] == "Slavery")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    rabstvo = true;
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");

                                }
                                else
                                {
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                }
                            }
                        }
                        if (stan == false)
                        {
                            if (rabstvo == true)
                            {

                                bool kritDamageAll = false;
                                int idSlotAll = 0;
                                try
                                {
                                    float damage = 0;
                                    float attackUser = EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Attack_info;
                                    int EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                    while (EnemyClildSlot == a.idSlot)
                                    {
                                        EnemyClildSlot = EnemyPersonidListSlot[UnityEngine.Random.Range(0, EnemyPersonidListSlot.Count - 1)];
                                    }

                                    PersonBattleScript vrag = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>();
                                    float DefensEnemy = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Defens_info;
                                    damage = (attackUser * attackUser / (attackUser + DefensEnemy));
                                    bool kritDamage = false;
                                    int randYklon = UnityEngine.Random.Range(0, 100);
                                    //Уклонение
                                    if (randYklon > 0 && randYklon < vrag.Evasion)
                                    {
                                        //точность
                                        int randTocnost = UnityEngine.Random.Range(0, 100);
                                        if (randTocnost > 0 && randTocnost < EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Accuracy)
                                        {
                                            //Шанс крита и крит урон
                                            int randKrit = UnityEngine.Random.Range(0, 100);
                                            if (randKrit > 0 && randKrit < EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                            {
                                                int randNoKrit = UnityEngine.Random.Range(0, 100);
                                                if (randNoKrit > 0 && randNoKrit < EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                                {
                                                    Debug.Log("Не Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                }
                                                else
                                                {
                                                    Debug.Log("Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                    kritDamage = true;
                                                }

                                            }
                                            else
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }



                                        }
                                        else
                                        {
                                            damage = 0;
                                        }
                                    }
                                    else
                                    {
                                        //Шанс крита и крит урон
                                        int randKrit = UnityEngine.Random.Range(0, 100);
                                        if (randKrit > 0 && randKrit < EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                        {
                                            int randNoKrit = UnityEngine.Random.Range(0, 100);
                                            if (randNoKrit > 0 && randNoKrit < EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }
                                            else
                                            {
                                                Debug.Log("Крит");
                                                //Доп урон
                                                damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                kritDamage = true;
                                            }

                                        }
                                        else
                                        {
                                            Debug.Log("Не Крит");
                                            //Доп урон
                                            damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                            //Уменьшение урона
                                            damage = damage * (100 - EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                        }
                                    }

                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                    bool c = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                    if (c)
                                    {
                                        Debug.Log("Смерть персонажа");
                                    }
                                    check = true;
                                    if (kritDamage == false)
                                    {
                                        Debug.Log("Желтый");
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                        kritDamageAll = false;
                                        idSlotAll = EnemyClildSlot;
                                    }
                                    else
                                    {
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.red;
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                        EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                        Debug.Log("Красный");
                                        kritDamageAll = true;
                                        idSlotAll = EnemyClildSlot;
                                    }
                                    if (personAllAttack.Count > 0)
                                    {


                                        Vector3 target = new Vector3(UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x + 0.4f, UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                        Debug.Log("Хуита1");




                                    }
                                    else
                                    {

                                        Vector3 target = new Vector3(UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x + 0.4f, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                        Debug.Log("Хуита3");




                                    }




                                }
                                catch (Exception ex)
                                {
                                    Debug.LogException(ex);
                                    check = false;
                                }
                                if (check)
                                {
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpFill.gameObject.transform.rotation = new UnityEngine.Quaternion(0, 180, 0, 0);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = true;
                                    yield return new WaitForSeconds(1.25f);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = false;
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, UserPersonSpavn[a.idSlot].transform.position, _speed);
                                    try
                                    {
                                        if (personAllAttack.Count > 0)
                                        {
                                            foreach (var AttackEnemy in personAllAttack)
                                            {
                                                EnemyPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                            }
                                        }
                                        else
                                        {
                                            EnemyPersonSpavn[idSlotAll].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                        }


                                    }
                                    catch
                                    {

                                    }

                                    check = false;
                                }
                            }
                            else if (molchanie == false)
                            {
                                bool kritDamageAll = false;
                                int idSlotAll = 0;
                                try
                                {
                                    float damage = 0;
                                    float attackUser = EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Attack_info;
                                    UnityEngine.Debug.Log(UserPersonidListSlot.Count);
                                    int EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count)];
                                    PersonBattleScript vrag = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>();
                                    float DefensEnemy = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Defens_info;
                                    damage = (attackUser * attackUser / (attackUser + DefensEnemy));
                                    if (EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill1Play != "")
                                    {
                                        Debug.Log("Скил 1");
                                        string[] server_info = EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill1Play.Split(',');
                                        if (server_info[27] == "Attack")
                                        {
                                            damage = damage * (100 + Convert.ToInt32(server_info[3])) / 100;
                                            bool Dead = false;
                                            //Цель Противник с ниже % ХП
                                            if (server_info[25] == "2" || Convert.ToInt32(server_info[25]) == 2)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            //Цель Противник с высшей атакой
                                            else if (server_info[25] == "3" || Convert.ToInt32(server_info[25]) == 3)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Противник с высшим БС
                                            else if (server_info[25] == "4" || Convert.ToInt32(server_info[25]) == 4)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.bs).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Персонаж на против
                                            else if (server_info[25] == "7" || Convert.ToInt32(server_info[25]) == 7)
                                            {
                                                personAllAttack.Clear();
                                                if (UserPersonSpavn[a.idSlot].transform.GetChild(0) != null)
                                                {
                                                    EnemyClildSlot = a.idSlot;
                                                }
                                                else
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Случайный персонаж
                                            else if (server_info[25] == "8" || Convert.ToInt32(server_info[25]) == 8)
                                            {
                                                personAllAttack.Clear();
                                                EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];

                                            }
                                            //Цель Случайные персонажи в количеств N 
                                            else if (server_info[25] == "9" || Convert.ToInt32(server_info[25]) == 9)
                                            {
                                                personAllAttack.Clear();
                                                List<int> deleteId = new List<int>();
                                                foreach (int g in UserPersonidListSlot)
                                                {
                                                    deleteId.Add(g);
                                                }

                                                for (int i = 0; i < Convert.ToInt32(server_info[40]); i++)
                                                {

                                                    int Enemy = deleteId[UnityEngine.Random.Range(0, deleteId.Count)];
                                                    Debug.Log(Enemy);
                                                    if (!personAllAttack.Contains(Enemy))
                                                    {
                                                        personAllAttack.Add(Enemy);
                                                        deleteId.Remove(Enemy);
                                                    }
                                                    else
                                                    {

                                                    }
                                                }

                                            }
                                            //Цель горизонтальный ряд - верхний строй
                                            else if (server_info[25] == "10" || Convert.ToInt32(server_info[25]) == 10)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель горизонтальный ряд - средний строй
                                            else if (server_info[25] == "11" || Convert.ToInt32(server_info[25]) == 11)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Противники по горизонтали 
                                            else if (server_info[25] == "12" || Convert.ToInt32(server_info[25]) == 12)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Всех персонажей 
                                            else if (server_info[25] == "13" || Convert.ToInt32(server_info[25]) == 13)
                                            {
                                                personAllAttack.Clear();
                                                foreach (int g in UserPersonidListSlot)
                                                {
                                                    personAllAttack.Add(g);
                                                }
                                            }
                                            //Цель Передний ряд
                                            else if (server_info[25] == "14" || Convert.ToInt32(server_info[25]) == 14)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Средний ряд
                                            else if (server_info[25] == "15" || Convert.ToInt32(server_info[25]) == 15)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Задний ряд 
                                            else if (server_info[25] == "16" || Convert.ToInt32(server_info[25]) == 16)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Два передних ряда 
                                            else if (server_info[25] == "17" || Convert.ToInt32(server_info[25]) == 17)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (UserPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Два задних ряда
                                            else if (server_info[25] == "18" || Convert.ToInt32(server_info[25]) == 18)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (UserPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (UserPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (UserPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            for (int i = 0; i < Convert.ToInt32(server_info[4]); i++)
                                            {
                                                try
                                                {
                                                    if (personAllAttack.Count > 0)
                                                    {
                                                        foreach (var AttackEnemy in personAllAttack)
                                                        {
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                            bool c = UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                            if (c)
                                                            {
                                                                //Dead = true;
                                                                Debug.Log("Смерть персонажа");
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                        bool c = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                        if (c)
                                                        {
                                                            Dead = true;
                                                            Debug.Log("Смерть персонажа");
                                                        }
                                                    }

                                                }
                                                catch
                                                {

                                                }


                                            }
                                            int RandomBuffDebuf = 99;
                                            if (personAllAttack.Count > 0)
                                            {
                                                foreach (var AttackEnemy in personAllAttack)
                                                {

                                                    //Кровотечение
                                                    Debug.Log(server_info[19]);
                                                    if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Яд
                                                    if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Стан
                                                    if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }

                                                    //Молчание
                                                    if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Рабство
                                                    if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                }
                                            }
                                            else if (Dead == false)
                                            {
                                                //Кровотечение
                                                Debug.Log(server_info[19]);
                                                if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Яд
                                                if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Стан
                                                if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }

                                                //Молчание
                                                if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Рабство
                                                if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                            }



                                        }
                                        else if (server_info[27] == "Hill")
                                        {
                                            if (server_info[25] == "5" || Convert.ToInt32(server_info[25]) == 5)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            else if (server_info[25] == "1" || Convert.ToInt32(server_info[25]) == 1)
                                            {
                                                EnemyClildSlot = a.idSlot;
                                            }
                                            else if (server_info[25] == "6" || Convert.ToInt32(server_info[25]) == 6)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            if (server_info[3] != null && Convert.ToInt32(server_info[3]) != 0)
                                            {

                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[3])) / 100;
                                                if (EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }
                                                if ((hill + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                                Debug.Log("Зеленый");

                                            }
                                            else if (server_info[15] != null && Convert.ToInt32(server_info[15]) != 0)
                                            {
                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[15])) / 100;
                                                if (EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }

                                                if ((hill + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                            }
                                            //повышение атаки
                                            int RandomBuffDebuf = 10;
                                            if (server_info[41] != "" || server_info[41] != null || Convert.ToInt32(server_info[41]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"AttackActivBoost,{server_info[41]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //повышение урона
                                            if (server_info[42] != "" || server_info[42] != null || Convert.ToInt32(server_info[42]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"YronActivBoost,{server_info[42]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение скорости
                                            if (server_info[43] != "" || server_info[43] != null || Convert.ToInt32(server_info[43]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"SpeedActivBoost,{server_info[43]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }

                                            //Повышение ХП 
                                            if (server_info[44] != "" || server_info[44] != null || Convert.ToInt32(server_info[44]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"HpActivBoost,{server_info[44]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение защиты
                                            if (server_info[45] != "" || server_info[45] != null || Convert.ToInt32(server_info[45]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"DefensActivBoost,{server_info[45]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            SetHill = true;
                                            Debug.Log(SetHill);
                                        }
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill1Play = "";
                                    }
                                    else if (EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill2Play != "")
                                    {
                                        Debug.Log("Скил 1");
                                        string[] server_info = EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill2Play.Split(',');
                                        if (server_info[27] == "Attack")
                                        {
                                            damage = damage * (100 + Convert.ToInt32(server_info[3])) / 100;
                                            bool Dead = false;
                                            //Цель Противник с ниже % ХП
                                            if (server_info[25] == "2" || Convert.ToInt32(server_info[25]) == 2)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            //Цель Противник с высшей атакой
                                            else if (server_info[25] == "3" || Convert.ToInt32(server_info[25]) == 3)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Противник с высшим БС
                                            else if (server_info[25] == "4" || Convert.ToInt32(server_info[25]) == 4)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.bs).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Персонаж на против
                                            else if (server_info[25] == "7" || Convert.ToInt32(server_info[25]) == 7)
                                            {
                                                personAllAttack.Clear();
                                                if (UserPersonSpavn[a.idSlot].transform.GetChild(0) != null)
                                                {
                                                    EnemyClildSlot = a.idSlot;
                                                }
                                                else
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Случайный персонаж
                                            else if (server_info[25] == "8" || Convert.ToInt32(server_info[25]) == 8)
                                            {
                                                personAllAttack.Clear();
                                                EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];

                                            }
                                            //Цель Случайные персонажи в количеств N 
                                            else if (server_info[25] == "9" || Convert.ToInt32(server_info[25]) == 9)
                                            {
                                                personAllAttack.Clear();
                                                List<int> deleteId = new List<int>();
                                                foreach (int g in UserPersonidListSlot)
                                                {
                                                    deleteId.Add(g);
                                                }

                                                for (int i = 0; i < Convert.ToInt32(server_info[40]); i++)
                                                {

                                                    int Enemy = deleteId[UnityEngine.Random.Range(0, deleteId.Count)];
                                                    Debug.Log(Enemy);
                                                    if (!personAllAttack.Contains(Enemy))
                                                    {
                                                        personAllAttack.Add(Enemy);
                                                        deleteId.Remove(Enemy);
                                                    }
                                                    else
                                                    {

                                                    }
                                                }

                                            }
                                            //Цель горизонтальный ряд - верхний строй
                                            else if (server_info[25] == "10" || Convert.ToInt32(server_info[25]) == 10)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель горизонтальный ряд - средний строй
                                            else if (server_info[25] == "11" || Convert.ToInt32(server_info[25]) == 11)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Противники по горизонтали 
                                            else if (server_info[25] == "12" || Convert.ToInt32(server_info[25]) == 12)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Всех персонажей 
                                            else if (server_info[25] == "13" || Convert.ToInt32(server_info[25]) == 13)
                                            {
                                                personAllAttack.Clear();
                                                foreach (int g in UserPersonidListSlot)
                                                {
                                                    personAllAttack.Add(g);
                                                }
                                            }
                                            //Цель Передний ряд
                                            else if (server_info[25] == "14" || Convert.ToInt32(server_info[25]) == 14)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Средний ряд
                                            else if (server_info[25] == "15" || Convert.ToInt32(server_info[25]) == 15)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Задний ряд 
                                            else if (server_info[25] == "16" || Convert.ToInt32(server_info[25]) == 16)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Два передних ряда 
                                            else if (server_info[25] == "17" || Convert.ToInt32(server_info[25]) == 17)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (UserPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Два задних ряда
                                            else if (server_info[25] == "18" || Convert.ToInt32(server_info[25]) == 18)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (UserPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (UserPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (UserPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            for (int i = 0; i < Convert.ToInt32(server_info[4]); i++)
                                            {
                                                try
                                                {
                                                    if (personAllAttack.Count > 0)
                                                    {
                                                        foreach (var AttackEnemy in personAllAttack)
                                                        {
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                            bool c = UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                            if (c)
                                                            {
                                                                //Dead = true;
                                                                Debug.Log("Смерть персонажа");
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                        bool c = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                        if (c)
                                                        {
                                                            Dead = true;
                                                            Debug.Log("Смерть персонажа");
                                                        }
                                                    }

                                                }
                                                catch
                                                {

                                                }


                                            }
                                            int RandomBuffDebuf = 99;
                                            if (personAllAttack.Count > 0)
                                            {
                                                foreach (var AttackEnemy in personAllAttack)
                                                {

                                                    //Кровотечение
                                                    Debug.Log(server_info[19]);
                                                    if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Яд
                                                    if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Стан
                                                    if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }

                                                    //Молчание
                                                    if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Рабство
                                                    if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                }
                                            }
                                            else if (Dead == false)
                                            {
                                                //Кровотечение
                                                Debug.Log(server_info[19]);
                                                if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Яд
                                                if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Стан
                                                if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }

                                                //Молчание
                                                if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Рабство
                                                if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                            }



                                        }
                                        else if (server_info[27] == "Hill")
                                        {
                                           
                                            if (server_info[25] == "5" || Convert.ToInt32(server_info[25]) == 5)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            else if (server_info[25] == "1" || Convert.ToInt32(server_info[25]) == 1)
                                            {
                                                EnemyClildSlot = a.idSlot;
                                            }
                                            else if (server_info[25] == "6" || Convert.ToInt32(server_info[25]) == 6)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            if (server_info[3] != null && Convert.ToInt32(server_info[3]) != 0)
                                            {

                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[3])) / 100;
                                                if (EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }
                                                if ((hill + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                                Debug.Log("Зеленый");

                                            }
                                            else if (server_info[15] != null && Convert.ToInt32(server_info[15]) != 0)
                                            {
                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[15])) / 100;
                                                if (EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }

                                                if ((hill + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                            }
                                            //повышение атаки
                                            int RandomBuffDebuf = 10;
                                            if (server_info[41] != "" || server_info[41] != null || Convert.ToInt32(server_info[41]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"AttackActivBoost,{server_info[41]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //повышение урона
                                            if (server_info[42] != "" || server_info[42] != null || Convert.ToInt32(server_info[42]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"YronActivBoost,{server_info[42]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение скорости
                                            if (server_info[43] != "" || server_info[43] != null || Convert.ToInt32(server_info[43]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"SpeedActivBoost,{server_info[43]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }

                                            //Повышение ХП 
                                            if (server_info[44] != "" || server_info[44] != null || Convert.ToInt32(server_info[44]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"HpActivBoost,{server_info[44]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение защиты
                                            if (server_info[45] != "" || server_info[45] != null || Convert.ToInt32(server_info[45]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"DefensActivBoost,{server_info[45]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            SetHill = true;
                                            Debug.Log(SetHill);
                                        }
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill2Play = "";
                                    }
                                    if (EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill3Play != "")
                                    {
                                        Debug.Log("Скил 1");
                                        string[] server_info = EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill3Play.Split(',');
                                        if (server_info[27] == "Attack")
                                        {
                                            damage = damage * (100 + Convert.ToInt32(server_info[3])) / 100;
                                            bool Dead = false;
                                            //Цель Противник с ниже % ХП
                                            if (server_info[25] == "2" || Convert.ToInt32(server_info[25]) == 2)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            //Цель Противник с высшей атакой
                                            else if (server_info[25] == "3" || Convert.ToInt32(server_info[25]) == 3)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Противник с высшим БС
                                            else if (server_info[25] == "4" || Convert.ToInt32(server_info[25]) == 4)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "UserPerson")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.bs).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            //Цель Персонаж на против
                                            else if (server_info[25] == "7" || Convert.ToInt32(server_info[25]) == 7)
                                            {
                                                personAllAttack.Clear();
                                                if (UserPersonSpavn[a.idSlot].transform.GetChild(0) != null)
                                                {
                                                    EnemyClildSlot = a.idSlot;
                                                }
                                                else
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Случайный персонаж
                                            else if (server_info[25] == "8" || Convert.ToInt32(server_info[25]) == 8)
                                            {
                                                personAllAttack.Clear();
                                                EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];

                                            }
                                            //Цель Случайные персонажи в количеств N 
                                            else if (server_info[25] == "9" || Convert.ToInt32(server_info[25]) == 9)
                                            {
                                                personAllAttack.Clear();
                                                List<int> deleteId = new List<int>();
                                                foreach (int g in UserPersonidListSlot)
                                                {
                                                    deleteId.Add(g);
                                                }

                                                for (int i = 0; i < Convert.ToInt32(server_info[40]); i++)
                                                {

                                                    int Enemy = deleteId[UnityEngine.Random.Range(0, deleteId.Count)];
                                                    Debug.Log(Enemy);
                                                    if (!personAllAttack.Contains(Enemy))
                                                    {
                                                        personAllAttack.Add(Enemy);
                                                        deleteId.Remove(Enemy);
                                                    }
                                                    else
                                                    {

                                                    }
                                                }

                                            }
                                            //Цель горизонтальный ряд - верхний строй
                                            else if (server_info[25] == "10" || Convert.ToInt32(server_info[25]) == 10)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель горизонтальный ряд - средний строй
                                            else if (server_info[25] == "11" || Convert.ToInt32(server_info[25]) == 11)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Противники по горизонтали 
                                            else if (server_info[25] == "12" || Convert.ToInt32(server_info[25]) == 12)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Всех персонажей 
                                            else if (server_info[25] == "13" || Convert.ToInt32(server_info[25]) == 13)
                                            {
                                                personAllAttack.Clear();
                                                foreach (int g in UserPersonidListSlot)
                                                {
                                                    personAllAttack.Add(g);
                                                }
                                            }
                                            //Цель Передний ряд
                                            else if (server_info[25] == "14" || Convert.ToInt32(server_info[25]) == 14)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Средний ряд
                                            else if (server_info[25] == "15" || Convert.ToInt32(server_info[25]) == 15)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Задний ряд 
                                            else if (server_info[25] == "16" || Convert.ToInt32(server_info[25]) == 16)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                if (UserPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (one == false && two == false && three == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            //Цель Два передних ряда 
                                            else if (server_info[25] == "17" || Convert.ToInt32(server_info[25]) == 17)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (UserPersonidListSlot.Contains(0))
                                                {
                                                    personAllAttack.Add(0);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(1))
                                                {
                                                    personAllAttack.Add(1);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(2))
                                                {
                                                    personAllAttack.Add(2);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }

                                            }
                                            //Цель Два задних ряда
                                            else if (server_info[25] == "18" || Convert.ToInt32(server_info[25]) == 18)
                                            {
                                                personAllAttack.Clear();
                                                bool one = true;
                                                bool two = true;
                                                bool three = true;
                                                bool four = true;
                                                bool five = true;
                                                bool six = true;
                                                if (UserPersonidListSlot.Contains(3))
                                                {
                                                    personAllAttack.Add(3);
                                                }
                                                else
                                                {
                                                    one = false;
                                                }
                                                if (UserPersonidListSlot.Contains(4))
                                                {
                                                    personAllAttack.Add(4);
                                                }
                                                else
                                                {
                                                    two = false;
                                                }
                                                if (UserPersonidListSlot.Contains(5))
                                                {
                                                    personAllAttack.Add(5);
                                                }
                                                else
                                                {
                                                    three = false;
                                                }
                                                if (UserPersonidListSlot.Contains(6))
                                                {
                                                    personAllAttack.Add(6);
                                                }
                                                else
                                                {
                                                    four = false;
                                                }
                                                if (UserPersonidListSlot.Contains(7))
                                                {
                                                    personAllAttack.Add(7);
                                                }
                                                else
                                                {
                                                    five = false;
                                                }
                                                if (UserPersonidListSlot.Contains(8))
                                                {
                                                    personAllAttack.Add(8);
                                                }
                                                else
                                                {
                                                    six = false;
                                                }
                                                if (one == false && two == false && three == false && four == false && five == false && six == false)
                                                {
                                                    EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                                }
                                            }
                                            for (int i = 0; i < Convert.ToInt32(server_info[4]); i++)
                                            {
                                                try
                                                {
                                                    if (personAllAttack.Count > 0)
                                                    {
                                                        foreach (var AttackEnemy in personAllAttack)
                                                        {
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                            UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                            
                                                            bool c = UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                            if (c)
                                                            {
                                                                //Dead = true;
                                                                Debug.Log("Смерть персонажа");
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                                        bool c = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                                        if (c)
                                                        {
                                                            Dead = true;
                                                            Debug.Log("Смерть персонажа");
                                                        }
                                                    }

                                                }
                                                catch (System.Exception ex)
                                                {

                                                }
                                                


                                            }
                                            int RandomBuffDebuf = 99;
                                            if (personAllAttack.Count > 0)
                                            {
                                                foreach (var AttackEnemy in personAllAttack)
                                                {

                                                    //Кровотечение
                                                    Debug.Log(server_info[19]);
                                                    if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Яд
                                                    if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Стан
                                                    if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }
                                                    }

                                                    //Молчание
                                                    if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                    //Рабство
                                                    if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                    {
                                                        try
                                                        {
                                                            if (UserPersonSpavn[AttackEnemy].transform.GetChild(0) != null)
                                                            {
                                                                int rand = UnityEngine.Random.Range(0, 100);
                                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                                {
                                                                    string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                                    UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                                }
                                                            }
                                                        }
                                                        catch
                                                        {

                                                        }


                                                    }
                                                }
                                            }
                                            else if (Dead == false)
                                            {
                                                //Кровотечение
                                                Debug.Log(server_info[19]);
                                                if (server_info[19] != "" || server_info[19] != null || Convert.ToInt32(server_info[19]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Bleeding,{server_info[19]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Яд
                                                if (server_info[20] != "" || server_info[20] != null || Convert.ToInt32(server_info[20]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Poison,{server_info[20]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Стан
                                                if (server_info[18] != "" || server_info[18] != null || Convert.ToInt32(server_info[18]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Stan,{server_info[18]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }

                                                //Молчание
                                                if (server_info[21] != "" || server_info[21] != null || Convert.ToInt32(server_info[21]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Silence,{server_info[21]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                                //Рабство
                                                if (server_info[22] != "" || server_info[22] != null || Convert.ToInt32(server_info[22]) != 0)
                                                {
                                                    int rand = UnityEngine.Random.Range(0, 100);
                                                    if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                    {
                                                        string debuf = $"Slavery,{server_info[22]},{server_info[23]}";
                                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Debuf.Add(debuf);

                                                    }

                                                }
                                            }



                                        }
                                        else if (server_info[27] == "Hill")
                                        {
                                            if (server_info[25] == "5" || Convert.ToInt32(server_info[25]) == 5)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.hp).ToList();
                                                EnemyClildSlot = GoalConvert[GoalConvert.Count - 1].idSlot;
                                                Debug.Log(EnemyClildSlot);
                                            }
                                            else if (server_info[25] == "1" || Convert.ToInt32(server_info[25]) == 1)
                                            {
                                                EnemyClildSlot = a.idSlot;
                                            }
                                            else if (server_info[25] == "6" || Convert.ToInt32(server_info[25]) == 6)
                                            {
                                                personAllAttack.Clear();
                                                List<PersonSearchSpeed> GoalConvert = new List<PersonSearchSpeed>();
                                                foreach (var x in AllPersonSpeed)
                                                {
                                                    if (x.typePerson == "Enemy")
                                                    {
                                                        GoalConvert.Add(x);
                                                    }
                                                }
                                                GoalConvert = GoalConvert.OrderByDescending(x => x.attack).ToList();
                                                EnemyClildSlot = GoalConvert[0].idSlot;
                                            }
                                            if (server_info[3] != null && Convert.ToInt32(server_info[3]) != 0)
                                            {

                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[3])) / 100;
                                                if (EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }
                                                if ((hill + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                                Debug.Log("Зеленый");

                                            }
                                            else if (server_info[15] != null && Convert.ToInt32(server_info[15]) != 0)
                                            {
                                                float hill = (attackUser * attackUser / (attackUser + DefensEnemy));
                                                hill = hill * (100 + Convert.ToInt32(server_info[15])) / 100;
                                                if (EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment != 0)
                                                {
                                                    hill = hill * (100 + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Treatment) / 100;
                                                }

                                                if ((hill + EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info) > EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax)
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().HpMax;
                                                }
                                                else
                                                {
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info += hill;
                                                }
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.green;
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                                EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(hill).ToString();
                                            }
                                            //повышение атаки
                                            int RandomBuffDebuf = 10;
                                            if (server_info[41] != "" || server_info[41] != null || Convert.ToInt32(server_info[41]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (RandomBuffDebuf >= rand && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"AttackActivBoost,{server_info[41]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //повышение урона
                                            if (server_info[42] != "" || server_info[42] != null || Convert.ToInt32(server_info[42]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"YronActivBoost,{server_info[42]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение скорости
                                            if (server_info[43] != "" || server_info[43] != null || Convert.ToInt32(server_info[43]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"SpeedActivBoost,{server_info[43]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }

                                            //Повышение ХП 
                                            if (server_info[44] != "" || server_info[44] != null || Convert.ToInt32(server_info[44]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"HpActivBoost,{server_info[44]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            //Повышение защиты
                                            if (server_info[45] != "" || server_info[45] != null || Convert.ToInt32(server_info[45]) != 0)
                                            {
                                                int rand = UnityEngine.Random.Range(0, 100);
                                                if (rand >= RandomBuffDebuf && rand <= RandomBuffDebuf)
                                                {
                                                    string debuf = $"DefensActivBoost,{server_info[45]},{server_info[46]}";
                                                    EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Buffs.Add(debuf);

                                                }

                                            }
                                            SetHill = true;
                                            Debug.Log(SetHill);
                                        }
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().skill3Play = "";
                                    }
                                    else
                                    {
                                        EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                        bool kritDamage = false;
                                        int randYklon = UnityEngine.Random.Range(0, 100);
                                        //Уклонение
                                        if (randYklon > 0 && randYklon < vrag.Evasion)
                                        {
                                            //точность
                                            int randTocnost = UnityEngine.Random.Range(0, 100);
                                            if (randTocnost > 0 && randTocnost < EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Accuracy)
                                            {
                                                //Шанс крита и крит урон
                                                int randKrit = UnityEngine.Random.Range(0, 100);
                                                if (randKrit > 0 && randKrit < EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                                {
                                                    int randNoKrit = UnityEngine.Random.Range(0, 100);
                                                    if (randNoKrit > 0 && randNoKrit < UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                                    {
                                                        Debug.Log("Не Крит");
                                                        //Доп урон
                                                        damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                        //Уменьшение урона
                                                        damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                    }
                                                    else
                                                    {
                                                        Debug.Log("Крит");
                                                        //Доп урон
                                                        damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                        //Уменьшение урона
                                                        damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                        damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                        kritDamage = true;
                                                    }

                                                }
                                                else
                                                {
                                                    Debug.Log("Не Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                }



                                            }
                                            else
                                            {
                                                damage = 0;
                                            }
                                        }
                                        else
                                        {
                                            //Шанс крита и крит урон
                                            int randKrit = UnityEngine.Random.Range(0, 100);
                                            if (randKrit > 0 && randKrit < EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                            {
                                                int randNoKrit = UnityEngine.Random.Range(0, 100);
                                                if (randNoKrit > 0 && randNoKrit < UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                                {
                                                    Debug.Log("Не Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                }
                                                else
                                                {
                                                    Debug.Log("Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                    kritDamage = true;
                                                }

                                            }
                                            else
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }
                                        }
                                        Debug.Log("Сука ебаная " + UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).name);
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                        bool c = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                        if (c)
                                        {
                                            Debug.Log("Смерть персонажа");
                                        }
                                        check = true;
                                        if (kritDamage == false)
                                        {
                                            Debug.Log("Желтый");
                                            UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                            UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                            UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                            kritDamageAll = false;
                                            idSlotAll = EnemyClildSlot;
                                        }
                                        else
                                        {
                                            UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.red;
                                            UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                            UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                            Debug.Log("Красный");
                                            kritDamageAll = true;
                                            idSlotAll = EnemyClildSlot;
                                        }
                                    }
                                    if (personAllAttack.Count > 0)
                                    {
                                        Vector3 target = new Vector3(UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x + 0.4f, UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(UserPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                    }
                                    else
                                    {
                                        if (SetHill == false)
                                        {
                                            Vector3 target = new Vector3(UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x + 0.4f, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                            EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                            check = true;
                                        }
                                        else if (SetHill == true && a.idSlot == EnemyClildSlot)
                                        {
                                            check = true;
                                        }
                                        else
                                        {
                                            Vector3 target = new Vector3(EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x - 0.4f, EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                            EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                            check = true;
                                            Debug.Log("Хуита4");
                                        }

                                    }




                                }
                                catch (Exception ex)
                                {
                                    Debug.LogException(ex);
                                    check = false;
                                }
                                yield return new WaitForSeconds(0.5f);
                                if (check)
                                {

                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = true;
                                    yield return new WaitForSeconds(1.25f);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = false;
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, EnemyPersonSpavn[a.idSlot].transform.position, _speed);
                                    try
                                    {
                                        if (personAllAttack.Count > 0)
                                        {
                                            foreach (var AttackEnemy in personAllAttack)
                                            {
                                                UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                            }
                                        }
                                        else
                                        {
                                            UserPersonSpavn[idSlotAll].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                        }


                                    }
                                    catch
                                    {

                                    }

                                    check = false;
                                }
                            }
                            else
                            {
                                bool kritDamageAll = false;
                                int idSlotAll = 0;
                                try
                                {
                                    float damage = 0;
                                    float attackUser = EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Attack_info;
                                    int EnemyClildSlot = UserPersonidListSlot[UnityEngine.Random.Range(0, UserPersonidListSlot.Count - 1)];
                                    PersonBattleScript vrag = EnemyPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>();
                                    float DefensEnemy = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Defens_info;
                                    damage = (attackUser * attackUser / (attackUser + DefensEnemy));
                                    bool kritDamage = false;
                                    int randYklon = UnityEngine.Random.Range(0, 100);
                                    //Уклонение
                                    if (randYklon > 0 && randYklon < vrag.Evasion)
                                    {
                                        //точность
                                        int randTocnost = UnityEngine.Random.Range(0, 100);
                                        if (randTocnost > 0 && randTocnost < EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Accuracy)
                                        {
                                            //Шанс крита и крит урон
                                            int randKrit = UnityEngine.Random.Range(0, 100);
                                            if (randKrit > 0 && randKrit < EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                            {
                                                int randNoKrit = UnityEngine.Random.Range(0, 100);
                                                if (randNoKrit > 0 && randNoKrit < UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                                {
                                                    Debug.Log("Не Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                }
                                                else
                                                {
                                                    Debug.Log("Крит");
                                                    //Доп урон
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                    //Уменьшение урона
                                                    damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                    damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                    kritDamage = true;
                                                }

                                            }
                                            else
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }



                                        }
                                        else
                                        {
                                            damage = 0;
                                        }
                                    }
                                    else
                                    {
                                        //Шанс крита и крит урон
                                        int randKrit = UnityEngine.Random.Range(0, 100);
                                        if (randKrit > 0 && randKrit < EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritChance)
                                        {
                                            int randNoKrit = UnityEngine.Random.Range(0, 100);
                                            if (randNoKrit > 0 && randNoKrit < UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().AntiCrit)
                                            {
                                                Debug.Log("Не Крит");
                                                //Доп урон
                                                damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                            }
                                            else
                                            {
                                                Debug.Log("Крит");
                                                //Доп урон
                                                damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                                //Уменьшение урона
                                                damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                                damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CritDamage) / 100;
                                                kritDamage = true;
                                            }

                                        }
                                        else
                                        {
                                            Debug.Log("Не Крит");
                                            //Доп урон
                                            damage = damage * (100 + EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageBonus) / 100;
                                            //Уменьшение урона
                                            damage = damage * (100 - UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageReduction) / 100;
                                        }
                                    }

                                    UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().Hp_info -= damage;
                                    bool c = UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().CheckHp();
                                    if (c)
                                    {
                                        Debug.Log("Смерть персонажа");
                                    }
                                    check = true;
                                    if (kritDamage == false)
                                    {
                                        Debug.Log("Желтый");
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(255, 127, 0, 255);
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                        kritDamageAll = false;
                                        idSlotAll = EnemyClildSlot;
                                    }
                                    else
                                    {
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.red;
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                        UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(damage).ToString();
                                        Debug.Log("Красный");
                                        kritDamageAll = true;
                                        idSlotAll = EnemyClildSlot;
                                    }
                                    if (personAllAttack.Count > 0)
                                    {


                                        Vector3 target = new Vector3(UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x + 0.4f, UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, UserPersonSpavn[personAllAttack[0]].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                        Debug.Log("Хуита1");




                                    }
                                    else
                                    {

                                        Vector3 target = new Vector3(UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.x + 0.4f, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.y, UserPersonSpavn[EnemyClildSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().transform.position.z);
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, target, _speed);
                                        check = true;
                                        Debug.Log("Хуита3");




                                    }




                                }
                                catch (Exception ex)
                                {
                                    Debug.LogException(ex);
                                    check = false;
                                }
                                yield return new WaitForSeconds(0.5f);
                                if (check)
                                {

                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = true;
                                    yield return new WaitForSeconds(1.25f);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().IsAttack = false;
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position = Vector3.MoveTowards(EnemyPersonSpavn[a.idSlot].transform.GetChild(0).transform.position, EnemyPersonSpavn[a.idSlot].transform.position, _speed);
                                    try
                                    {
                                        if (personAllAttack.Count > 0)
                                        {
                                            foreach (var AttackEnemy in personAllAttack)
                                            {
                                                UserPersonSpavn[AttackEnemy].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                            }
                                        }
                                        else
                                        {
                                            UserPersonSpavn[idSlotAll].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                        }


                                    }
                                    catch
                                    {

                                    }
                                    yield return new WaitForSeconds(0.5f);
                                    check = false;
                                }
                            }

                        }
                    }








                }
                AllPersonSpeed.Remove(a);

            }
            RoundStart = false;
            
        }
        else if (ListSpeedPersonUser.Count > 0 && ListSpeedPersonEnemy.Count == 0)
        {
            ClientSend.WinBossKvest(Level);
            ClientSend.SearchLevelBatlePve();
            WinBoos.SetActive(true);
            UserPersonidListSlot.Clear();
            ListSpeedPersonUser.Clear();
            AllPersonSpeed.Clear();
            EnemyPersonidListSlot.Clear();
            ListSpeedPersonEnemy.Clear();

            foreach (var item in EnemyPersonSpavn)
            {
                try
                {
                    if (item.transform.GetChild(0) != null)
                    {
                        Destroy(item.transform.GetChild(0).gameObject);

                    }

                }
                catch
                {

                }
            }
            foreach (var item in UserPersonSpavn)
            {
                try
                {
                    if (item.transform.GetChild(0) != null)
                    {
                        Destroy(item.transform.GetChild(0).gameObject);

                    }

                }
                catch
                {

                }
            }
            RoundStart = false;
            BattleStart = false;
            Raund = 0;
            MaxRaund = 1;
            CheckGoPersonUser = false;
            CheckGoPersonEnemy = false;

        }
        else if (ListSpeedPersonUser.Count == 0 && ListSpeedPersonEnemy.Count > 0)
        {
            GameControll.instance.AudioSourceG.clip = GameControll.instance.DefaultClip;
            GameControll.instance.AudioSourceG.Play();
            lozzeBoos.SetActive(true);
            UserPersonidListSlot.Clear();
            ListSpeedPersonUser.Clear();
            AllPersonSpeed.Clear();
            EnemyPersonidListSlot.Clear();
            ListSpeedPersonEnemy.Clear();
            
            foreach (var item in EnemyPersonSpavn)
            {
                try
                {
                    if (item.transform.GetChild(0) != null)
                    {
                        Destroy(item.transform.GetChild(0).gameObject);

                    }

                }
                catch
                {

                }
            }
            foreach (var item in UserPersonSpavn)
            {
                try
                {
                    if (item.transform.GetChild(0) != null)
                    {
                        Destroy(item.transform.GetChild(0).gameObject);

                    }

                }
                catch
                {

                }
            }
            RoundStart = false;
            BattleStart = false;
            Raund = 0;
            MaxRaund = 1;
            CheckGoPersonUser = false;
            CheckGoPersonEnemy = false;
            
        }
        

    }
    public void CloseLozze()
    {
        Boss.SetActive(true);
        Vboi.SetActive(false);
        Vboi.GetComponent<Button>().interactable = true;
        lozzeBoos.SetActive(false);

    }
    public void CloseWin()
    {
        while (WinNagrandaFather.transform.childCount > 0)
        {
            DestroyImmediate(WinNagrandaFather.transform.GetChild(0).gameObject);
        }
        Boss.SetActive(true);
        Vboi.SetActive(false);
        Vboi.GetComponent<Button>().interactable = true;
        WinBoos.SetActive(false);

    }
    private async void Update()
    {
        if (!BattleStart)
        {
            levelText.gameObject.transform.parent.gameObject.SetActive(false);
            raundText.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            levelText.gameObject.transform.parent.gameObject.SetActive(true);
            raundText.gameObject.transform.parent.gameObject.SetActive(true);
            if (CheckGoPersonUser == true && CheckGoPersonEnemy == true)
            {
                if (ListSpeedPersonEnemy.Count == 0 && ListSpeedPersonUser.Count == 0)
                {

                }
                else
                {
                    
                    
                    if (RoundStart == false)
                    {
                        if (Raund < MaxRaund)
                        {
                            if (ListSpeedPersonEnemy.Count == 0)
                            {
                                ClientSend.WinBossKvest(Level);
                                ClientSend.SearchLevelBatlePve();
                                WinBoos.SetActive(true);
                                UserPersonidListSlot.Clear();
                                ListSpeedPersonUser.Clear();
                                AllPersonSpeed.Clear();
                                EnemyPersonidListSlot.Clear();
                                ListSpeedPersonEnemy.Clear();

                                foreach (var item in EnemyPersonSpavn)
                                {
                                    try
                                    {
                                        if (item.transform.GetChild(0) != null)
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);

                                        }

                                    }
                                    catch
                                    {

                                    }
                                }
                                foreach (var item in UserPersonSpavn)
                                {
                                    try
                                    {
                                        if (item.transform.GetChild(0) != null)
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);

                                        }

                                    }
                                    catch
                                    {

                                    }
                                }
                                RoundStart = false;
                                BattleStart = false;
                                Raund = 0;
                                MaxRaund = 1;
                                CheckGoPersonUser = false;
                                CheckGoPersonEnemy = false;
                            }
                            else if (ListSpeedPersonUser.Count == 0)
                            {
                                GameControll.instance.AudioSourceG.clip = GameControll.instance.DefaultClip;
                                GameControll.instance.AudioSourceG.Play();
                                lozzeBoos.SetActive(true);
                                UserPersonidListSlot.Clear();
                                ListSpeedPersonUser.Clear();
                                AllPersonSpeed.Clear();
                                EnemyPersonidListSlot.Clear();
                                ListSpeedPersonEnemy.Clear();
                                foreach (var item in EnemyPersonSpavn)
                                {
                                    try
                                    {
                                        if (item.transform.GetChild(0) != null)
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);

                                        }

                                    }
                                    catch
                                    {

                                    }
                                    
                                }
                                foreach (var item in UserPersonSpavn)
                                {
                                    try
                                    {
                                        if (item.transform.GetChild(0) != null)
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);

                                        }

                                    }
                                    catch
                                    {

                                    }
                                }
                                RoundStart = false;
                                BattleStart = false;
                                Raund = 0;
                                MaxRaund = 1;
                                CheckGoPersonUser = false;
                                CheckGoPersonEnemy = false;
                                
                            }
                            else
                            {
                                
                                Raund += 1;
                                ListSpeedPersonUser = ListSpeedPersonUser.OrderByDescending(x => x.speed).ToList();
                                ListSpeedPersonEnemy = ListSpeedPersonEnemy.OrderByDescending(x => x.speed).ToList();
                                
                                foreach (var a in ListSpeedPersonEnemy.ToList())
                                {
                                    AllPersonSpeed.Add(new PersonSearchSpeed(a.idSlot, a.speed,a.typePerson, a.attack, a.hp, a.bs));

                                }
                                foreach (var a in ListSpeedPersonUser.ToList())
                                {
                                    AllPersonSpeed.Add(new PersonSearchSpeed(a.idSlot, a.speed, a.typePerson,a.attack,a.hp,a.bs));

                                }
                                AllPersonSpeed = AllPersonSpeed.OrderByDescending(x => x.speed).ToList();
                                foreach (var a in AllPersonSpeed)
                                {
                                    if (a.typePerson == "UserPerson" && UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Play == "" && UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Play == "" && UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Play == "")
                                    {
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Play = UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Resiver;
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Play = UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Resiver;
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Play = UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Resiver;
                                    }
                                    if (a.typePerson == "Enemy" && EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Play == "" && EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Play == "" && EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Play == "")
                                    {
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Play = EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill1Resiver;
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Play = EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill2Resiver;
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Play = EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().skill3Resiver;
                                    }
                                }
                                foreach (var a in AllPersonSpeed)
                                {
                                    if (a.typePerson == "UserPerson")
                                    {
                                        UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().UpdateBuf();
                                    }
                                    else if (a.typePerson == "Enemy")
                                    {
                                        EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().UpdateBuf();
                                    }
                                }
                                StartCoroutine(DebufBoiCorut());
                                
                                StartCoroutine(UdarBattleIenumerator());
                                RoundStart = true;
                            }
                            
                        }
                        else
                        {
                            if (ListSpeedPersonUser.Count == 0)
                            {
                                GameControll.instance.AudioSourceG.clip = GameControll.instance.DefaultClip;
                                GameControll.instance.AudioSourceG.Play();
                                lozzeBoos.SetActive(true);
                                UserPersonidListSlot.Clear();
                                ListSpeedPersonUser.Clear();
                                AllPersonSpeed.Clear();
                                EnemyPersonidListSlot.Clear();
                                ListSpeedPersonEnemy.Clear();
                                foreach (var item in EnemyPersonSpavn)
                                {
                                    if (item.transform.GetChild(0) != null)
                                    {
                                        try
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                                foreach (var item in UserPersonSpavn)
                                {
                                    if (item.transform.GetChild(0) != null)
                                    {
                                        try
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                                RoundStart = false;
                                BattleStart = false;
                                Raund = 0;
                                MaxRaund = 1;
                                CheckGoPersonUser = false;
                                CheckGoPersonEnemy = false;
                                
                            }
                            else if (ListSpeedPersonEnemy.Count == 0)
                            {
                                ClientSend.WinBossKvest(Level);
                                ClientSend.SearchLevelBatlePve();
                                WinBoos.SetActive(true);
                                UserPersonidListSlot.Clear();
                                ListSpeedPersonUser.Clear();
                                AllPersonSpeed.Clear();
                                EnemyPersonidListSlot.Clear();
                                ListSpeedPersonEnemy.Clear();

                                foreach (var item in EnemyPersonSpavn)
                                {
                                    try
                                    {
                                        if (item.transform.GetChild(0) != null)
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);

                                        }

                                    }
                                    catch
                                    {

                                    }
                                }
                                foreach (var item in UserPersonSpavn)
                                {
                                    try
                                    {
                                        if (item.transform.GetChild(0) != null)
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);

                                        }

                                    }
                                    catch
                                    {

                                    }
                                }
                                RoundStart = false;
                                BattleStart = false;
                                Raund = 0;
                                MaxRaund = 1;
                                CheckGoPersonUser = false;
                                CheckGoPersonEnemy = false;

                            }
                            else
                            {

                                lozzeBoos.SetActive(true);
                                GameControll.instance.AudioSourceG.clip = GameControll.instance.DefaultClip;
                                GameControll.instance.AudioSourceG.Play();
                                UserPersonidListSlot.Clear();
                                ListSpeedPersonUser.Clear();
                                AllPersonSpeed.Clear();
                                EnemyPersonidListSlot.Clear();
                                ListSpeedPersonEnemy.Clear();
                                foreach (var item in EnemyPersonSpavn)
                                {
                                    try
                                    {
                                        if (item.transform.GetChild(0) != null)
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);

                                        }

                                    }
                                    catch
                                    {

                                    }
                                }
                                foreach (var item in UserPersonSpavn)
                                {
                                    try
                                    {
                                        if (item.transform.GetChild(0) != null)
                                        {
                                            Destroy(item.transform.GetChild(0).gameObject);

                                        }

                                    }
                                    catch
                                    {

                                    }
                                }
                                RoundStart = false;
                                BattleStart = false;
                                Raund = 0;
                                MaxRaund = 1;
                                CheckGoPersonUser = false;
                                CheckGoPersonEnemy = false;
                                
                            }
                        }
                       
                    }
                    else
                    {
                        
                        
                    }

                }
            }
            else
            {
                foreach (int a in UserPersonidListSlot)
                {
                    if (UserPersonSpavn[a].transform.childCount > 0)
                    {
                        if (UserPersonSpavn[a].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().ReadiPerson == true)
                        {
                            CheckGoPersonUser = true;
                        }
                        else
                        {
                            CheckGoPersonUser = false;
                            break;
                        }
                    }
                }
                foreach (int a in EnemyPersonidListSlot)
                {
                    if (EnemyPersonSpavn[a].transform.childCount > 0)
                    {
                        if (EnemyPersonSpavn[a].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().ReadiPerson == true)
                        {
                            CheckGoPersonEnemy = true;
                        }
                        else
                        {
                            CheckGoPersonEnemy = false;
                            break;
                        }
                    }
                }
            }
            
        }
        levelText.text = $"Уровень {Level}";
        raundText.text = $"{Raund}/{MaxRaund} раунд";
    }

    public IEnumerator DebufBoiCorut()
    {
        if (Raund > 1)
        {
            foreach (var a in AllPersonSpeed.ToList())
            {
                if (a.typePerson == "UserPerson")
                {
                    if (UserPersonidListSlot.Contains(a.idSlot))
                    {
                        foreach (var b in UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.ToList())
                        {
                            string[] server_info = b.Split(',');
                            //Кровотичение
                            if (server_info[0] == "Bleeding")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    Debug.Log("Кровь");
                                    float hp = UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_info;
                                    float demage = ((hp * Convert.ToInt32(server_info[1])) / 100);
                                    Debug.Log(demage);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_info -= demage;
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.red;
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(demage).ToString();
                                    yield return new WaitForSeconds(0.5f);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");

                                }
                                else
                                {
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                }



                            }
                            //Яд
                            else if (server_info[0] == "Poison")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    float hp = UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_info;
                                    float demage = ((hp * Convert.ToInt32(server_info[1])) / 100);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_info -= demage;
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(13, 159, 18, 255);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(demage).ToString();
                                    yield return new WaitForSeconds(0.5f);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");
                                }
                                else
                                {
                                    UserPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                }

                            }
                        }
                    }
                    

                }
                else if (a.typePerson == "Enemy")
                {
                    if (EnemyPersonidListSlot.Contains(a.idSlot))
                    {
                        foreach (var b in EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.ToList())
                        {
                            string[] server_info = b.Split(',');
                            //Кровотичение
                            if (server_info[0] == "Bleeding")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    float demage = ((EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_info * Convert.ToInt32(server_info[1])) / 100);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_info -= demage;
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = Color.red;
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(demage).ToString();
                                    yield return new WaitForSeconds(0.5f);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");
                                }
                                else
                                {
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);

                                }
                            }
                            //Яд
                            else if (server_info[0] == "Poison")
                            {
                                if (Convert.ToInt32(server_info[2]) != 0)
                                {
                                    float demage = ((EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_info * Convert.ToInt32(server_info[1])) / 100);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Hp_info -= demage;
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.color = new Color(13, 159, 18, 255);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(true);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.text = Convert.ToInt32(demage).ToString();
                                    yield return new WaitForSeconds(0.5f);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).GetComponent<PersonBattleScript>().DamageText.gameObject.SetActive(false);
                                    string str = b;
                                    string[] debug = str.Split(',');
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Add($"{debug[0]},{debug[1]},{Convert.ToInt32(debug[2]) - 1}");
                                }
                                else
                                {
                                    EnemyPersonSpavn[a.idSlot].transform.GetChild(0).gameObject.GetComponent<PersonBattleScript>().Debuf.Remove(b);

                                }

                            }
                        }
                    }
                    
                }
            }
        }
    }
    private void Start()
    {
        ClientSend.SearchLevelBatlePve();

    }
    public void LoadEnemyPerson()
    {
        foreach (var a in GameControll.instance.BattlePveInfoLevel)
        {

            string[] server_info = a.Split(',');
            if (GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().Level == Convert.ToInt32(server_info[1]))
            {
                GameControll.instance.kvestPanel.GetComponent<cvestControlScript>().levelPerson = Convert.ToInt32(server_info[2]);
                if (server_info[3] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[3]);
                }
                if (server_info[4] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[4]);

                }
                if (server_info[5] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[5]);

                }
                if (server_info[6] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[6]);

                }
                if (server_info[7] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[7]);

                }
                if (server_info[8] != null)
                {
                    ClientSend.SearchPersonEnemy(server_info[8]);

                }
            }



        }
    }
    public void BossBtn()
    {
        GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.SetActive(false);
        while (GameControll.instance.stroiFatherList.transform.childCount > 0)
        {
            DestroyImmediate(GameControll.instance.stroiFatherList.transform.GetChild(0).gameObject);
        }
        GameControll.instance.persons.GetComponent<ControlPersonScreapt>().DestroyItemStroi();
        ClientSend.PersonSearchUser();
        ClientSend.InventorySearchUser();
        GameControll.instance.stroi.SetActive(true);
        ClientSend.SearchStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().list);
    }

}
