using UnityEngine;
using UnityEngine.InputSystem;

public class LighterController : MonoBehaviour
{
    public Light lighterFlame;
    public OxygenManager oxygenManager;
    public float oxygenDrainWhileLit = 1.5f;

    private bool isLit = false;
    // 최신 Starter Assets의 Trigger 액션을 연결할 변수
    public InputActionReference toggleAction;

    void OnEnable() => toggleAction.action.performed += Toggle;
    void OnDisable() => toggleAction.action.performed -= Toggle;

    void Toggle(InputAction.CallbackContext ctx)
    {
        isLit = !isLit;
        lighterFlame.intensity = isLit ? 1.5f : 0f;
    }

    void Update()
    {
        if (isLit && oxygenManager != null)
            oxygenManager.AddPenalty(oxygenDrainWhileLit * Time.deltaTime);
    }
}