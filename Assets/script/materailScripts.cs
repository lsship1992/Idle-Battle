using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class materailScripts : MonoBehaviour
{
    public Image img;
    public Text CountText;
    public string Name;
    public int id;
    public int Count;

    private void Update()
    {
        CountText.text = Count.ToString();
        if (Name == "UserUpdateMaterial")
        {
            img.sprite = GameControll.instance.material[0];
        }
        else if (Name == "svitok")
        {
            img.sprite = GameControll.instance.material[1];
        }
        else if (Name == "modifikator")
        {
            img.sprite = GameControll.instance.material[2];
        }
        else if (Name == "Zelie rosta")
        {
            img.sprite = GameControll.instance.material[3];
        }
        else if (Name == "Zelia usileniya")
        {
            img.sprite = GameControll.instance.material[4];
        }
        else if (Name == "Svitok zatochki A")
        {
            img.sprite = GameControll.instance.material[5];
        }
        else if (Name == "Svitok zatochki S")
        {
            img.sprite = GameControll.instance.material[6];
        }
        else if (Name == "Svitok zatochki SR")
        {
            img.sprite = GameControll.instance.material[7];
        }
        else if (Name == "Bilet areny")
        {
            img.sprite = GameControll.instance.material[8];
        }
    }
}
