using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBackground : MonoBehaviour
{
    [SerializeField] private float animSpeed = 1f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = animSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
