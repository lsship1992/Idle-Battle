using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePersonScript : MonoBehaviour
{
    public static UsePersonScript instance;

    private void Awake()
    {
        instance = this;
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        GameControll.instance.PersonsUseFather.GetComponent<RectTransform>().sizeDelta = new Vector2(GameControll.instance.PersonsUseFather.GetComponent<RectTransform>().sizeDelta.x, GameControll.instance.PersonsUseFather.transform.childCount * 51.25f + 100);
    }

}
