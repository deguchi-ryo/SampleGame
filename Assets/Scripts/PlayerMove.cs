using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameManager myManager;
    public float speed; // 速度
    public float angle; // 角度
    private Vector3 vec; // 移動ベクトル
    public Vector3 gyroRotation; // ジャイロデータ
    private Vector2 startTouchPosition; // タッチ開始位置
    private Vector2 endTouchPosition; // タッチ終了位置
    private Vector2 direction; // タッチ方向
    private float lockAngle; // フリック入力前の角度

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f) return;

        // 角度をラジアンに変換
        float rad = angle * Mathf.Deg2Rad;
        // ラジアンから進行方向を設定
        Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0.0f);
        // 方向に速度を掛け合わせて移動ベクトルを算出
        vec = direction * speed * Time.deltaTime;
        // 物体を移動する
        transform.position += vec;

        // ジャイロ機能の検出
        GyroOperation();

        // タッチ入力の検出
        if (Input.touchCount > 0)
        {
            TouchOperation();
        }
    }

    // ジャイロ機能の処理
    private void GyroOperation()
    {
        // 実行環境を判定
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            // プレイヤーの位置を取得
            Vector3 playerPosition = transform.position;

            if (Input.GetKeyDown(KeyCode.A))
            {
                // 垂直方向に進行中はジャイロ機能をx軸に適用
                if (this.angle == 90.0f || this.angle == -90.0f) playerPosition.x -= 1.0f;
                playerPosition.y += 1.0f;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                // 垂直方向に進行中はジャイロ機能をx軸に適用
                if (this.angle == 90.0f || this.angle == -90.0f) playerPosition.x += 1.0f;
                playerPosition.y -= 1.0f;
            }

            // プレイヤーの移動
            transform.position = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
        }
        else
        {
            // 実機でのジャイロデータ取得
            if (SystemInfo.supportsGyroscope)
            {
                // ジャイロデータを取得
                gyroRotation = Input.gyro.rotationRateUnbiased;
            }
        }
    }

    // フリック入力時の処理
    private void TouchOperation()
    {
        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                startTouchPosition = touch.position;
                break;
            case TouchPhase.Ended:
                endTouchPosition = touch.position;
                direction = endTouchPosition - startTouchPosition;
                // プレイヤーの向きを変更
                ChangePlayerDirection(direction);
                break;
        }
    }

    // プレイヤーの変更する向きの指定
    private void ChangePlayerDirection(Vector2 direction)
    {
        float changeAngle;
        float lockAngle;
        // フリック方向を判定してプレイヤーの向きを変更
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // 水平方向のフリック
            if (direction.x > 0)
            {
                changeAngle = 0.0f;
                lockAngle = 180.0f;
                // 右方向
                directionChange(changeAngle, lockAngle);
            }
            else
            {
                changeAngle = 180.0f;
                lockAngle = 0.0f;
                // 左方向
                directionChange(changeAngle, lockAngle);
            }
        }
        else
        {
            // 垂直方向のフリック
            if (direction.y > 0)
            {
                changeAngle = 90.0f;
                lockAngle = -90.0f;
                directionChange(changeAngle, lockAngle);
            }
            else
            {
                changeAngle = -90.0f;
                lockAngle = 90.0f;
                directionChange(changeAngle, lockAngle);
            }
        }
    }

    // プレイヤーの方向変換
    private void directionChange(float angle, float lockAngle)
    {
        if (this.lockAngle == angle) return;
        this.angle = angle;
        this.lockAngle = lockAngle;
        float roundedX = Mathf.Round(transform.position.x);
        float roundedY = Mathf.Round(transform.position.y);
        transform.position = new Vector3(roundedX, roundedY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            myManager.GameOver();
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Clear")
        {
            myManager.GameClear();
            gameObject.SetActive(false);
        }

    }
}
