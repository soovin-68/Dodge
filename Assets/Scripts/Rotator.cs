using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f; // 회전 속도
    public Vector3 center = Vector3.zero; // 회전 중심점

    void Update()
    {
        // 중심점을 기준으로 회전
        transform.RotateAround(center, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
