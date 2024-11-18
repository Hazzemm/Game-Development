using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bus : MonoBehaviour
{
    // Adjust this speed according to your requirements

    public float movespeed = 25f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f,0f,-movespeed*Time.deltaTime);
    }

}
