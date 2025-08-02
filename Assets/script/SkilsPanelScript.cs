using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilsPanelScript : MonoBehaviour
{
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

    public GameObject skill1Block;
    public GameObject skill2Block;
    public GameObject skill3Block;
    public GameObject skill4PassivBlock;
    public GameObject skill5PassivBlock;


    public void close()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateSkillBlock()
    {
        if (skill1 != "")
        {
            ClientSend.SearcSkillStrPersonPanel(Convert.ToInt32(skill1),"skill1");
        }
        else
        {
            skill1Block.GetComponent<SkilsPersonBlock>().Name = "Отсутсвует";
            skill1Block.GetComponent<SkilsPersonBlock>().Description = "";
        }
        if (skill2 != "")
        {
            ClientSend.SearcSkillStrPersonPanel(Convert.ToInt32(skill2), "skill2");
        }
        else
        {
            skill2Block.GetComponent<SkilsPersonBlock>().Name = "Отсутсвует";
            skill2Block.GetComponent<SkilsPersonBlock>().Description = "";
        }
        if (skill3 != "")
        {
            ClientSend.SearcSkillStrPersonPanel(Convert.ToInt32(skill3), "skill3");
        }
        else
        {
            skill3Block.GetComponent<SkilsPersonBlock>().Name = "Отсутсвует";
            skill3Block.GetComponent<SkilsPersonBlock>().Description = "";
        }
        if (skill4Pasiv != "")
        {
            ClientSend.SearcSkillStrPersonPanel(Convert.ToInt32(skill4Pasiv), "skill4");
        }
        else
        {
            skill4PassivBlock.GetComponent<SkilsPersonBlock>().Name = "Отсутсвует";
            skill4PassivBlock.GetComponent<SkilsPersonBlock>().Description = "";
        }
        if (skill5Pasiv != "")
        {
            ClientSend.SearcSkillStrPersonPanel(Convert.ToInt32(skill5Pasiv), "skill5");
        }
        else
        {
            skill5PassivBlock.GetComponent<SkilsPersonBlock>().Name = "Отсутсвует";
            skill5PassivBlock.GetComponent<SkilsPersonBlock>().Description = "";
        }
    }

}
