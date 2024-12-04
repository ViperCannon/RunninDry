using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed;
    public bool isScrolling = true;

    [SerializeField]
    Renderer bgRenderer;

    [SerializeField]
    Material[] bgMaterials; 

    // Update is called once per frame
    void Update()
    {
        if (isScrolling)
        {
            bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        }
        
    }

    public void UpdateBackground(int selection)
    {

    }
}
