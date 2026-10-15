using UnityEngine;

public class PhysicsHand : MonoBehaviour
{
    [Header("추적할 대상 (VR 컨트롤러 또는 마우스 타겟)")]
    public Transform targetController;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 물리 떨림 현상을 부드럽게 보정
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    {
        if (targetController == null) return;

        // 1. 컨트롤러의 위치로 이동하려는 벡터 계산
        Vector3 direction = targetController.position - rb.position;

        // 2. Rigidbody의 속력을 조절하여 물리 충돌(관 벽)을 무시하지 않고 밀려나도록 설정
        rb.linearVelocity = direction / Time.fixedDeltaTime;

        // 3. 회전 값 동기화
        rb.MoveRotation(targetController.rotation);
    }
}