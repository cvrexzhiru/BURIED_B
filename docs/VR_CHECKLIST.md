# VR 검증 체크리스트

## 단계 1: 손 교체

진행 전 PC에서 VG_USE_UNITYXRINTERACTION_HAND define이 Standalone에만 추가되었고 Unity 컴파일이 끝났는지 확인한다. VG_XRI_Entries는 Resources의 VG_XRI_Actions를 가리키고, 액션 접두사는 Position, Rotation, Trigger, Grab, Haptics여야 한다. 두 InputActionManager 모두 VG_XRI_Actions를 첫 번째, 기존 XRI Default Input Actions를 두 번째로 둔다. VG_XRI_Entries, Prefab Variant, 씬 연결은 사용자가 에디터에서 구성한 뒤 아래 항목을 확인한다.

1. **양손 추적**
   - 확인 방법: Quest 3S를 착용하고 왼쪽과 오른쪽 컨트롤러를 각각 천천히 움직이고 회전한다.
   - 정상 기준: 해당 손만 대응하는 컨트롤러를 따라가며 좌우가 뒤바뀌거나 함께 움직이지 않는다.

2. **컨트롤러 액션**
   - 확인 방법: 각 컨트롤러의 트리거와 그립을 눌러 본다.
   - 정상 기준: VirtualGrasp가 좌우 입력을 각각 받으며 오류 없이 동작한다.

3. **손 메시 머티리얼**
   - 확인 방법: Prefab Variant의 GleechiRig/GleechiHandMesh를 선택해 Skinned Mesh Renderer의 Materials 참조와 Material의 Shader를 확인한다.
   - 정상 기준: 기존 M_GleechiHands와 SH_GleechiHands 참조가 그대로 유지된다.

4. **기존 컨트롤러 시각 모델**
   - 확인 방법: UniversalController를 비활성화한 상태에서 좌우 손을 움직여 본다.
   - 정상 기준: 에셋 손이 나타나고 기존 컨트롤러 시각 모델은 보이지 않는다. 참조 확인과 사용자 확인 전에는 오브젝트를 삭제하지 않는다.

5. **오류와 중복 장치**
   - 확인 방법: Unity Console을 비우거나 새 세션으로 열고 씬을 실행한 뒤 오류·경고를 확인한다.
   - 정상 기준: Missing Script, Missing Reference, 입력 액션 누락, 중복 Camera/AudioListener 관련 오류가 없다.

6. **범위 보호**
   - 확인 방법: 플레이어 시작 위치와 라이터·불·연료의 변경 여부를 확인한다.
   - 정상 기준: 이번 단계에서 해당 항목은 변경되지 않았다.

결과는 [VR 검증 완료]로 기록하기 전까지 [VR 검증 필요] 상태로 둔다.
