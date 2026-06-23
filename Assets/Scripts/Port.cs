using System;
using UnityEngine;
using DG.Tweening;


public enum PortType
{
    Input,
    Output
}
public class Port : ElectricUnit
{
    public int value;
    public Action<int> onValueChanged;
    public PortType type;
    public bool isConnected;


    public Color showColor;
    public Color hideColor;
    public Renderer rend;
    Tween portTween;

    public void SetValue(int newValue)
    {
        if (newValue == value)
        {
            return;
        }
        value = newValue;
        onValueChanged?.Invoke(value);
    }


    public void ShowPort()
    {
        if (portTween != null)
            portTween.Kill();
        rend.material.color = showColor;
        portTween = transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0.4f);
    }
    public void HidePort()
    {
        if (portTween != null)
            portTween.Kill();
        rend.material.color = hideColor;
        portTween = transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.4f);

    }

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowPort();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            HidePort();
        }
    }
}
