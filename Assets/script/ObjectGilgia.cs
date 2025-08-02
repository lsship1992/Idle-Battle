using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectGilgia : MonoBehaviour
{
    public string NameKlan;
    public string GlavaKlan;
    public int LevelGildiaPerson;
    public int LevelGildia = 1;
    public int SilaGildia;
    public int MaxPeople = 50;
    public int AllPeople;

    public Text NameKlanText;
    public Text GlavaKlanText;
    public Text LevelGildiaText;
    public Text SilaGildiaText;
    public Text PeopleText;
    public GameObject ButtonVhod;

    private void Awake()
    {
        if (LevelGildia == 1)
        {
            MaxPeople = 50;
        }
        else if (LevelGildia == 2)
        {
            MaxPeople = 55;
        }
        else if (LevelGildia == 3)
        {
            MaxPeople = 60;
        }
        else if (LevelGildia == 4)
        {
            MaxPeople = 65;
        }
        else if (LevelGildia == 5)
        {
            MaxPeople = 70;
        }
        else if (LevelGildia == 6)
        {
            MaxPeople = 75;
        }
        ButtonVhod.GetComponent<Button>().onClick.AddListener(() => Vstupit());
    }
    public void Vstupit()
    {
        ClientSend.VstupitInKlanUser(NameKlan);
    }
    private void Update()
    {
        NameKlanText.text = $"{NameKlan} (ур. {LevelGildia})";
        GlavaKlanText.text = $"Глава: {GlavaKlan}";
        LevelGildiaText.text = $"Ур. {LevelGildiaPerson}";
        SilaGildiaText.text = $"Силы: {SilaGildia}";
        PeopleText.text = $"Кол-во: {AllPeople}/{MaxPeople}";
        if (AllPeople >= MaxPeople)
        {
            ButtonVhod.GetComponent<Button>().interactable = false;
        }
        else
        {
            ButtonVhod.GetComponent<Button>().interactable = true;

        }
    }



}
