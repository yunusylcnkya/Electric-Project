using System;
using UnityEngine;

public class WindTurbine : PowerSource
{
    public Transform blades;
    public float bladesForce;
    void Update()
    {
        if (isGeneratingPower)
        {
            blades.transform.Rotate(((float)currentOutput) / ((float)maxOutput) * bladesForce, 0, 0);
        }
    }
    public override bool CanGeneratePower()
    {
        return transform.position.y > 0;
    }


    public override void OnPowerGenerationStateChanged(bool newState)
    {
        isGeneratingPower = newState;
        if (isGeneratingPower)
        {
            float tempOutput = transform.position.y * 10;
            currentOutput = (int)Math.Clamp(tempOutput, 0, maxOutput);
        }
        else
        {
            currentOutput = 0;
        }

        outputPort.SetValue(currentOutput);
    }
}
