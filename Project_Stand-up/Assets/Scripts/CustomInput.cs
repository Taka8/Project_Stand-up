using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomInput : MonoBehaviour {

    [SerializeField] float lx = 30, ly = 20;

    [SerializeField] TestSerialRead reader;

    [SerializeField] Text[] valueLabel = new Text[4];
    [SerializeField] RectTransform pointer;

    [SerializeField] float x;
    [SerializeField] float offsetX;
    [SerializeField] float y;
    [SerializeField] float offsetY;

    /*
     * センサーのイメージ
     * (x0, y0) = (-lx, ly), (x1, y1) = (lx, ly) , ... 
     * ⓪    |    ①
     * --    o    --
     * ②    |    ③
     * 
     * */
    
	void Update () {

        x = (((reader.GetV[0] * -lx) + (reader.GetV[1] * lx) + (reader.GetV[2] * -lx) + (reader.GetV[3] * lx)) / (1 + reader.GetV[0] + reader.GetV[1] + reader.GetV[2] + reader.GetV[3])) + offsetX;
        y = (((reader.GetV[0] * ly) + (reader.GetV[1] * ly) + (reader.GetV[2] * -ly) + (reader.GetV[3] * -ly)) / (1 + reader.GetV[0] + reader.GetV[1] + reader.GetV[2] + reader.GetV[3])) + offsetY;

        x *= 5;
        y *= 5;

        ApplyUserInterface();
    }
    
    void ApplyUserInterface()
    {
        for(int i = 0; i < 4; i++)
        {
            valueLabel[i].text = reader.GetV[i].ToString();
        }

        pointer.anchoredPosition = new Vector2(x, y);
    }

}
