﻿using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform player;

    [Header("跟蹤速度"), Range(0, 10)]
    public float speed = 1.5f;
    [Header("上方限制")]
    public float top = -3;
    [Header("下方限制")]
    public float bottom = 5;

    /// <summary>
    /// 遊戲開始執行
    /// </summary>
    private void Start()
    {
        player = GameObject.Find("玩家").transform;
    }

    /// <summary>
    /// 延後更新(在Update之後執行:攝影機推薦)
    /// </summary>
    private void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// 追蹤玩家座標方法
    /// </summary>
    private void Track()
    {
        Vector3 posplayer = player.position;
        Vector3 posCamera = transform.position;

        posplayer.x = 0;

        posplayer.z =  Mathf.Clamp(posplayer.z, top, bottom);

        transform.position = Vector3.Lerp(posCamera, posplayer, 0.5f);   // camera 往 player 前進 0.5f
    }
}
