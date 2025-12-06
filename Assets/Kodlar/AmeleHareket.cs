using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeleHareket : MonoBehaviour
{
    public DurumKodu currentState;
    public DurumKodu bekleme = new Bekleme();
    public DurumKodu yurume = new Yurume();
    public DurumKodu ziplama = new Ziplama();
    public DurumKodu dusme = new Dusme();
    public DurumKodu atesEtme = new AtesEtme();

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D AmeleRb;

    [Header("Çevre Kontrolleri")]
    public bool zemindeMi;
    public bool duvardaMi;
    public int Yon;

    [Header("Tuþ Girdileri")]
    public float yatayGirdi;
    public float duseyGirdi;
    public float ziplamaGirdi;
    public float saldiriGirdi;

    [Header("Atamalar")]
    public LayerMask zemin;
    public Transform ZeminKontrol;
    public Transform DuvarKontrol;

    [Header("Parametreler")]
    public float YurumeHizi;
    public float ZiplamaHizi;
    public float SuzulmeHizi;
    public float zeminKontrolYaricapi;
    public float duvarKontrolMesafesi;
    public float maxCan;
    public float hasar;

    private float mevcutCan;

    void Start()
    {
        Yon = 1;
        currentState = bekleme;
        animator = GetComponent<Animator>();
        AmeleRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
        saldiriGirdi = Input.GetAxisRaw("Fire");
    }

    private void CevreKontrol()
    {
        zemindeMi = Physics2D.OverlapCircle(ZeminKontrol.position, zeminKontrolYaricapi, zemin);
        duvardaMi = Physics2D.Raycast(DuvarKontrol.transform.position, Vector2.right, duvarKontrolMesafesi, zemin);
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
        else if (!zemindeMi && yatayGirdi != 0)
        {
            AmeleRb.velocity = new Vector2(SuzulmeHizi * Yon, AmeleRb.velocity.y);
        }
    }
    public static void HasarAl(float mevcutCan, float hasar)
    {
        mevcutCan -= hasar;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(ZeminKontrol.position, zeminKontrolYaricapi);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(DuvarKontrol.position, new Vector2(DuvarKontrol.position.x + duvarKontrolMesafesi * Yon, DuvarKontrol.position.y ));
    }
}
