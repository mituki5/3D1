using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetBackground : MonoBehaviour
{
    Vector3 startPos;//リピートの開始位置
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;//ゲーム開始時の場所を記憶
    }

    // Update is called once per frame
    void Update()
    {
        //何かの条件が満たされたら…
        if (startPos.x - transform.position.x > 50.0f)//現在のX座標‐最初のX座標　＞　規定値
        {
            transform.position = startPos;//場所をリセット
        }
    }
}
