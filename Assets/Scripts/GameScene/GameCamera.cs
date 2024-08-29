using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    GameObject player;
 

    [SerializeField]
    Vector3 CameraAddPos = Vector2.zero;
 

    [SerializeField]
    Vector2 CameraMaxPos = Vector2.zero;
    [SerializeField]
    Vector2 CameraMinPos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // Playerタグのついたオブジェクトをターゲットにする
        player = GameObject.FindGameObjectWithTag("Player");
        // 最初に座標更新しておく
        CameraUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーがいないなら何もしない
        if (player == null)
        {
            return;
        }
        CameraUpdate();
    }

    void CameraUpdate()
    {
        // カメラの位置を設定
        transform.position = player.transform.position + CameraAddPos;
 

        // 座標がオーバーしないように調整
        // Vector3 cameraPos = transform.position;
        // cameraPos.x = Mathf.Clamp(cameraPos.x, CameraMinPos.x, CameraMaxPos.x);
        // cameraPos.y = Mathf.Clamp(cameraPos.y, CameraMinPos.y, CameraMaxPos.y);
        // transform.position = cameraPos;
    }
}
