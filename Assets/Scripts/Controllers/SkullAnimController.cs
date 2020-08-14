using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullAnimController : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.skullBombCount >= 5)
        {
            anim.Play("SkullButton");
        }
    }

    public void FireBomb()
    {
        GameController.skullBombCount = 0;
        FireBombFromSpaship();
    }

    private void FireBombFromSpaship()
    {
        Debug.Log("Fire Bomb..");
    }
}
