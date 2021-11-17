using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public GameObject selfobject;

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        transform.position = target.position;
        Vector3 v3Position = selfobject.transform.position;
        v3Position.z = -10;
        selfobject.transform.position = v3Position;
    }
}
