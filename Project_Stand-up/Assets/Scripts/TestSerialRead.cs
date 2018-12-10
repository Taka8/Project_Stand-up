using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSerialRead : MonoBehaviour {

    [SerializeField] SerialHandler serialHandler;
    [SerializeField] float m_Threshold = 500f;

    public float[] GetV = new float[4];

	void Start () {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }
	
	void Update () {
		
	}

    void OnDataReceived(string message)
    {
        
        var data = message.Split(
                new string[] { "\t" }, System.StringSplitOptions.None);
        if (data.Length < 2) return;

        try
        {
            for (int i = 0; i < 4; i++)
            {
                GetV[i] = float.Parse(data[i]);

                if (GetV[i] < m_Threshold) GetV[i] = 0;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

}
