using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObmenAstralGold : MonoBehaviour
{
    public int astral;
    public int gold;

    public Text astralText;
    public Text goldText;

    public Slider astralSlider;

    static string FormatNumber(long number)
    {
        if (number < 1000)
        {
            return number.ToString();
        }

        string[] suffixes = { "", "K", "M", "B", "T" }; // Тысячи, миллионы, миллиарды, триллионы
        int suffixIndex = 0;

        double formattedNumber = number;
        while (formattedNumber >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            formattedNumber /= 1000;
            suffixIndex++;
        }

        // Округляем до одного знака после запятой
        return $"{formattedNumber:0.#}{suffixes[suffixIndex]}";
    }


    private void Update()
    {
        astralSlider.maxValue = GameControll.instance.AstralShop.GetComponent<ShopAstral>().MaxAstral;
        astral = (int)astralSlider.value * 1;
        astralText.text = astral.ToString();
        gold = astral * 100000;

        goldText.text = FormatNumber(gold);
    }

    public void ClickObmen()
    {
        ClientSend.BuyAstral((int)astralSlider.value, "Gold");

    }
}
