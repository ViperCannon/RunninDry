using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.IsWheelSpinning())
        {
            gameObject.transform.Rotate(0f, 0f, -180f * Time.deltaTime);
        }
    }
}
