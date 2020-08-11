using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //[SerializeField] private float bgSpeed = 0;

    private Renderer meshRender;

    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //renderer.material.mainTextureOffset += new Vector2(0, bgSpeed * Time.deltaTime);
    }
}
