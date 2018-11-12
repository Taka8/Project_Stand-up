using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    //ポート名
    public string portName = "COM5";
    public int baudRate = 9600;

    SerialPort m_SerialPort;
    Thread m_Thread_;
    bool m_IsRunning = false;

    string m_Message;
    bool m_IsNewMessageReceived = false;

    void Awake()
    {
        Open();
    }

    void Update()
    {
        if (m_IsNewMessageReceived)
        {
            OnDataReceived(m_Message);
        }
        m_IsNewMessageReceived = false;
    }

    void OnDestroy()
    {
        Close();
    }

    private void Open()
    {
        m_SerialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
        m_SerialPort.Open();

        m_IsRunning = true;

        m_Thread_ = new Thread(Read);
        m_Thread_.Start();
    }

    private void Close()
    {
        m_IsNewMessageReceived = false;
        m_IsRunning = false;

        if (m_Thread_ != null && m_Thread_.IsAlive)
        {
            m_Thread_.Join();
        }

        if (m_SerialPort != null && m_SerialPort.IsOpen)
        {
            m_SerialPort.Close();
            m_SerialPort.Dispose();
        }
    }

    private void Read()
    {
        while (m_IsRunning && m_SerialPort != null && m_SerialPort.IsOpen)
        {
            try
            {
                m_Message = m_SerialPort.ReadLine();
                m_IsNewMessageReceived = true;
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }

    // 今回は不使用
    public void Write(string message)
    {
        try
        {
            m_SerialPort.Write(message);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}