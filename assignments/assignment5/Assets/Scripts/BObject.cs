using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BObject : MonoBehaviour
{
    private float shakeSpeed = 0.1f;
    private float maxShakeOffset = 0.1f;

    private IEnumerator shakeCoroutine;

    void Start()
    {
        GameController.OnCObjectPointerEnter += StartShake;
        GameController.OnCObjectPointerExit += StopShake;
        shakeCoroutine = Shake();
    }

    void StartShake()
    {
        StartCoroutine(shakeCoroutine);
    }

    void StopShake()
    {
        StopCoroutine(shakeCoroutine);
    }

    IEnumerator Shake()
    {
        while(true)
        {
            yield return new WaitForSeconds(shakeSpeed / 2);
            Vector3 originalPosition = transform.position;
            Vector3 newPosition = new Vector3
            {
                x = originalPosition.x + Random.Range(-maxShakeOffset, maxShakeOffset),
                y = originalPosition.y + Random.Range(-maxShakeOffset, maxShakeOffset),
                z = originalPosition.z + Random.Range(-maxShakeOffset, maxShakeOffset)
            };
            transform.SetPositionAndRotation(newPosition, transform.rotation);
            yield return new WaitForSeconds(shakeSpeed / 2);
            transform.SetPositionAndRotation(originalPosition, transform.rotation);
        }
        
    }
}
