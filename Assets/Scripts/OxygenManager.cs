using UnityEngine;
using UnityEngine.Events;

public class OxygenManager : MonoBehaviour
{
    [Header("산소 설정")]
    public float maxOxygen = 100f;
    public float decayRate = 1.2f; // 초당 기본 소모량

    [Header("이벤트 연결")]
    // [중요] 슬라이더의 Dynamic float 값과 연결할 이벤트
    public UnityEvent<float> onOxygenChanged;
    public UnityEvent onDepleted;

    private float current;
    private bool isDepleted = false;

    void Start()
    {
        current = maxOxygen;
    }

    void Update()
    {
        if (isDepleted) return;

        // 1. 산소 감소 로직
        current -= decayRate * Time.deltaTime;
        current = Mathf.Clamp(current, 0f, maxOxygen); // 0 이하로 내려가지 않게 방지

        // 2. [로그 확인] 실시간 산소량 확인 (콘솔창 참고)
        Debug.Log("현재 산소량: " + current);

        // 3. 0~1 사이의 값으로 변환하여 UI 슬라이더에 전달 (Dynamic float 이벤트)
        onOxygenChanged?.Invoke(current / maxOxygen);

        // 4. 고갈 확인
        if (current <= 0f)
        {
            isDepleted = true;
            onDepleted?.Invoke();
        }
    }

    // 라이터 켜졌을 때 추가 페널티 부여 함수
    public void AddPenalty(float amount)
    {
        if (!isDepleted)
        {
            current = Mathf.Clamp(current - amount, 0f, maxOxygen);
        }
    }
}