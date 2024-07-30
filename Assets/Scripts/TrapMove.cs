using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    public float Speed; // 速度
    public float Angle; // 角度
    private Vector3 vec; // 移動ベクトル

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f) return;
        // 角度をラジアンに変換
        float rad = Angle * Mathf.Deg2Rad;
        // ラジアンから進行方向を設定
        Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
        // 方向に速度を掛け合わせて移動ベクトルを求める
        vec = direction * Speed * Time.deltaTime;
        // 物体を移動する
        transform.position += vec;
    }

    // カメラに表示されなくなった時、消去する
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
