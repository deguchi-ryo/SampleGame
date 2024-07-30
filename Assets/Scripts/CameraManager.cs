using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = target.transform.position;

        cameraPos.z = -10.0f;
        Camera.main.gameObject.transform.position = cameraPos;

    }
}
