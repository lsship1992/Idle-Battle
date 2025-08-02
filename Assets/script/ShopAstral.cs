using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopAstral : MonoBehaviour
{
    public Sprite ButtonOn;
    public Sprite ButtonOff;

    public GameObject astral;
    public GameObject zoloto;
    public GameObject almaz;

    public Image ButtonAstral;
    public Image ButtonGold;
    public Image ButtonAlmaz;

    public int MaxAstral = 0;
    public Text AstralCount;

    [Header("Îáúåêòû")]
    [SerializeField] public GameObject FatherShop;
    [SerializeField] public GameObject PrefabShop;
    [SerializeField] public GameObject AcceptPay;


    public void ClosePayAccept()
    {
        AcceptPay.SetActive(false);
    }
    private void Update()
    {
        AstralCount.text = MaxAstral.ToString();
    }

    public void VoidAstral()
    {
        ButtonAstral.sprite = ButtonOn;
        ButtonGold.sprite = ButtonOff;
        ButtonAlmaz.sprite = ButtonOff;
        astral.SetActive(true);
        zoloto.SetActive(false);
        almaz.SetActive(false);
    }

    public void VoidGold()
    {
        ButtonAstral.sprite = ButtonOff;
        ButtonGold.sprite = ButtonOn;
        ButtonAlmaz.sprite = ButtonOff;
        astral.SetActive(false);
        zoloto.SetActive(true);
        almaz.SetActive(false);
    }

    public void VoidAlmaz()
    {
        ButtonAstral.sprite = ButtonOff;
        ButtonGold.sprite = ButtonOff;
        ButtonAlmaz.sprite = ButtonOn;
        astral.SetActive(false);
        zoloto.SetActive(false);
        almaz.SetActive(true);
    }
    public void close()
    {
        this.gameObject.SetActive(false);
    }

}
