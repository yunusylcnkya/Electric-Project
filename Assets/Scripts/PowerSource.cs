using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PowerSource : ElectricUnit
{
    public Port outputPort;
    public float refreshRate = 5;

    public int currentOutput;
    public int maxOutput;
    public bool isGeneratingPower;

    private void Start()
    {
        StartCoroutine(refreshCoroutine());
    }

    IEnumerator refreshCoroutine()
    {
        while (true)
        {
            OnPowerGenerationStateChanged(CanGeneratePower());
            yield return new WaitForSeconds(refreshRate);
        }
    }

    public virtual bool CanGeneratePower()
    {
        return true;
    }

    public virtual void OnPowerGenerationStateChanged(bool newState)
    {
        if (newState == isGeneratingPower) { return; }

        isGeneratingPower = newState;
        currentOutput = isGeneratingPower ? maxOutput : 0;
        outputPort.SetValue(currentOutput);
    }


}
