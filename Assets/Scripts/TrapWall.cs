using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWall : MonoBehaviour
{
    private Vector3 trapPos;

    // Start is called before the first frame update
    void Start()
    {
        trapPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f) return;
        transform.position = new Vector3(trapPos.x, (Mathf.Sin(Time.time) * 1.0f) + trapPos.y, trapPos.z);
    }
}
