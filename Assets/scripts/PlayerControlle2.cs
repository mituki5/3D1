using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlle2 : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float gravityModifier;//privateは省略
    [SerializeField]float jumpForce;//ジャンプ力
    [SerializeField]bool isOnGround;//地面についているか
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        //rb.AddForce(Vector3.up * 1000);//上え飛ばす
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround)//スペースキーが押されて、かつ、地面にいたら
        {
            rb.AddForce(Vector3.up * jumpForce ,ForceMode.Impulse);//上へ力を加える
            isOnGround = false;//ジャンプした＝地面にいない
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;//地面についている状態に変更
        }
 
    }
}
