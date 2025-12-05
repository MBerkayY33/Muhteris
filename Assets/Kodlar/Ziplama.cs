using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziplama : DurumKodu
{
    public override void EnterState(AmeleHareket amele)
    {
        amele.animator.SetTrigger("Ziplama");
        amele.AmeleRb.velocity = new Vector2(amele.AmeleRb.velocity.x, amele.ZiplamaHizi);
    }
    public override void UpdateState(AmeleHareket amele)
    {
        amele.YonDegistir();
        if(amele.yatayGirdi != 0)
        {
            amele.HareketEt();
        }

        // dusme durumuna geçiþ
        if (amele.AmeleRb.velocity.y < 0 )
        {
            amele.SwitchState(amele.dusme);
        }
        
    }
    public override void ExitState(AmeleHareket amele)
    {
        amele.animator.ResetTrigger("Ziplama");
    }
}
