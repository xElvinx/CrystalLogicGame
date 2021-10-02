using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Movetest : MonoBehaviour
{
    private UnityArmatureComponent player;

    void Start()
    {
        player = GetComponent<UnityArmatureComponent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Input.GetMouseButton(0));
        if (Input.GetMouseButtonDown(0))
        {
            player.animation.Play(("Attack"));
        } else if (Input.GetAxis("Horizontal") != 0f)
        {
            player.animation.Play(("run"));
        } else
        {
            player.animation.Play(("idle"));
        }
    }
}
