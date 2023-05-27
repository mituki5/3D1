using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //面倒なのでrivate省略してます
    [SerializeField]GameObject obstaclePrefab;//障害物プレハブ
    Vector3 spawnPos = new Vector3(25,0,0);//スポーンする場所
    float elapsedTime;//経過時間
    PlayerControlle2 playerControllerScript;
    // Start is called before the first frame update
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControlle2>();
        //プレイヤーからスプリクトとを奪ってくるイメージ
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;//毎Fの時間を足していく
        //経過時間が2秒を越えて、かつ、ゲームオーバーではない
        if (elapsedTime > 2.0f)
        {
            Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);
            elapsedTime = 0.0f;
        }
        //Debug.Log(elapsedTime);//デバック

    }
}
