using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PersonPrefabScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image Image;
    public string name;
    public int id;
    public string rank;
    public int levelEvo;
    public int level;
    public string Class;
    public int Attack;
    public int Hp;
    public int Defens;
    public int Speed;
    //����
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
    public GameObject Check;
    public Image isEvol;
    private RectTransform rectTransform;
    private Image image;
    public void OnBeginDrag(PointerEventData eventData)
    {

        if (gameObject.transform.parent.name != "Content")
        {
            image.raycastTarget = false;
        }

    }
    public void OnDrag(PointerEventData eventData)
    {
        if (gameObject.transform.parent.name != "Content")
        {
            rectTransform.anchoredPosition += eventData.delta;

        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject.transform.parent.name != "Content" )
        {
            image.raycastTarget = true;
        }


    }
    private void Awake()
    {
       // this.GetComponent<Button>().onClick.AddListener(() => OnClick());
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
    private void Update()
    {
        if (GameControll.instance.stroi.activeSelf == true && gameObject.transform.parent.name != "Content")
        {
            Image.raycastTarget = false;
        }
        else
        {
            Image.raycastTarget = true;

        }
        if (levelEvo == 0)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[0];
        }
        else if (levelEvo == 1)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[1];
        }
        else if (levelEvo == 2)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[2];
        }
        else if (levelEvo == 3)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[3];
        }
        else if (levelEvo == 4)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[4];
        }
        else if (levelEvo == 5)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[5];
        }
        else if (levelEvo == 6)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[6];
        }
        else if (levelEvo == 7)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[7];
        }
        else if (levelEvo == 8)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[8];
        }
        else if (levelEvo == 9)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[9];
        }
        else if (levelEvo == 10)
        {
            isEvol.sprite = GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().spriteUpdateEvo[10];
        }
        if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().gameObject.activeSelf == true)
        {
            if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().ViborPerson == 1)
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Id.Contains(id))
                {
                    Check.SetActive(true);
                }
                else
                {
                    Check.SetActive(false);
                }
            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().ViborPerson == 2)
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Id.Contains(id))
                {
                    Check.SetActive(true);
                }
                else
                {
                    Check.SetActive(false);
                }
            }

        }
        if (levelEvo == 0)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[10];
        }
        else if (levelEvo == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[0];
        }
        else if (levelEvo == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[1];
        }
        else if (levelEvo == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[2];
        }
        else if (levelEvo == 4)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[3];
        }
        else if (levelEvo == 5)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[4];
        }
        else if (levelEvo == 6)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[5];
        }
        else if (levelEvo == 7)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[6];
        }
        else if (levelEvo == 8)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[7];
        }
        else if (levelEvo == 9)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[8];
        }
        else if (levelEvo == 10)
        {
            this.gameObject.GetComponent<Image>().sprite = GameControll.instance.EvoSprite[9];
        }
    }
    public void OnClick()
    {
        if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.activeSelf == true)
        {
            if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().ViborPerson == 1)
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Id.Contains(id))
                {
                    Check.SetActive(false);
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Id.Remove(id);
                }
                else
                {
                    if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Id.Count < GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Col)
                    {
                        Check.SetActive(true);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Id.Add(id);
                    }
                    
                }
            }
            else if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().ViborPerson == 2)
            {
                if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Id.Contains(id))
                {
                    Check.SetActive(false);
                    GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Id.Remove(id);
                }
                else
                {
                    if (GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Id.Count < GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Col)
                    {
                        Check.SetActive(true);
                        GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Id.Add(id);
                    }

                }
            }

        }
        else if (GameControll.instance.Persons.activeSelf == true)
        {
            ClientSend.InventoryMaterialSearchUser();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person1Id.Clear();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().evalution.GetComponent<evalutionPanelScript>().Person2Id.Clear();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().name = name;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().id = id;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().rank = rank;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().level = level;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().levelEvo = levelEvo;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Class = Class;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Attack = Attack;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Hp = Hp;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Defens = Defens;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Speed = Speed;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().DamageReduction = DamageReduction;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().CritDamage = CritDamage;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().CritChance = CritChance;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Evasion = Evasion;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Accuracy = Accuracy;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().DamageBonus = DamageBonus;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().AntiCrit = AntiCrit;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Control = Control;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().AntiControl = AntiControl;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Treatment = Treatment;
            GameControll.instance.personPanel.GetComponent<PersControlScript>().Recovery = Recovery;
            GameControll.instance.personPanel.SetActive(true);
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateItemNecklace();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateItemEarrings();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateItemRings();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateItemGloves();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateItemArmor();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateItemWeapon();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateItembots();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateItemHelmet();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateItemBook1();
            GameControll.instance.personPanel.GetComponent<PersControlScript>().UpdateLevelDef();

            GameControll.instance.persons.SetActive(false);
        }
        else if (GameControll.instance.stroi.activeSelf == true)
        {
            if (GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Count < 6)
            {
                if (gameObject.transform.parent.name == "Content")
                {
                    if (!GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Contains(name))
                    {
                        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
                        GameObject a = gameObject.transform.Find("Image").gameObject;
                        GameObject evo = gameObject.transform.Find("evo").gameObject;
                        a.GetComponent<RectTransform>().sizeDelta = new Vector2(115, 115);
                        evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.71f, 34.71f);
                        
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name == "")
                        {
                            gameObject.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].gameObject.transform, false);
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name = name;
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().idPerson = id;
                            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(name);
                            gameObject.transform.position = new Vector3(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].transform.position.x, GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].transform.position.y, GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].transform.position.z);
                            if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, id, name, "pve", "+");
                            }
                            else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, id, name, "pvp", "+");
                            }
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name == "")
                        {
                            gameObject.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].gameObject.transform, false);
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name = name;
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().idPerson = id;
                            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(name);
                            gameObject.transform.position = new Vector3(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].transform.position.x, GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].transform.position.y, GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].transform.position.z);
                            if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, id, name, "pve", "+");
                            }
                            else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, id, name, "pvp", "+");
                            }
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name == "")
                        {
                            gameObject.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].gameObject.transform, false);
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name = name;
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().idPerson = id;
                            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(name);

                            gameObject.transform.position = new Vector3(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].transform.position.x, GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].transform.position.y, GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].transform.position.z);
                            if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, id, name, "pve", "+");
                            }
                            else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, id, name, "pvp", "+");
                            }
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name == "")
                        {
                            gameObject.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].gameObject.transform, false);
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name = name;
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().idPerson = id;
                            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(name);

                            transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].transform.position;
                            if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, id, name, "pve", "+");
                            }
                            else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, id, name, "pvp", "+");
                            }
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name == "")
                        {
                            gameObject.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].gameObject.transform, false);
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name = name;
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().idPerson = id;
                            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(name);

                            transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].transform.position;
                            if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, id, name, "pve", "+");
                            }
                            else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, id, name, "pvp", "+");
                            }
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name == "")
                        {
                            gameObject.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].gameObject.transform, false);
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name = name;
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().idPerson = id;
                            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(name);

                            transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].transform.position;
                            if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, id, name, "pve", "+");
                            }
                            else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, id, name, "pvp", "+");
                            }
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name == "")
                        {
                            gameObject.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].gameObject.transform, false);
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name = name;
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().idPerson = id;
                            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(name);

                            transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].transform.position;
                            if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, id, name, "pve", "+");
                            }
                            else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, id, name, "pvp", "+");
                            }
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name == "")
                        {
                            gameObject.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].gameObject.transform, false);
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name = name;
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().idPerson = id;
                            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(name);

                            transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].transform.position;
                            if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, id, name, "pve", "+");
                            }
                            else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, id, name, "pvp", "+");
                            }
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name == "")
                        {
                            gameObject.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].gameObject.transform, false);
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name = name;
                            GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().idPerson = id;
                            GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Add(name);

                            transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].transform.position;
                            if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, id, name, "pve", "+");
                            }
                            else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                            {
                                ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, id, name, "pvp", "+");
                            }
                        }
                    }
                    
                }
                else if (gameObject.transform.parent.name == "Image")
                {

                    gameObject.transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
                    transform.SetSiblingIndex(0);
                    GameObject evo = gameObject.transform.Find("evo").gameObject;
                    evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
                    GameObject a = gameObject.transform.Find("Image").gameObject;
                    a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);

                    if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name == name)
                    {
                        Debug.Log("Хуй1");

                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().idPerson = -1;
                        Debug.Log("Хуй");


                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Remove(name);
                }
                else
                {
                }
            }
            else
            {
                if (gameObject.transform.parent.name == "Image")
                {
                    gameObject.transform.SetParent(GameControll.instance.stroiFatherList.transform, false);
                    transform.SetSiblingIndex(0);
                    GameObject evo = gameObject.transform.Find("evo").gameObject;
                    evo.GetComponent<RectTransform>().sizeDelta = new Vector2(169.7127f, 43.2091f);
                    GameObject a = gameObject.transform.Find("Image").gameObject;
                    a.GetComponent<RectTransform>().sizeDelta = new Vector2(143.7047f, 143.7047f);
                    if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name == name)
                    {
                        Debug.Log("Хуй1");

                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().idPerson = -1;
                        Debug.Log("Хуй");

                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name == name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, id, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, id, name, "pvp", "-");
                        }
                    }
                    GameControll.instance.stroi.GetComponent<stroiScript>().nameObj.Remove(name);
                }
                else
                {
                }
            }
        }

    }
}
