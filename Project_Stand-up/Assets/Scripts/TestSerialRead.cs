using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSerialRead : MonoBehaviour {

    [SerializeField] SerialHandler serialHandler;

	void Start () {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }
	
	void Update () {
		
	}

    void OnDataReceived(string message)
    {
        Debug.Log("onReceived");

        var data = message.Split(
                new string[] { "\t" }, System.StringSplitOptions.None);
        if (data.Length < 2) return;

        try
        {
            Debug.Log(data[0].ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

}
