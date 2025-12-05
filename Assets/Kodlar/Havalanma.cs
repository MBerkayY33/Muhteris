using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Havalanma : DurumKodu
{
    public override void EnterState(AmeleHareket amele)
    {
       amele.animator.SetTrigger("Havalanma");
    }
    public override void UpdateState(AmeleHareket amele)
    {
        // Düþüþ aþamasý baþladý
        if (amele.AmeleRb.velocity.y < 0)
        {
            amele.SwitchState(amele.dusme);
            return;
        }

        // Yere temas ettiyse beklemeye dön
        if (amele.zemindeMi)
        {
            amele.SwitchState(amele.bekleme);
            return;
        }
    }


    public override void ExitState(AmeleHareket amele)
    {
        amele.animator.ResetTrigger("Havalanma");
    }

    
}
