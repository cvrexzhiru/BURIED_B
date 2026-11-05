# 개발 로그

## 2026-11-05 — 단계 1: 손 교체 준비

- 상태: [VR 검증 필요] (PC 확인은 아직 하지 않음)
- 한 일: Assets/Resources/VG_XRI_Actions.inputactions에 XRI Player 액션 맵을 추가했다. 좌우 손의 위치, 회전, 트리거, 그립, 햅틱 액션을 정의했다. VG_XRI_Entries의 리소스명은 VG_XRI_Actions, 액션 접두사는 Position, Rotation, Trigger, Grab, Haptics로 맞춘다.
- 확인하지 못한 것: Unity에서 InputActionAsset으로 가져오는지, VG_XRI_Entries 및 두 InputActionManager와 연결되는지, 좌우 손이 Quest 3S 컨트롤러를 따라가는지 확인하지 않았다.
- 다음 할 일: Standalone define을 추가하고 컴파일 상태를 확인한다. 사용자가 VG_XRI_Entries와 프로젝트 소유 Prefab Variant를 에디터에서 만들고, 두 InputActionManager 모두 VG_XRI_Actions를 첫 번째, 기존 XRI Default Input Actions를 두 번째로 연결한다. PC와 Quest 3S에서 양손 추적과 콘솔을 확인한다.
- 범위: SDK 파일·원본 프리팹·씬·Project Settings는 수정하지 않았다. 라이터/불, 연료, 시작 배치도 수정하지 않았다.
