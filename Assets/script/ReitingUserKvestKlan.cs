using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReitingUserKvestKlan : MonoBehaviour
{
    public string Damage;
    public string mesto;
    public string username;
    public RawImage AvatarImage;

    public Text DamageText;
    public Text mestoText;
    public Text usernameText;

    private void Update()
    {
        DamageText.text = $"Урон: {Damage}";
        mestoText.text = $"Место: {mesto}";
        usernameText.text = $"{username}";
    }
}
