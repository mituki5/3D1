using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetBackground : MonoBehaviour
{
    Vector3 startPos;//リピートの開始位置
    float repeayWidth;//リピートの幅
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;//ゲーム開始時の場所を記憶
        repeayWidth = GetComponent<BoxCollider>().size.x / 2;
        //背景ののコライダーのｘ方向の長さの半分をリピート幅にする
        //【注意】これはStart内に書いてあるので、毎Ｆ変更とはされない
        //ずっと固定！！
    }

    // Update is called once per frame
    void Update()
    {
        //何かの条件が満たされたら…
        if (startPos.x - transform.position.x > repeayWidth)
            //現在のX座標‐最初のX座標　＞　規定値
        {
            transform.position = startPos;//場所をリセット
        }
    }
}
