using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bekleme : DurumKodu
{
    public override void EnterState(AmeleHareket amele)
    {
        amele.animator.SetTrigger("Bekleme");
        amele.AmeleRb.velocity = new Vector2(0, amele.AmeleRb.velocity.y);
    }
    public override void UpdateState(AmeleHareket amele)
    {
        amele.YonDegistir();
        //beklemeye geçiþ
        if (amele.yatayGirdi != 0)
        {
            amele.SwitchState(amele.yurume);
        }
        //zýplamaya geçiþ
        if (amele.ziplamaGirdi > 0 && amele.zemindeMi)
        {
            amele.SwitchState(amele.ziplama);
        }
    }
    public override void ExitState(AmeleHareket amele)
    {
        amele.animator.ResetTrigger("Bekleme");
    }

}
