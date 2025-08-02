using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AstralShopItem : MonoBehaviour
{
    [Header("Объекты")]
    public int id;
    public int Count;
    public int Price;

    public Text CountText;
    public Text PriceText;
    

    private void Update()
    {
        CountText.text = $"{Count} астралов";
        PriceText.text = $"{Price} ₽";
    }

    public void Buy()
    {
        ClientSend.LinkInvateCreate(Count,Price);
    }
}
