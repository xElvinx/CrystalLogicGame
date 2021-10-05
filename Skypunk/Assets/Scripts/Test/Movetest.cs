using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Movetest : MonoBehaviour
{
    private UnityArmatureComponent player;
    [SerializeField] private ParticleSystem ps;

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

            ps.Play();
            Thread.Sleep(1000);
            ps.Stop();
        }
    }
}
