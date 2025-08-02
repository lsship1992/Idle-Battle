using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private int speed;
    
    private bool _right;
    private bool _left;

    public void right()
    {
        _right = true;
        
    }
    public void rightUp()
    {
        _right = false;


    }
    public void leftDown()
    {
        _left = true;

    }
    public void lefttUp()
    {
        _left = false;


    }
    private void Update()
    {
        if (_right)
        {
            if (background.transform.localPosition.x > -1000f)
            {
                background.transform.localPosition = new Vector3(background.transform.localPosition.x - (speed * Time.deltaTime), background.transform.localPosition.y, 0);
                
            }
        }
        if (_left)
        {
            if (background.transform.localPosition.x < 1000f)
            {
                background.transform.localPosition = new Vector3(background.transform.localPosition.x + (speed * Time.deltaTime), background.transform.localPosition.y, 0);
                
            }
        }

    }
}
