using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke(nameof(WarpPos), 1.0f);
        }
    }

    // ワープ処理
    private void WarpPos()
    {
        GameObject playerObject = GameObject.Find("Player");
        PlayerMove playerScript = playerObject.GetComponent<PlayerMove>();
        playerScript.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
