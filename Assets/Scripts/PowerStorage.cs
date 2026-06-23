using System;
using System.Collections;
using UnityEngine;

public class PowerStorage : ElectricUnit
{
    public Port inputPort;
    public Port outputPort;

    public int maxCapacity;
    public int currentStorageAmount;

    public int maxOutput;
    public int currentOutput;

    public float refreshRate = 5;

    void Start()
    {
        StartCoroutine(RefreshCoroutine());
    }

    IEnumerator RefreshCoroutine()
    {
        while (true)
        {

            int usedEnergy = Mathf.Min(GetConnectedDevicesCost(), currentOutput);
            currentStorageAmount = usedEnergy;
            currentStorageAmount += inputPort.value;
            currentStorageAmount = Math.Clamp(currentStorageAmount, 0, maxCapacity);

            currentOutput = Mathf.Min(currentStorageAmount, maxOutput);
            outputPort.SetValue(currentOutput);
            yield return new WaitForSeconds(refreshRate);
        }
    }


    public int GetConnectedDevicesCost()
    {
        return 0;
    }
}
