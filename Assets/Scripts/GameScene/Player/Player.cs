using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Vector3 moveSpeed = Vector3.zero;
    [SerializeField]
    float jumpPower = 10.0f;
    [SerializeField]
    GroundCheck groundCheck;

    // 2Dなので注意！
    Rigidbody2D player_rb2d;

    // Start is called before the first frame update
    void Start()
    {
        // 自身にアタッチされているRigidBody2Dを取得する
        player_rb2d = GetComponent<Rigidbody2D>();
        SceneController.GetInstance();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 move = Vector3.zero;

        // 右移動
        if (InputController.GetInstance().GetIsInputKey(InputController.EnKey.enKey_PlayerRight))
        {
            move.x += moveSpeed.x;
        }
        // 左移動
        if (InputController.GetInstance().GetIsInputKey(InputController.EnKey.enKey_PlayerLeft))
        {
            move.x += -moveSpeed.x;
        }
        move *= Time.deltaTime;
        transform.Translate(move);
    }

    void Jump()
    {
        // 地面に居なかったら処理終了
        if(!groundCheck.GetIsGround())
        {
            return;
        }
        // スペースキーが押されていなかったら処理終了
        if (!InputController.GetInstance().GetIsInputKey(InputController.EnKey.enKey_PlayerJump))
        {
            return;
        }

        // 加わっている力を一旦リセット
        player_rb2d.velocity = Vector2.zero;
        // 上方向に力を加える
        player_rb2d.AddForce(new Vector2(0.0f, jumpPower), ForceMode2D.Impulse);
    }
}
