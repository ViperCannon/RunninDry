using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDisappearance : MonoBehaviour
{
    [SerializeField] private float DisappearTime = 3.0f;
    [SerializeField] private bool DestroyDisappearingObject = false;
    
    
    
    private void OnEnable()
    {
        StartCoroutine(WaitThenDisappear());
    }

    private IEnumerator WaitThenDisappear()
    {
        yield return new WaitForSeconds(DisappearTime);

        if (DestroyDisappearingObject)
        {
            Destroy(gameObject);
        }
        else gameObject.SetActive(false);
    }
}