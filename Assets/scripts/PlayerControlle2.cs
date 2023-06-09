﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlle2 : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem dirtParticle;
    Rigidbody rb;
    [SerializeField]float gravityModifier;//privateは省略
    [SerializeField]float jumpForce;//ジャンプ力
    [SerializeField]bool isOnGround;//地面についているか
    public bool gameOver = false;//何も書かなければprivateです
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        //rb.AddForce(Vector3.up * 1000);//上え飛ばす
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        //dirtParticle.Play();//最初から再生
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround && !gameOver)
            //スペースキーが押されて、かつ、地面にいたら、ゲームオーバーでないなら
        {
            rb.AddForce(Vector3.up * jumpForce ,ForceMode.Impulse);//上へ力を加える
            isOnGround = false;//ジャンプした＝地面にいない
            playerAnim.SetTrigger("Jump_trig");//ジャンプアニメ発動準備
            dirtParticle.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;//地面についている状態に変更
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))//障害物に衝突
        {
            gameOver = true;//ゲームオーバーにしてみる
            explosionParticle.Play();//再生
            //Debug.Log("Game Over!");//プレイ中にConsoleに表示される
            playerAnim.SetBool("Death_b", true);//ここで死亡状態ｂにする。（Death_b とかいうのは本来自分で定義できる）
            playerAnim.SetInteger("DeathType_int", 1);//integerは整数の意味。死亡のタイプ？を一番目のやつにする的な。
            dirtParticle.Stop();//砂のアニメは消す
        }    
    }
}
