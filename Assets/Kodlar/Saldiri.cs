using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saldiri : MonoBehaviour
{
    public float 
        atesEtmeHizi,
        atesEtmeZamanAraligi,
        atesEtmeAni
        ;

    public GameObject mermi;
    public Transform atesEtmeNoktasi;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AtesEtme()
    {
        GameObject yeniMermi = Instantiate(mermi, atesEtmeNoktasi.transform.position, Quaternion.identity);

        Rigidbody2D mermiRb = yeniMermi.GetComponent<Rigidbody2D>();

        float yon = transform.localScale.x;

        mermiRb.velocity = new Vector2(atesEtmeHizi * yon, 0);
    }

}
