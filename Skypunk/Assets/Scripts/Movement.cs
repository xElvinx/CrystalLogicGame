using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 oldPos;
    [SerializeField] private Camera cam;

    public float speed = 0.5f;
    public float touchPosX = 0;
    public float touchPosY = 0;

    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 nowPos = cam.ScreenToWorldPoint(Input.mousePosition);

            float nowPosX = nowPos.x;
            float nowPosY = nowPos.y;

            transform.position = new Vector3(nowPosX, nowPosY);
        } else
        {
            transform.position = oldPos;
        }
    }
}
