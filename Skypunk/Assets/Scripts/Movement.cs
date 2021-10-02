using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 oldPos;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject scene;

    public float radius = 0.1f;
    public float speed = 0.5f;

    float touchPosX = 0;
    float touchPosY = 0;

    void Start()
    {
        oldPos = transform.position;
        Debug.Log(Vector3.Distance(transform.position, scene.transform.GetChild(6).position));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = new Vector3(transform.position.x, transform.position.y);
        Vector2 nowPos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.Mouse0) &&
            nowPos.x < scale.x + transform.localScale.x / 2 && nowPos.x > scale.x - transform.localScale.x / 2 &&
            nowPos.y < scale.y + transform.localScale.y / 2 && nowPos.y > scale.y - transform.localScale.y / 2)
        {

            float nowPosX = nowPos.x;
            float nowPosY = nowPos.y;

            transform.position = new Vector3(nowPosX, nowPosY);
        } else if (Physics.CheckSphere(transform.position, radius, layerMask) && Input.GetMouseButtonUp(0)) 
        {
            Collider[] collider2D = Physics.OverlapSphere(transform.position, radius, layerMask);
            float minDist = 100f;

            foreach (Collider i in collider2D)
            {
                float dist = Vector3.Distance(transform.position, i.transform.position);
                if (dist < minDist)
                {
                    Debug.Log(i.transform.gameObject.name);
                    minDist = dist;
                }
            }

            Collider[] deleteCollider2D = Physics.OverlapBox(transform.position, new Vector2(50f, 1f), Quaternion.Euler(0, 0, 0), layerMask);
            foreach (Collider i in deleteCollider2D)
            {
                Destroy(i.gameObject);
            }

            foreach (Transform i in scene.transform)
            {
                if (Vector3.Distance(i.position, transform.position) > 3.1f)
                    i.position = new Vector3(i.position.x, i.position.y - 3f);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, oldPos, speed);
        }
    }
}
