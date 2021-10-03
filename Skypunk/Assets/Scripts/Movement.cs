using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 oldPos;
    Vector3 oldPosCam;
    Collider collider;
    SpriteRenderer oldCollider;

    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;
    //[SerializeField] private Scene scene;

    public float radius = 0.1f;
    public float speed = 0.5f;

    float touchPosX = 0;
    float touchPosY = 0;

    void Start()
    {
        oldPos = transform.position;
        oldPosCam = cam.transform.position;
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

            collider = GetCollider();
            if (collider != null)
            {
                int countChild = collider.gameObject.transform.childCount;

                collider.transform.GetChild(countChild - 1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                oldCollider = collider.transform.GetChild(countChild - 1).gameObject.GetComponent<SpriteRenderer>();

                collider = null;
            } else if (oldCollider != null)
            {
                oldCollider.enabled = false;
                oldCollider = null;
            }

        } else if (Physics.CheckSphere(transform.position, radius, layerMask) && Input.GetMouseButtonUp(0)) 
        {
            collider = GetCollider();

            oldPos = collider.transform.position;
            oldPosCam.y = oldPosCam.y + 142.5f;

            Destroy(collider);

            Collider[] deleteCollider2D = Physics.OverlapBox(transform.position, new Vector2(500f, 2f), Quaternion.Euler(0, 0, 0), layerMask);
            foreach (Collider i in deleteCollider2D)
            {
                Destroy(i.gameObject);
            }

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, oldPos, speed);
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, oldPosCam, speed);
        }
    }

    private Collider GetCollider()
    {
        Collider[] colliderList = Physics.OverlapBox(transform.position, new Vector2(500f, 2f), Quaternion.Euler(0, 0, 0), layerMask);
        float minDist = 100f;

        Collider coll = new Collider();

        foreach (Collider i in colliderList)
        {
            float dist = Vector3.Distance(transform.position, i.transform.position);
            int count = i.gameObject.transform.childCount;
            i.transform.GetChild(count - 1).gameObject.GetComponent<SpriteRenderer>().enabled = false;

            if (dist < minDist)
            {
                coll = i;
                minDist = dist;
            }
        }

        return coll;
    }
}
