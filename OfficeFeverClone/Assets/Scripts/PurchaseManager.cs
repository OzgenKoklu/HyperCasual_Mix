using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    public int MoneyCount = 0;

    private void OnEnable()
    {
        TriggerEventManager.OnMoneyCollected += IncreaseMoney;
    }

    private void OnDisable()
    {
        TriggerEventManager.OnMoneyCollected -= IncreaseMoney;
    }

    void IncreaseMoney()
    {
        MoneyCount += 50;

    }

}
