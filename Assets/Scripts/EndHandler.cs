using UnityEngine;
using System.Collections;

public class EndHandler : MonoBehaviour
{
    public CanvasGroup fadeCanvas; // 방금 만든 검은 화면의 Canvas Group
    public float fadeDuration = 3f; // 3초에 걸쳐 서서히 어두워짐

    public void TriggerEnd()
    {
        StartCoroutine(FadeOutAndStop());
    }

    IEnumerator FadeOutAndStop()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = t / fadeDuration;
            yield return null;
        }
        fadeCanvas.alpha = 1f;
        // 완전히 어두워진 후 그대로 정지 (시뮬레이션 종료)
    }

    
}