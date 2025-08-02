using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUser : MonoBehaviour
{
    public int level;
    public Text levelText;

    public int exp;

    public Image Fill;

    public bool UpdateBool = false;
    private void Update()
    {
        levelText.text = level.ToString();
        if (level == 1)
        {
            Fill.fillAmount = (float)exp / (float)56;
            if (exp >= 56)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 2)
        {
            Fill.fillAmount = (float)exp / (float)76;
            if (exp >= 76)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 3)
        {
            Fill.fillAmount = (float)exp / (float)87;
            if (exp >= 87)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 4)
        {
            Fill.fillAmount = (float)exp / (float)99;
            if (exp >= 99)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 5)
        {
            Fill.fillAmount = (float)exp / (float)118;
            if (exp >= 118)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 6)
        {
            Fill.fillAmount = (float)exp / (float)136;
            if (exp >= 136)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 7)
        {
            Fill.fillAmount = (float)exp / (float)167;
            if (exp >= 167)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 8)
        {
            Fill.fillAmount = (float)exp / (float)205;
            if (exp >= 205)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 9)
        {
            Fill.fillAmount = (float)exp / (float)207;
            if (exp >= 207)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 10)
        {
            Fill.fillAmount = (float)exp / (float)227;
            if (exp >= 227)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 11)
        {
            Fill.fillAmount = (float)exp / (float)247;
            if (exp >= 247)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 12)
        {
            Fill.fillAmount = (float)exp / (float)267;
            if (exp >= 267)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 13)
        {
            Fill.fillAmount = (float)exp / (float)306;
            if (exp >= 306)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 14)
        {
            Fill.fillAmount = (float)exp / (float)326;
            if (exp >= 326)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 15)
        {
            Fill.fillAmount = (float)exp / (float)346;
            if (exp >= 346)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 16)
        {
            Fill.fillAmount = (float)exp / (float)366;
            if (exp >= 366)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 17)
        {
            Fill.fillAmount = (float)exp / (float)385;
            if (exp >= 385)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 18)
        {
            Fill.fillAmount = (float)exp / (float)405;
            if (exp >= 405)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 19)
        {
            Fill.fillAmount = (float)exp / (float)425;
            if (exp >= 425)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 20)
        {
            Fill.fillAmount = (float)exp / (float)445;
            if (exp >= 445)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 21)
        {
            Fill.fillAmount = (float)exp / (float)465;
            if (exp >= 465)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 22)
        {
            Fill.fillAmount = (float)exp / (float)484;
            if (exp >= 484)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 23)
        {
            Fill.fillAmount = (float)exp / (float)504;
            if (exp >= 504)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 24)
        {
            Fill.fillAmount = (float)exp / (float)524;
            if (exp >= 524)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 25)
        {
            Fill.fillAmount = (float)exp / (float)544;
            if (exp >= 544)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 26)
        {
            Fill.fillAmount = (float)exp / (float)544;
            if (exp >= 544)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 27)
        {
            Fill.fillAmount = (float)exp / (float)564;
            if (exp >= 564)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 28)
        {
            Fill.fillAmount = (float)exp / (float)584;
            if (exp >= 584)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 29)
        {
            Fill.fillAmount = (float)exp / (float)603;
            if (exp >= 603)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 30)
        {
            Fill.fillAmount = (float)exp / (float)623;
            if (exp >= 623)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 31)
        {
            Fill.fillAmount = (float)exp / (float)643;
            if (exp >= 643)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 32)
        {
            Fill.fillAmount = (float)exp / (float)663;
            if (exp >= 663)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 33)
        {
            Fill.fillAmount = (float)exp / (float)683;
            if (exp >= 683)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 34)
        {
            Fill.fillAmount = (float)exp / (float)702;
            if (exp >= 702)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 35)
        {
            Fill.fillAmount = (float)exp / (float)722;
            if (exp >= 722)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 36)
        {
            Fill.fillAmount = (float)exp / (float)742;
            if (exp >= 742)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 37)
        {
            Fill.fillAmount = (float)exp / (float)762;
            if (exp >= 762)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 38)
        {
            Fill.fillAmount = (float)exp / (float)782;
            if (exp >= 782)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 39)
        {
            Fill.fillAmount = (float)exp / (float)834;
            if (exp >= 834)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 40)
        {
            Fill.fillAmount = (float)exp / (float)932;
            if (exp >= 932)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 41)
        {
            Fill.fillAmount = (float)exp / (float)1044;
            if (exp >= 1044)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 42)
        {
            Fill.fillAmount = (float)exp / (float)1918;
            if (exp >= 1918)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 43)
        {
            Fill.fillAmount = (float)exp / (float)2792;
            if (exp >= 2792)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 44)
        {
            Fill.fillAmount = (float)exp / (float)3666;
            if (exp >= 3666)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 45)
        {
            Fill.fillAmount = (float)exp / (float)4539;
            if (exp >= 4539)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 46)
        {
            Fill.fillAmount = (float)exp / (float)5413;
            if (exp >= 5413)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 47)
        {
            Fill.fillAmount = (float)exp / (float)6287;
            if (exp >= 6287)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 48)
        {
            Fill.fillAmount = (float)exp / (float)7161;
            if (exp >= 7161)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 49)
        {
            Fill.fillAmount = (float)exp / (float)8035;
            if (exp >= 8035)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 50)
        {
            Fill.fillAmount = (float)exp / (float)8909;
            if (exp >= 8909)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 51)
        {
            Fill.fillAmount = (float)exp / (float)9783;
            if (exp >= 9783)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 52)
        {
            Fill.fillAmount = (float)exp / (float)10657;
            if (exp >= 10657)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 53)
        {
            Fill.fillAmount = (float)exp / (float)11531;
            if (exp >= 11531)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 54)
        {
            Fill.fillAmount = (float)exp / (float)12405;
            if (exp >= 12405)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 55)
        {
            Fill.fillAmount = (float)exp / (float)13278;
            if (exp >= 13278)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 56)
        {
            Fill.fillAmount = (float)exp / (float)14152;
            if (exp >= 14152)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 57)
        {
            Fill.fillAmount = (float)exp / (float)15026;
            if (exp >= 15900)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 58)
        {
            Fill.fillAmount = (float)exp / (float)15900;
            if (exp >= 16774)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 59)
        {
            Fill.fillAmount = (float)exp / (float)16774;
            if (exp >= 17661)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 60)
        {
            Fill.fillAmount = (float)exp / (float)17661;
            if (exp >= 18509)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 61)
        {
            Fill.fillAmount = (float)exp / (float)18509;
            if (exp >= 19382)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 62)
        {
            Fill.fillAmount = (float)exp / (float)19382;
            if (exp >= 20283)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 63)
        {
            Fill.fillAmount = (float)exp / (float)20283;
            if (exp >= 21144)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 64)
        {
            Fill.fillAmount = (float)exp / (float)21144;
            if (exp >= 22017)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 65)
        {
            Fill.fillAmount = (float)exp / (float)22017;
            if (exp >= 22891)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 66)
        {
            Fill.fillAmount = (float)exp / (float)22891;
            if (exp >= 22891)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 67)
        {
            Fill.fillAmount = (float)exp / (float)23765;
            if (exp >= 23765)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 68)
        {
            Fill.fillAmount = (float)exp / (float)24639;
            if (exp >= 24639)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 69)
        {
            Fill.fillAmount = (float)exp / (float)25513;
            if (exp >= 25513)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 70)
        {
            Fill.fillAmount = (float)exp / (float)26387;
            if (exp >= 26387)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 71)
        {
            Fill.fillAmount = (float)exp / (float)26475;
            if (exp >= 26475)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 72)
        {
            Fill.fillAmount = (float)exp / (float)27907;
            if (exp >= 27907)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 73)
        {
            Fill.fillAmount = (float)exp / (float)29338;
            if (exp >= 29338)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 74)
        {
            Fill.fillAmount = (float)exp / (float)30770;
            if (exp >= 30770)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 75)
        {
            Fill.fillAmount = (float)exp / (float)32201;
            if (exp >= 32201)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 76)
        {
            Fill.fillAmount = (float)exp / (float)33633;
            if (exp >= 33633)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 77)
        {
            Fill.fillAmount = (float)exp / (float)35065;
            if (exp >= 35065)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 78)
        {
            Fill.fillAmount = (float)exp / (float)36496;
            if (exp >= 36496)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 79)
        {
            Fill.fillAmount = (float)exp / (float)37928;
            if (exp >= 37928)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 80)
        {
            Fill.fillAmount = (float)exp / (float)39971;
            if (exp >= 39971)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 81)
        {
            Fill.fillAmount = (float)exp / (float)39975;
            if (exp >= 39975)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 82)
        {
            Fill.fillAmount = (float)exp / (float)42019;
            if (exp >= 42019)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 83)
        {
            Fill.fillAmount = (float)exp / (float)44062;
            if (exp >= 44062)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 84)
        {
            Fill.fillAmount = (float)exp / (float)46105;
            if (exp >= 46105)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 85)
        {
            Fill.fillAmount = (float)exp / (float)48148;
            if (exp >= 48148)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 86)
        {
            Fill.fillAmount = (float)exp / (float)50192;
            if (exp >= 50192)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 87)
        {
            Fill.fillAmount = (float)exp / (float)52235;
            if (exp >= 52235)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 88)
        {
            Fill.fillAmount = (float)exp / (float)54278;
            if (exp >= 54278)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 89)
        {
            Fill.fillAmount = (float)exp / (float)56321;
            if (exp >= 56321)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 90)
        {
            Fill.fillAmount = (float)exp / (float)55867;
            if (exp >= 55867)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 91)
        {
            Fill.fillAmount = (float)exp / (float)61324;
            if (exp >= 61324)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 92)
        {
            Fill.fillAmount = (float)exp / (float)64216;
            if (exp >= 64216)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 93)
        {
            Fill.fillAmount = (float)exp / (float)65535;
            if (exp >= 65535)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 94)
        {
            Fill.fillAmount = (float)exp / (float)66854;
            if (exp >= 66854)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 95)
        {
            Fill.fillAmount = (float)exp / (float)68173;
            if (exp >= 68173)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 96)
        {
            Fill.fillAmount = (float)exp / (float)69492;
            if (exp >= 69492)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 97)
        {
            Fill.fillAmount = (float)exp / (float)70811;
            if (exp >= 70811)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 98)
        {
            Fill.fillAmount = (float)exp / (float)72130;
            if (exp >= 72130)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 99)
        {
            Fill.fillAmount = (float)exp / (float)73449;
            if (exp >= 73449)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 100)
        {
            Fill.fillAmount = (float)exp / (float)75388;
            if (exp >= 75388)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 101)
        {
            Fill.fillAmount = (float)exp / (float)75467;
            if (exp >= 75467)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 102)
        {
            Fill.fillAmount = (float)exp / (float)77096;
            if (exp >= 77096)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 103)
        {
            Fill.fillAmount = (float)exp / (float)78725;
            if (exp >= 78725)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 104)
        {
            Fill.fillAmount = (float)exp / (float)80354;
            if (exp >= 80354)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 105)
        {
            Fill.fillAmount = (float)exp / (float)81983;
            if (exp >= 81983)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 106)
        {
            Fill.fillAmount = (float)exp / (float)83612;
            if (exp >= 83612)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 107)
        {
            Fill.fillAmount = (float)exp / (float)85241;
            if (exp >= 85241)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 108)
        {
            Fill.fillAmount = (float)exp / (float)86870;
            if (exp >= 86870)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 109)
        {
            Fill.fillAmount = (float)exp / (float)88499;
            if (exp >= 88499)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 110)
        {
            Fill.fillAmount = (float)exp / (float)90128;
            if (exp >= 90128)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 111)
        {
            Fill.fillAmount = (float)exp / (float)91757;
            if (exp >= 91757)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 112)
        {
            Fill.fillAmount = (float)exp / (float)93386;
            if (exp >= 93386)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 113)
        {
            Fill.fillAmount = (float)exp / (float)95015;
            if (exp >= 95015)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 114)
        {
            Fill.fillAmount = (float)exp / (float)96644;
            if (exp >= 96644)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 115)
        {
            Fill.fillAmount = (float)exp / (float)98273;
            if (exp >= 98273)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 116)
        {
            Fill.fillAmount = (float)exp / (float)99902;
            if (exp >= 99902)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 117)
        {
            Fill.fillAmount = (float)exp / (float)101531;
            if (exp >= 101531)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 118)
        {
            Fill.fillAmount = (float)exp / (float)103160;
            if (exp >= 103160)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 119)
        {
            Fill.fillAmount = (float)exp / (float)104789;
            if (exp >= 104789)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 120)
        {
            Fill.fillAmount = (float)exp / (float)106418;
            if (exp >= 106418)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 121)
        {
            Fill.fillAmount = (float)exp / (float)108047;
            if (exp >= 108047)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 122)
        {
            Fill.fillAmount = (float)exp / (float)109676;
            if (exp >= 109676)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 123)
        {
            Fill.fillAmount = (float)exp / (float)111304;
            if (exp >= 111304)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 124)
        {
            Fill.fillAmount = (float)exp / (float)112934;
            if (exp >= 112934)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 125)
        {
            Fill.fillAmount = (float)exp / (float)114563;
            if (exp >= 114563)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 126)
        {
            Fill.fillAmount = (float)exp / (float)116192;
            if (exp >= 116192)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 127)
        {
            Fill.fillAmount = (float)exp / (float)117821;
            if (exp >= 117821)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 128)
        {
            Fill.fillAmount = (float)exp / (float)119450;
            if (exp >= 119450)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 129)
        {
            Fill.fillAmount = (float)exp / (float)121079;
            if (exp >= 121079)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 130)
        {
            Fill.fillAmount = (float)exp / (float)122708;
            if (exp >= 122708)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 131)
        {
            Fill.fillAmount = (float)exp / (float)124337;
            if (exp >= 124337)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 132)
        {
            Fill.fillAmount = (float)exp / (float)125966;
            if (exp >= 125966)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 133)
        {
            Fill.fillAmount = (float)exp / (float)134234;
            if (exp >= 134234)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 134)
        {
            Fill.fillAmount = (float)exp / (float)139323;
            if (exp >= 139323)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 135)
        {
            Fill.fillAmount = (float)exp / (float)143233;
            if (exp >= 143233)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 136)
        {
            Fill.fillAmount = (float)exp / (float)147232;
            if (exp >= 147232)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 137)
        {
            Fill.fillAmount = (float)exp / (float)152234;
            if (exp >= 152234)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 138)
        {
            Fill.fillAmount = (float)exp / (float)155233;
            if (exp >= 155233)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 139)
        {
            Fill.fillAmount = (float)exp / (float)161309;
            if (exp >= 161309)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 140)
        {
            Fill.fillAmount = (float)exp / (float)166013;
            if (exp >= 166013)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 141)
        {
            Fill.fillAmount = (float)exp / (float)170717;
            if (exp >= 170717)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 142)
        {
            Fill.fillAmount = (float)exp / (float)175421;
            if (exp >= 175421)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 143)
        {
            Fill.fillAmount = (float)exp / (float)180125;
            if (exp >= 180125)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 144)
        {
            Fill.fillAmount = (float)exp / (float)184829;
            if (exp >= 184829)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 145)
        {
            Fill.fillAmount = (float)exp / (float)189533;
            if (exp >= 189533)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 146)
        {
            Fill.fillAmount = (float)exp / (float)185563;
            if (exp >= 185563)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 147)
        {
            Fill.fillAmount = (float)exp / (float)189057;
            if (exp >= 189057)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 148)
        {
            Fill.fillAmount = (float)exp / (float)192551;
            if (exp >= 192551)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 149)
        {
            Fill.fillAmount = (float)exp / (float)196045;
            if (exp >= 196045)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 150)
        {
            Fill.fillAmount = (float)exp / (float)199540;
            if (exp >= 199540)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 151)
        {
            Fill.fillAmount = (float)exp / (float)203034;
            if (exp >= 203034)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 152)
        {
            Fill.fillAmount = (float)exp / (float)206528;
            if (exp >= 206528)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 153)
        {
            Fill.fillAmount = (float)exp / (float)210022;
            if (exp >= 213516)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 154)
        {
            Fill.fillAmount = (float)exp / (float)213516;
            if (exp >= 213516)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 155)
        {
            Fill.fillAmount = (float)exp / (float)217010;
            if (exp >= 217010)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 156)
        {
            Fill.fillAmount = (float)exp / (float)220504;
            if (exp >= 220504)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 157)
        {
            Fill.fillAmount = (float)exp / (float)223998;
            if (exp >= 223998)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 158)
        {
            Fill.fillAmount = (float)exp / (float)227492;
            if (exp >= 227492)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 159)
        {
            Fill.fillAmount = (float)exp / (float)230986;
            if (exp >= 230986)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 160)
        {
            Fill.fillAmount = (float)exp / (float)234480;
            if (exp >= 234480)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 161)
        {
            Fill.fillAmount = (float)exp / (float)237974;
            if (exp >= 237974)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 162)
        {
            Fill.fillAmount = (float)exp / (float)241468;
            if (exp >= 241468)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 163)
        {
            Fill.fillAmount = (float)exp / (float)244962;
            if (exp >= 244962)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 164)
        {
            Fill.fillAmount = (float)exp / (float)248456;
            if (exp >= 248456)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 165)
        {
            Fill.fillAmount = (float)exp / (float)251950;
            if (exp >= 251950)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 166)
        {
            Fill.fillAmount = (float)exp / (float)255444;
            if (exp >= 255444)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 167)
        {
            Fill.fillAmount = (float)exp / (float)258938;
            if (exp >= 258938)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 168)
        {
            Fill.fillAmount = (float)exp / (float)262433;
            if (exp >= 262433)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 169)
        {
            Fill.fillAmount = (float)exp / (float)265927;
            if (exp >= 265927)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 170)
        {
            Fill.fillAmount = (float)exp / (float)269421;
            if (exp >= 269421)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 171)
        {
            Fill.fillAmount = (float)exp / (float)272915;
            if (exp >= 272915)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 172)
        {
            Fill.fillAmount = (float)exp / (float)276409;
            if (exp >= 276409)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 173)
        {
            Fill.fillAmount = (float)exp / (float)279903;
            if (exp >= 279903)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 174)
        {
            Fill.fillAmount = (float)exp / (float)283397;
            if (exp >= 283397)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 175)
        {
            Fill.fillAmount = (float)exp / (float)286891;
            if (exp >= 286891)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 176)
        {
            Fill.fillAmount = (float)exp / (float)290385;
            if (exp >= 290385)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 177)
        {
            Fill.fillAmount = (float)exp / (float)293879;
            if (exp >= 293879)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 178)
        {
            Fill.fillAmount = (float)exp / (float)297373;
            if (exp >= 297373)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 179)
        {
            Fill.fillAmount = (float)exp / (float)300867;
            if (exp >= 300867)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 180)
        {
            Fill.fillAmount = (float)exp / (float)304361;
            if (exp >= 304361)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 181)
        {
            Fill.fillAmount = (float)exp / (float)307855;
            if (exp >= 307855)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 182)
        {
            Fill.fillAmount = (float)exp / (float)311349;
            if (exp >= 311349)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 183)
        {
            Fill.fillAmount = (float)exp / (float)314843;
            if (exp >= 314843)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 184)
        {
            Fill.fillAmount = (float)exp / (float)318337;
            if (exp >= 318337)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 185)
        {
            Fill.fillAmount = (float)exp / (float)321831;
            if (exp >= 321831)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 186)
        {
            Fill.fillAmount = (float)exp / (float)325325;
            if (exp >= 325325)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 187)
        {
            Fill.fillAmount = (float)exp / (float)328820;
            if (exp >= 328820)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 188)
        {
            Fill.fillAmount = (float)exp / (float)332313;
            if (exp >= 332313)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 189)
        {
            Fill.fillAmount = (float)exp / (float)335808;
            if (exp >= 335808)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 190)
        {
            Fill.fillAmount = (float)exp / (float)339302;
            if (exp >= 339302)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 191)
        {
            Fill.fillAmount = (float)exp / (float)342796;
            if (exp >= 342796)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 192)
        {
            Fill.fillAmount = (float)exp / (float)346290;
            if (exp >= 346290)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 193)
        {
            Fill.fillAmount = (float)exp / (float)349784;
            if (exp >= 349784)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 194)
        {
            Fill.fillAmount = (float)exp / (float)353278;
            if (exp >= 353278)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 195)
        {
            Fill.fillAmount = (float)exp / (float)356772;
            if (exp >= 356772)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 196)
        {
            Fill.fillAmount = (float)exp / (float)360266;
            if (exp >= 360266)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 197)
        {
            Fill.fillAmount = (float)exp / (float)363760;
            if (exp >= 363760)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 198)
        {
            Fill.fillAmount = (float)exp / (float)367254;
            if (exp >= 367254)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 199)
        {
            Fill.fillAmount = (float)exp / (float)370748;
            if (exp >= 370748)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
        else if (level == 200)
        {
            Fill.fillAmount = (float)exp / (float)374242;
            if (exp >= 374242)
            {
                if (!UpdateBool)
                {
                    ClientSend.LevelUpUser();
                    UpdateBool = true;
                }
            }
        }
    }
}
