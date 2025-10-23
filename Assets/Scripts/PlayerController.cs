using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //プレイヤーオブジェクト
    public GameObject body;

    // 移動設定
    public float moveSpeed = 20.0f;
    public float dashSpeed = 50.0f;
    public float gravity = 9.81f;
    public float jumpPower = 8.0f;

    // 移動
    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;

    // Animator参照
    private Animator animator;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    
    void Update()
    {
        //ゲームステータスplayingじゃないなら何もしない
        if (GameManager.gameState != GameState.playing) return;

        if (controller.isGrounded) //地面にいるなら
        {
            //水平入力
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                moveDirection.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
            }
            else
            {
                moveDirection.x = 0;
            }

            //垂直入力
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                moveDirection.z = Input.GetAxisRaw("Vertical") * moveSpeed;
            }
            else
            {
                moveDirection.z = 0;
            }

            //スペースキーでジャンプ
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpPower;
                
            }
        }

        //重力付与
        moveDirection.y -= gravity * Time.deltaTime;

        //実際の移動の実行
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);


    }
}
