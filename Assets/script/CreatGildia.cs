using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreatGildia : MonoBehaviour
{
    public InputField name;
    public InputField description;
    public int Level = 0;
    public int sila = 0;
    public GameObject NoName;
    public GameObject NoManey;
    public Text sileText;
    public Text LevelText;
    public GameObject ClanYsheCreate;

    private void Update()
    {
        sileText.text = sila.ToString();
        LevelText.text = $"{Level} ур.";
    }

    public void levelNazad()
    {
        if (Level == 0)
        {
            Level = 10;
        }
        else
        {
            Level--;
        }
    }

    public void levelVpered()
    {
        if (Level == 10)
        {
            Level = 0;
        }
        else
        {
            Level++;
        }
    }

    public void SilaVpered()
    {
        if (sila == 5000)
        {
            sila = 0;
        }
        else
        {
            sila = sila + 200;
        }
    }

    public void silaNazad()
    {
        if (sila == 0)
        {
            sila = 5000;
        }
        else
        {
            sila = sila - 200;
        }
    }

    public void Create()
    {
        if (name.text != "")
        {
            if (PlayerPrefs.GetFloat("gold") >= 500)
            {
                ClientSend.CreateClen(name.text,description.text, Level,sila);
            }
            else
            {
                NoManey.SetActive(true);
                Invoke("CloseOff", 1);
            }
        }
        else
        {
            NoName.SetActive(true);
            Invoke("CloseOff", 1);
        }
    }

    public void CloseOff()
    {
        NoName.SetActive(false);
        NoManey.SetActive(false);
        ClanYsheCreate.SetActive(false);
    }
    
    public void NoNameClanYshe()
    {
        ClanYsheCreate.SetActive(true);
        Invoke("CloseOff", 1);
    }

}
