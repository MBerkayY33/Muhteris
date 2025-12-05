using UnityEngine;
public abstract class DurumKodu
{
    public abstract void EnterState(AmeleHareket amele);
    public abstract void UpdateState(AmeleHareket amele);
    public abstract void ExitState(AmeleHareket amele);
}
