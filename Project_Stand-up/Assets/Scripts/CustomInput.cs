using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomInput : MonoBehaviour
{

    [SerializeField] float lx = 15, ly = 10;
    [SerializeField] float scaler = 10f;

    [SerializeField] TestSerialRead reader;

    [SerializeField] Text[] valueLabel = new Text[4];
    [SerializeField] RectTransform pointer;

    [SerializeField] float gx;
    [SerializeField] float offsetX;
    [SerializeField] float gy;
    [SerializeField] float offsetY;

    public bool isSitdown = false;

    /*
     * センサーのイメージ
     * ①    |    ②
     * --    o    --
     * ④    |    ③
     * */

    void Update()
    {

        // 値の取得
        float m1 = reader.GetV[0];
        float m2 = reader.GetV[1];
        float m3 = reader.GetV[2];
        float m4 = reader.GetV[3];

        float sum = 1 + m1 + m2 + m3 + m4;

        // 重心計算
        gx = (m1 * -lx + m2 * lx + m3 * lx + m4 * -lx) / (sum) + offsetX;
        gy = (m1 * ly + m2 * ly + m3 * -ly + m4 * -ly) / (sum) + offsetY;

        gx *= scaler;
        gy *= scaler;

        isSitdown = sum > 20000;

        ApplyUserInterface();

    }

    void ApplyUserInterface()
    {
        for (int i = 0; i < 4; i++)
        {
            valueLabel[i].text = reader.GetV[i].ToString();
        }

        pointer.anchoredPosition = new Vector2(gx, gy); 
    }

}
