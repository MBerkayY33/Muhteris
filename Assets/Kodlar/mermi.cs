using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{
    private AmeleHareket amele;
    void Start()
    {
        amele = GameObject.FindGameObjectWithTag("Player").GetComponent<AmeleHareket>();
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Zemin")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag== "Dusman")
        {
            DusmanHareket.HasarAl(collision.gameObject.transform.GetComponent<DusmanHareket>().mevcutCan, amele.hasar);
            Destroy(gameObject,0.1f);
        }
    }
}
