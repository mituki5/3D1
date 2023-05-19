using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;
    public Text scoreText;
    public Text winText;
    private Rigidbody rb;
    private int Score;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        Score = 0;
        SetCountText();//UIの更新委託
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal=Input.GetAxis("Horizontal");
        var moveVertical=Input.GetAxis("Vertical");
        var movement=new Vector3(moveHorizontal,0,moveVertical);
        rb.AddForce(movement *speed);
    }
    void OnTriggerEnter(Collider other)
        
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            Score = Score + 1;//内部的にスコアを増やす
            SetCountText();//ついでに、UIを更新委託
        }
    }
    void SetCountText()
    { 
        scoreText.text = "Count: " + Score.ToString();
        if(Score >= 8)
        { 
            winText.text = "You win!";
        }
    }
}
