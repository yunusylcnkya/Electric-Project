using UnityEngine;

public class Wire : MonoBehaviour
{
    public Port inputPort;
    public Port outputPort;

    public LineRenderer line;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateConnection();
        }
    }

    public void CreateConnection()
    {
        inputPort.isConnected = true;
        outputPort.isConnected = true;

        outputPort.onValueChanged += inputPort.SetValue;
        outputPort.onValueChanged.Invoke(outputPort.value);
        line.positionCount = 2;
        line.SetPosition(0, inputPort.transform.position);
        line.SetPosition(1, outputPort.transform.position);
    }
}
