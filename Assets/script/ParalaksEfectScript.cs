using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaksEfectScript : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private float paralax;
    private float StartPosX;

    void Start()
    {
        StartPosX = transform.position.x;
    }

   
    void Update()
    {
        float distX = (MainCamera.transform.position.x * (1 - paralax));
        transform.position = new Vector3(StartPosX + distX, transform.position.y, transform.position.z);
    }
}
