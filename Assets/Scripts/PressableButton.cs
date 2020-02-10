using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 originalScale;
    public float multiplyer;

    private void Start()
    {
        originalScale = transform.localScale;
        pos = transform.localPosition;
    }

    public Vector3 GetPosition()
    {
        return pos;
    }

    public void ChangeScale(float value)
    {
        transform.localScale = new Vector3(
                                    originalScale.x * value,
                                    originalScale.y * value,
                                    originalScale.z * value);
        transform.position = new Vector3(
                                    transform.position.x,
                                    transform.position.y * value,
                                    transform.position.z);
    }

}
