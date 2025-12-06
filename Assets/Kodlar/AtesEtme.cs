using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEtme : DurumKodu
{
    public override void EnterState(AmeleHareket amele)
    {
        amele.animator.SetTrigger("AtesEtme");
        amele.AmeleRb.velocity = Vector2.zero;
    }
    public override void UpdateState(AmeleHareket amele)
    {
        //beklemeye geç
        if (amele.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && amele.saldiriGirdi <= 0)
        {
            amele.SwitchState(amele.bekleme);
        }
    }
    public override void ExitState(AmeleHareket amele)
    {
        amele.animator.ResetTrigger("AtesEtme");
    }
}
