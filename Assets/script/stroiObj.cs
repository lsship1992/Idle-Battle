using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class stroiObj : MonoBehaviour,IDropHandler
{
    public int id;
    public string name;
    public int idPerson = -1;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<PersonPrefabScript>() && eventData.pointerDrag.gameObject.transform.parent.name != "Content")
            {
                
                if (name == "")
                {
                    if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        Debug.Log("’ÛÈ1");

                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().idPerson = -1;
                        Debug.Log("’ÛÈ");

                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name = "";
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().idPerson = -1;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                    }
                    //GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name = "";
                    //GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().idPerson = -1;
                    eventData.pointerDrag.gameObject.transform.SetParent(transform, false);
                    eventData.pointerDrag.transform.position = transform.position;
                    name = eventData.pointerDrag.GetComponent<PersonPrefabScript>().name;
                    idPerson = eventData.pointerDrag.GetComponent<PersonPrefabScript>().id;

                    if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                    {
                        ClientSend.AddStroiPerson(id, idPerson, name, "pve", "+");
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                    {
                        ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "+");
                    }
                }
                else
                {
                    if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameObject persProsh = gameObject.transform.GetChild(0).gameObject;
                        persProsh.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].transform, false);
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().name = name;
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().idPerson = persProsh.GetComponent<PersonPrefabScript>().id;
                        persProsh.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].transform.position;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "-");
                        }
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, idPerson, name, "pve", "+");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[0].GetComponent<stroiObj>().id, idPerson, name, "pvp", "+");
                        }



                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameObject persProsh = gameObject.transform.GetChild(0).gameObject;
                        persProsh.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].transform, false);
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().name = name;
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().idPerson = persProsh.GetComponent<PersonPrefabScript>().id;
                        persProsh.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].transform.position;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "-");
                        }
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, idPerson, name, "pve", "+");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[1].GetComponent<stroiObj>().id, idPerson, name, "pvp", "+");
                        }


                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameObject persProsh = gameObject.transform.GetChild(0).gameObject;
                        persProsh.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].transform, false);
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().name = name;
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().idPerson = persProsh.GetComponent<PersonPrefabScript>().id;
                        persProsh.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].transform.position;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "-");
                        }
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, idPerson, name, "pve", "+");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[2].GetComponent<stroiObj>().id, idPerson, name, "pvp", "+");
                        }


                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameObject persProsh = gameObject.transform.GetChild(0).gameObject;
                        persProsh.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].transform, false);
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().name = name;
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().idPerson = persProsh.GetComponent<PersonPrefabScript>().id;
                        persProsh.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].transform.position;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "-");
                        }
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, idPerson, name, "pve", "+");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[3].GetComponent<stroiObj>().id, idPerson, name, "pvp", "+");
                        }


                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameObject persProsh = gameObject.transform.GetChild(0).gameObject;
                        persProsh.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].transform, false);
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().name = name;
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().idPerson = persProsh.GetComponent<PersonPrefabScript>().id;
                        persProsh.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].transform.position;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "-");
                        }
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, idPerson, name, "pve", "+");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[4].GetComponent<stroiObj>().id, idPerson, name, "pvp", "+");
                        }


                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameObject persProsh = gameObject.transform.GetChild(0).gameObject;
                        persProsh.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].transform, false);
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().name = name;
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().idPerson = persProsh.GetComponent<PersonPrefabScript>().id;
                        persProsh.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].transform.position;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "-");
                        }
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, idPerson, name, "pve", "+");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[5].GetComponent<stroiObj>().id, idPerson, name, "pvp", "+");
                        }


                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameObject persProsh = gameObject.transform.GetChild(0).gameObject;
                        persProsh.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].transform, false);
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().name = name;
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().idPerson = persProsh.GetComponent<PersonPrefabScript>().id;
                        persProsh.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].transform.position;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "-");
                        }
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, idPerson, name, "pve", "+");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[6].GetComponent<stroiObj>().id, idPerson, name, "pvp", "+");
                        }


                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {

                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameObject persProsh = gameObject.transform.GetChild(0).gameObject;
                        persProsh.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].transform, false);
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().name = name;
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().idPerson = persProsh.GetComponent<PersonPrefabScript>().id;
                        persProsh.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].transform.position;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "-");
                        }
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, idPerson, name, "pve", "+");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[7].GetComponent<stroiObj>().id, idPerson, name, "pvp", "+");
                        }


                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name == eventData.pointerDrag.GetComponent<PersonPrefabScript>().name)
                    {
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().id, eventData.pointerDrag.GetComponent<PersonPrefabScript>().name, "pvp", "-");
                        }
                        GameObject persProsh = gameObject.transform.GetChild(0).gameObject;
                        persProsh.transform.SetParent(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].transform, false);
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().name = name;
                        GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().idPerson = persProsh.GetComponent<PersonPrefabScript>().id;
                        persProsh.transform.position = GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].transform.position;
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pve", "-");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "-");
                        }
                        if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, idPerson, name, "pve", "+");
                        }
                        else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                        {
                            ClientSend.AddStroiPerson(GameControll.instance.stroi.GetComponent<stroiScript>().imgstroi[8].GetComponent<stroiObj>().id, idPerson, name, "pvp", "+");
                        }


                    }


                    eventData.pointerDrag.gameObject.transform.SetParent(transform, false);
                    eventData.pointerDrag.transform.position = transform.position;
                    name = eventData.pointerDrag.GetComponent<PersonPrefabScript>().name;
                    idPerson = eventData.pointerDrag.GetComponent<PersonPrefabScript>().id;

                    if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pve")
                    {
                        ClientSend.AddStroiPerson(id, idPerson, name, "pve", "+");
                    }
                    else if (GameControll.instance.stroi.GetComponent<stroiScript>().list == "pvp")
                    {
                        ClientSend.AddStroiPerson(id, idPerson, name, "pvp", "+");
                    }

                }
                
            }
            
            

        }
        

        
    }
}
