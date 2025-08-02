using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mail : MonoBehaviour
{
    public GameObject PrefabMail;
    public GameObject FatherMail;

    public GameObject NonMailObject;
    public void close()
    {
        gameObject.SetActive(false);
    }

    public void DeleteAll()
    {
        ClientSend.DeleteMailAll();
    }


    private void Update()
    {
        if (FatherMail.transform.childCount == 0)
        {
            NonMailObject.SetActive(true);
        }
        else
        {
            NonMailObject.SetActive(false);

        }
    }
}
