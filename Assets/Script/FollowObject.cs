using System.ComponentModel;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [Header("�n���H������")]
    public Transform target;
    [Header("�첾")]
    public float y = -3;

    private void Update()
    {
        Vector3 targetPos = target.position;
        targetPos.y += y;
        transform.position = targetPos;
    }
}
