using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusme : DurumKodu
{
    public override void EnterState(AmeleHareket amele)
    {
       amele.animator.SetTrigger("Dusme");
    }

    public override void UpdateState(AmeleHareket amele)
    {
        amele.YonDegistir();
        amele.HareketEt();
        // Yere temas ettiyse beklemeye dön
        if (amele.zemindeMi)
        {
            amele.SwitchState(amele.bekleme);
            return;
        }
    }

    public override void ExitState(AmeleHareket amele)
    {
        amele.animator.ResetTrigger("Dusme");
    }

    
}
