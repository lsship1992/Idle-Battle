using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlotScript : MonoBehaviour
{
    public string NameItem = "";
    public string Nameru = "";
    public string description = "";
    public string RangItem;
    public int attack;
    public int defens;
    public int speed;
    public int hp;
    public int _attack_Proc;
    public int _hp_proc;
    public int CritDamage;
    public int DamageBonus;
    public int id;
    public int defens_proc;
    public int speed_proc;
    public int Count;
    [SerializeField] private Image ImageSlot;
    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(() => OnClick());
    }
    private void OnClick()
    {
        if (GameControll.instance.personPanel.activeSelf == true)
        {
            if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == "Helmet")
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().NameItem != "")
                {
                    ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().id, -1);
                }
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().NameItem = NameItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().RangItem = RangItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().attack = attack;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().defens = defens;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().speed = speed;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().hp = hp;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().id = id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().Nameru = Nameru;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().description = description;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[0].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                GameControll.instance.Inventory.SetActive(false);



            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == "Armor")
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().NameItem != "")
                {
                    ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().id, -1);


                }
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().NameItem = NameItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().RangItem = RangItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().attack = attack;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().defens = defens;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().speed = speed;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().hp = hp;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().id = id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().Nameru = Nameru;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().description = description;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[1].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                GameControll.instance.Inventory.SetActive(false);

            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == "Gloves")
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().NameItem != "")
                {
                    ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().id, -1);


                }
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().NameItem = NameItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().RangItem = RangItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().attack = attack;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().defens = defens;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().speed = speed;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().hp = hp;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().id = id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().Nameru = Nameru;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().description = description;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[2].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                GameControll.instance.Inventory.SetActive(false);

            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == "Bots")
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().NameItem != "")
                {
                    ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().id, -1);


                }
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().NameItem = NameItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().RangItem = RangItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().attack = attack;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().defens = defens;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().speed = speed;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().hp = hp;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().id = id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().Nameru = Nameru;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().description = description;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[3].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                GameControll.instance.Inventory.SetActive(false);

            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == "Weapon")
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().NameItem != "")
                {
                    ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().id, -1);


                }
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().NameItem = NameItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().RangItem = RangItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().attack = attack;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().defens = defens;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().speed = speed;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().hp = hp;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().id = id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().Nameru = Nameru;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().description = description;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[4].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                GameControll.instance.Inventory.SetActive(false);
            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == "Rings")
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().NameItem != "")
                {
                    ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().id, -1);


                }
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().NameItem = NameItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().RangItem = RangItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().attack = attack;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().defens = defens;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().speed = speed;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().hp = hp;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().id = id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().Nameru = Nameru;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().description = description;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[5].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                GameControll.instance.Inventory.SetActive(false);
            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == "Earrings")
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().NameItem != "")
                {
                    ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().id, -1);


                }
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().NameItem = NameItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().RangItem = RangItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().attack = attack;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().defens = defens;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().speed = speed;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().hp = hp;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().id = id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().Nameru = Nameru;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().description = description;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[6].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                GameControll.instance.Inventory.SetActive(false);
            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == "Necklace")
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().NameItem != "")
                {
                    ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().id, -1);


                }
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().NameItem = NameItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().RangItem = RangItem;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().attack = attack;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().defens = defens;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().speed = speed;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().hp = hp;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().id = id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().Nameru = Nameru;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().description = description;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[7].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                GameControll.instance.Inventory.SetActive(false);
                
            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().nameItem == "Book")
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().idSlot == 1)
                {
                    if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().NameItem != "")
                    {
                        ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().id, -1);


                    }
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().NameItem = NameItem;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().RangItem = RangItem;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().attack = attack;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().defens = defens;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().speed = speed;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().hp = hp;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().id = id;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().Nameru = Nameru;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().description = description;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[8].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                    ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                    GameControll.instance.Inventory.SetActive(false);
                }
                else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().idSlot == 2)
                {
                    if (GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().NameItem != "")
                    {
                        ClientSend.ItemPersonUserUpdate(GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().id, -1);


                    }
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().NameItem = NameItem;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().RangItem = RangItem;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().attack = attack;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().defens = defens;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().speed = speed;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().hp = hp;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>()._attack_Proc = _attack_Proc;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>()._hp_proc = _hp_proc;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().CritDamage = CritDamage;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().DamageBonus = DamageBonus;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().id = id;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().idPerson = GameControll.instance.personPanel.GetComponent<PersControlScript>().id;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().Nameru = Nameru;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().description = description;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().defens_proc = defens_proc;
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().Item[9].GetComponent<SelectItemScript>().speed_proc = speed_proc;
                    ClientSend.ItemPersonUserUpdate(id, GameControll.instance.personPanel.GetComponent<PersControlScript>().id);
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();
                    GameControll.instance.Inventory.SetActive(false);
                }

            }
        }
        else
        {
            GameControll.instance.ItemInfoPanel.GetComponent<ItemInfoPanel>().NameItem = NameItem;
            GameControll.instance.ItemInfoPanel.GetComponent<ItemInfoPanel>().RangItem = RangItem;
            GameControll.instance.ItemInfoPanel.GetComponent<ItemInfoPanel>().Nameru = Nameru;
            GameControll.instance.ItemInfoPanel.GetComponent<ItemInfoPanel>().description = description;
            GameControll.instance.ItemInfoPanel.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
            if (NameItem == "Book")
            {
                if (Nameru == "The Book of Blessings of the Earth")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[72];
                }
                else if (Nameru == "The Book of Dark Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[77];
                }
                else if (Nameru == "Universal Book")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[71];
                }
                else if (Nameru == "The Book of Green Nature")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[74];
                }
                else if (Nameru == "The Book of Holiness")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[76];
                }
                else if (Nameru == "The book of power")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[69];
                }
                else if (Nameru == "The book of life")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[67];
                }
                else if (Nameru == "Book of protection")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[68];
                }
                else if (Nameru == "Speed book")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[70];
                }
                else if (Nameru == "The Book of Water Spirits")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[73];
                }
                else if (Nameru == "The Book of Dead Spirits")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[75];
                }


            }
            if (NameItem == "Helmet")
            {
                if (Nameru == "Beginner helmet")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[20];
                }
                else if (Nameru == "Dark Crystal helmet")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[21];
                }
                else if (Nameru == "Dinasty helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[24];
                }
                else if (Nameru == "Draconik helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[23];
                }
                else if (Nameru == "Majestik helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[25];
                }
                else if (Nameru == "Tallum helmett")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[22];
                }
                else if (Nameru == "Ice Helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[28];
                }
                else if (Nameru == "Imperial Helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[27];
                }
                else if (Nameru == "Golden Helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[115];
                }
                else if (Nameru == "Demonic Helmet")
                {

                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[26];
                }


            }
            if (NameItem == "Bots")
            {
                if (Nameru == "Beginner boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[0];

                }
                else if (Nameru == "Majestik boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[4];
                }
                else if (Nameru == "Tallum boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[5];

                }
                else if (Nameru == "Demonic Boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[6];

                }
                else if (Nameru == "Golden Shoes")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[7];

                }
                else if (Nameru == "Ice boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[9];

                }
                else if (Nameru == "Imperial Boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[8];

                }
                else if (Nameru == "Dark Crystal boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[1];

                }
                else if (Nameru == "Dinasty boots S")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[3];

                }
                else if (Nameru == "Draconik boots")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[2];

                }
            }
            if (NameItem == "Weapon")
            {
                if (Nameru == "Demonic Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[49];

                }
                else if (Nameru == "Demonic Two-handed Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[47];
                }
                else if (Nameru == "The Golden Wrecker")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[54];

                }
                else if (Nameru == "Golden Knife")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[56];

                }
                else if (Nameru == "Golden Peak")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[52];

                }
                else if (Nameru == "Golden Two-handed Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[53];

                }
                else if (Nameru == "The Imperial Sword of Justice")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[61];

                }
                else if (Nameru == "Golden Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[55];

                }
                else if (Nameru == "Imperial Two-handed Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[59];

                }
                else if (Nameru == "Imperial Snake Fangs")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[57];

                }
                else if (Nameru == "The Imperial Spellcaster")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[60];

                }
                else if (Nameru == "The Imperial Axe")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[58];

                }
                else if (Nameru == "Ice Knife")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[64];

                }
                else if (Nameru == "Ice Sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[63];

                }
                else if (Nameru == "Ice Caster")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[62];

                }
                else if (Nameru == "Ice Piercer")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[566];

                }
                else if (Nameru == "Ice Staff")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[65];

                }
                else if (Nameru == "The Demonic Wand")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[48];

                }
                else if (Nameru == "Demonic Staff")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[51];

                }
                else if (Nameru == "Demonic Knife")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[50];

                }
                else if (Nameru == "Killer dagger")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[46];

                }
                else if (Nameru == "Bazalt hammer")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[44];

                }
                else if (Nameru == "Bloody orich dagger")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[42];

                }
                else if (Nameru == "Cristal dagger")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[43];

                }
                else if (Nameru == "Dark legion sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[41];

                }
                else if (Nameru == "Beginner wooden sword")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[39];

                }
                else if (Nameru == "Dragon slayer")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[40];

                }
                else if (Nameru == "duals of greatness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[45];

                }


            }
            if (NameItem == "Armor")
            {
                if (Nameru == "Beginner armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[29];

                }
                else if (Nameru == "Imperial Armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[37];
                }
                else if (Nameru == "Dark Crystal armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[34];

                }
                else if (Nameru == "Dinasty armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[30];

                }
                else if (Nameru == "Draconik armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[33];

                }
                else if (Nameru == "Majestik armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[32];

                }
                else if (Nameru == "Tallum armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[31];

                }
                else if (Nameru == "Demonic Armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[35];

                }
                else if (Nameru == "Golden Armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[36];

                }
                else if (Nameru == "Ice Armor")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[38];

                }

            }
            if (NameItem == "Gloves")
            {
                if (Nameru == "Tallum gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[11];

                }
                else if (Nameru == "Beginner gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[10];
                }
                else if (Nameru == "Demonic Gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[16];

                }
                else if (Nameru == "Dark Crystal gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[12];

                }
                else if (Nameru == "Dinasty gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[13];

                }
                else if (Nameru == "Draconik gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[15];

                }
                else if (Nameru == "Majestik gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[14];

                }
                else if (Nameru == "Golden Gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[17];

                }
                else if (Nameru == "Imperial Gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[18];

                }
                else if (Nameru == "Ice Gloves")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[19];

                }
            }
            if (NameItem == "Rings")
            {
                if (Nameru == "Power Core Rings")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[84];

                }
                else if (Nameru == "The Ant Ring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[85];
                }
                else if (Nameru == "Ruby Power Ring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[83];

                }
                else if (Nameru == "Beginner ring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[82];

                }
                else if (Nameru == "Demans Ring of Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[93];

                }
                else if (Nameru == "Imperial Control Rings")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[86];

                }
                else if (Nameru == "The Imperial Ring of Crete")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[87];

                }
                else if (Nameru == "The Imperial Ring of Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[88];

                }
                else if (Nameru == "Charm Power Ring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[90];

                }
                else if (Nameru == "The Ring of Wisdom Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[89];

                }
                else if (Nameru == "The Ring of power of Aspiration")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[91];

                }
                else if (Nameru == "The ring of Deman luck")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[92];

                }

            }
            if (NameItem == "Earrings")
            {
                if (Nameru == "Magnificent earring of Greatness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[109];

                }
                else if (Nameru == "The earring of the heart of the ice dragon of rage")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[114];
                }
                else if (Nameru == "Beginner earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[105];

                }
                else if (Nameru == "Lich earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[106];

                }
                else if (Nameru == "Dinasty earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[107];

                }
                else if (Nameru == "Core Earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[108];

                }
                else if (Nameru == "The earring of the heart of the ice dragon of darkness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[113];

                }
                else if (Nameru == "Ice Dragon Heart Earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[112];

                }
                else if (Nameru == "Magnificent earring of good luck")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[111];

                }
                else if (Nameru == "Gorgeous Charm Earring")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[110];

                }

            }
            if (NameItem == "Necklace")
            {
                if (Nameru == "Beginner necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[95];

                }
                else if (Nameru == "Lich necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[97];
                }
                else if (Nameru == "Dinasty necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[98];

                }
                else if (Nameru == "Demonic Necklace of Greatness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[99];

                }
                else if (Nameru == "Dragon Necklace of Wisdom")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[102];

                }
                else if (Nameru == "core necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[96];

                }
                else if (Nameru == "Demonic Necklace of Power")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[100];

                }
                else if (Nameru == "Demonic Necklace of Darkness")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[101];

                }
                else if (Nameru == "Dragon Charm Necklace")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[103];

                }
                else if (Nameru == "Dragon Necklace of Aspiration")
                {
                    ImageSlot.sprite = GameControll.instance.SpriteItemSnar[104];

                }
            }
        
    }
}
