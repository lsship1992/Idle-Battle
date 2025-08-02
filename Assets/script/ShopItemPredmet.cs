using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopItemPredmet : MonoBehaviour
{
    public Image AvatarImg;
    public Image CoinImg;
    public Text NameText;
    public Text PriceText;
    public int Price;
    public string Name;
    public string type;
    public int id;
    public int idItem;
    public Text MaxByuText;
    public int MaxByu;
    public int Byu;
    public string Valet;
    public List<Sprite> SpriteCoin = new List<Sprite>();
    public string description;
    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(() => OnClick());
    }
    public void OnClick()
    {
        if (type == "Predmet")
        {
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Nameru = Name;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().id = id;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().idItemShop = idItem;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().type = "Predmet";
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Valet = Valet;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Price = Price;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().MaxByu = MaxByu;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().Byu = Byu;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.GetComponent<ItemInfoShopPersonSnar>().description = description;
            GameControll.instance.ShopPanel.GetComponent<Shop>().InfoPanelPersSnar.SetActive(true);
        }
    }
    private void Update()
    {
        MaxByuText.text = $"{Byu}/{MaxByu}";
        PriceText.text = Price.ToString();
        if (Valet == "serebro")
        {
            CoinImg.sprite = SpriteCoin[0];
        }
        else if (Valet == "almaz")
        {
            CoinImg.sprite = SpriteCoin[1];
        }
        else if (Valet == "KlanMoney")
        {
            CoinImg.sprite = SpriteCoin[2];
        }
        if (type == "Predmet")
        {
            NameText.text = Name;
            if (Name == "UserUpdateMaterial")
            {
                AvatarImg.sprite = GameControll.instance.material[0];
            }
            else if (Name == "svitok")
            {
                AvatarImg.sprite = GameControll.instance.material[1];
            }
            else if (Name == "modifikator")
            {
                AvatarImg.sprite = GameControll.instance.material[2];
            }
            else if (Name == "Zelie rosta")
            {
                AvatarImg.sprite = GameControll.instance.material[3];
            }
            else if (Name == "Zelia usileniya")
            {
                AvatarImg.sprite = GameControll.instance.material[4];
            }
            else if (Name == "Svitok zatochki A")
            {
                AvatarImg.sprite = GameControll.instance.material[5];
            }
            else if (Name == "Svitok zatochki S")
            {
                AvatarImg.sprite = GameControll.instance.material[6];
            }
            else if (Name == "Svitok zatochki SR")
            {
                AvatarImg.sprite = GameControll.instance.material[7];
            }
            else if (Name == "Bilet areny")
            {
                AvatarImg.sprite = GameControll.instance.material[8];
            }
        }
    }
}
