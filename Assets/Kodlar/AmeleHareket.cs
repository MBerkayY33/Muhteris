using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeleHareket : MonoBehaviour
{
    public DurumKodu currentState;    
    public DurumKodu bekleme= new Bekleme();
    public DurumKodu yurume = new Yurume();
    public DurumKodu ziplama = new Ziplama();
    public DurumKodu dusme = new Dusme();
    public DurumKodu havalanma = new Havalanma();

    public LayerMask zemin;
    [HideInInspector]public Animator animator;
    public Transform ZeminKontrol;
    [HideInInspector]public Rigidbody2D AmeleRb;
    public float 
        YurumeHizi, ZiplamaHizi, SuzulmeHizi,
        zeminKontrolYaricapi,
        dusmeHizi
        ;
    public int Yon;

    public bool zemindeMi;

    public float 
        yatayGirdi,
        duseyGirdi,
        ziplamaGirdi
        ;

    void Start()
    {

        Yon = 1;
        currentState = bekleme;
        animator = GetComponent<Animator>();
        AmeleRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dusmeHizi = AmeleRb.velocity.y;
        currentState.UpdateState(this);
        Tusgirdi();
        CevreKontrol();
    }

    public void SwitchState(DurumKodu newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    private void Tusgirdi()
    {
        yatayGirdi = Input.GetAxisRaw("Horizontal");
        duseyGirdi = Input.GetAxisRaw("Vertical");
        ziplamaGirdi = Input.GetAxisRaw("Jump");       
    }
    

    private void CevreKontrol()
    {
        zemindeMi = Physics2D.OverlapCircle(ZeminKontrol.position, zeminKontrolYaricapi, zemin);
    }

    public void YonDegistir()
    {
        if (yatayGirdi == 0) return;

        float mevcutBoyutX = Mathf.Abs(transform.localScale.x);

        if (yatayGirdi > 0)
        {
           transform.localScale = new Vector3(mevcutBoyutX, transform.localScale.y, transform.localScale.z);
            Yon = 1;
        }
        else if (yatayGirdi < 0)
        {
            transform.localScale = new Vector3(-mevcutBoyutX, transform.localScale.y, transform.localScale.z);
            Yon = -1;
        }
    }

    public void HareketEt()
    {
        if (zemindeMi)
        {
            AmeleRb.velocity = new Vector2(YurumeHizi * Yon, AmeleRb.velocity.y);
        }
        else if( !zemindeMi && yatayGirdi != 0)
        {
            AmeleRb.velocity = new Vector2(SuzulmeHizi* Yon, AmeleRb.velocity.y);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ZeminKontrol.position, zeminKontrolYaricapi);
    }
}
