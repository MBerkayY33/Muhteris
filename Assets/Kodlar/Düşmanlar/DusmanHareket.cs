using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanHareket : MonoBehaviour
{
    public float maxCan;

    [HideInInspector] public float mevcutCan;
    void Start()
    {
        mevcutCan = maxCan;
    }
    void Update()
    {
        
    }
    public static void HasarAl(float mevcutCan, float hasar)
    {
        mevcutCan -= hasar;
    }

    public static void Olum(float mevcutCan)
    {
        if (mevcutCan <= 0)
        {
            Destroy(GameObject.FindWithTag("Dusman"));
        }
    }
}
