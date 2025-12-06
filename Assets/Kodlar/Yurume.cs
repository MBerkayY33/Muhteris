using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yurume : DurumKodu
{
    public override void EnterState(AmeleHareket amele)
    {
        amele.animator.SetTrigger("Yurume");
        
    }
    public override void UpdateState(AmeleHareket amele)
    {
        amele.YonDegistir();
        amele.HareketEt();

        // beklemeye geçiþ
        if (amele.yatayGirdi == 0)
        {
            amele.SwitchState(amele.bekleme);
        }
        //zýplamaya geçiþ
        if (amele.ziplamaGirdi > 0 && amele.zemindeMi)
        {
            amele.SwitchState(amele.ziplama);
        }
        //ateþ etme durumuna geçiþ
        if (amele.saldiriGirdi > 0)
        {
            amele.SwitchState(amele.atesEtme);
        }
    }
    public override void ExitState(AmeleHareket amele)
    {
        amele.animator.ResetTrigger("Yurume");
    }
}
