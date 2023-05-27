using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]float speed = 30;//Groundを動く速さ
    PlayerControlle2 playerControllerScript;
    //実は、PlayerControllerというのも、Rigidbodyとかと同様に『クラス』なので、型として宣言できる。使い方はいつもと同じで＜型名＞変数名の順序
    //（例）rigidbody rb;
    //（例）int score;
    //とくに、public等にしたい場合は、
    //（例）public int score;
    //等とするが、普通は、publicにしない。とにかく＜型名＞+変数名の順序
    // Start is called before the first frame update
    float leftBound = -15;//左の限界値
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControlle2>();
        //まず、左辺は頭で宣言しただけなので、実態が不明
        //そこで代入が必要
        //PlayerControllerを持っているのはPlayer本人。なので、まず見つける（Find）する必要がある。
        //それがgamaObject.Findです。ただし、Findの引数には、一字一句同じ名前を入れる必要がある
        //なので、"player"とか誤字になるバグります。
        //GameObject.Find("Player")がプレイヤー自身を表すと考える。
        //そうすれば、そいつが持っているPlayerControllerほしいですね。
        //それは、GatComeponent<型名>（）という方法で取ってこれます。
        //実際、みなさんはroll a ballを作るときに、PlayerのRigidbodyをとってくるときに一回これを書いてます
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー状態でなければ、backgroundを動かす
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound　&& gameObject.CompareTag("Obstacle"))
            //左の限界値よりも左に行ってしまったら、かつ、左に行き過ぎたやつが障害物なら
        {
            //障害物を消してしまう
            Destroy(gameObject);
        }
    }
}
