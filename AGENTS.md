# BURIED(뷰리드) 개발 규칙

## 프로젝트 사실
- VR 1인칭 탈출 생존 퍼즐 공포 게임. 나무 관 안에서 깨어나며, 플레이어는 이동 불가, 시선과 손 상호작용만 가능하다.
- Unity 6 (URP), XR Interaction Toolkit, VirtualGrasp (Gleechi) SDK, Free Pack - VR Hands
- 대상 기기: Meta Quest 3S (컨트롤러). 개발 중에는 XR Device Simulator 사용.
- 활성 씬: Assets/Scenes/SampleScene.unity. Assets/_Recovery/는 건드리지 않는다.
- 기존 스크립트: LighterController, OxygenManager, PhysicsHand, EndHandler (Assets/Scripts)
- 연료와 산소는 같은 값이며 게이지는 하나다. 소진 시 암전 후 게임 오버. 기존 암전 연결(EndHandler)은 깨뜨리지 않는다.
- 코드의 "Oxygen"과 기획의 "연료"는 같은 개념이다. 이름 변경은 내가 승인하기 전까지 하지 않는다.
- 퍼즐(P1 단서 수집, P2 양철통, P3 덮개 점검, P4 자물쇠)은 확정이나 핵심 시스템 완료 전에는 범위 밖이다.

## 현재 씬의 손과 라이터 (확정)
- 기존 손 = XR Origin (VR) > Camera Offset > XR Controller Right. 자식으로 컨트롤러 모델(UniversalController)과 Lighter가 있다.
- XR Controller 루트는 컨트롤러 추적과 입력의 기준일 수 있으므로 삭제하지 않는다. 제거 대상은 컨트롤러 시각 모델과 기존 Lighter다.
- ReplayBaseLinePhysicalHand는 VirtualGrasp 에셋 프리팹을 그대로 가져온 것이다. 원본 프리팹은 수정하지 않는다.
- 현재 프로젝트에는 실제 라이터 모델이 없고, Unity Asset Store에서 가져올 예정이다.

## 작업 원칙
1. 추측하지 말고, 확인되지 않은 것은 "확인 필요"라고 말하고 질문한다.
2. 수정 전에 관련 파일을 읽고 현재 구조를 요약한다.
3. 기획과 충돌하는 제안은 하지 않는다. 불가피하면 이유를 설명하고 승인을 받는다.
4. 변경은 최소 범위로 하고, 수정할 파일과 이유를 먼저 알린다.
5. Library/, Temp/, Packages/, Assets/_Recovery/, 기존 .meta 파일은 요청 없이 수정하지 않는다.
6. 씬/프리팹 YAML 직접 수정은 위험을 먼저 설명하고, 가능하면 에디터 작업 절차(클릭 순서)로 안내한다.
7. 삭제는 "비활성화 → 내 확인 → 삭제" 순서다. 삭제 전에 참조하는 스크립트와 씬 연결을 모두 찾아 보고한다.
8. 설명과 코드 주석은 한국어, 소스 파일은 UTF-8로 유지한다.
9. 수치(속도, 소모율, 시간, 밝기, 파티클 수)는 SerializeField 또는 ScriptableObject로 노출한다.
10. Quest 3S 성능을 고려한다. 실시간 그림자 다수, 과도한 파티클, 고비용 후처리는 피하고, 쓰게 되면 이유를 알린다.

## 진행 방식
각 단계는 "계획 보고 → 내 승인 → 구현 → 검증 방법 보고" 순서이며, 한 번에 한 단계만 한다.
계획 보고에는 (1) 수정/생성/삭제할 파일, (2) 변경 이유와 영향 범위, (3) 내가 에디터에서 할 작업, (4) 완료 기준과 테스트 방법을 담는다.
구현 후 보고는 "바꾼 것 / 확인하지 못한 것 / 내가 에디터에서 할 일"을 구분한다.

## 테스트 환경 규칙
- 개발은 PC에서 하고, VR 기기(Meta Quest 3S)는 대여라 항상 테스트할 수 없다. 모든 기능은 PC에서 최대한 확인 가능하게 만든다.
- 각 단계의 완료 기준을 [PC 확인]과 [VR 확인]으로 나눈다. PC 확인만 끝난 항목은 "VR 검증 필요"로 표시하고 완료됐다고 단정하지 않는다.
- Codex는 Unity 에디터를 실행하거나 VR 기기를 조작할 수 없다. 에디터 실행과 VR 확인이 필요한 항목은 "내가 할 일"로 안내한다.
- 조정이 필요한 수치(물리, 불꽃, 연료, 밝기)는 Inspector에 노출한다. VR 세션에서 비교할 수 있도록 프리셋(Soft/Normal/Firm 등)과 개발 전용 디버그 표시(연료량 등)를 지원하고, 개발 전용 요소는 Development Build 또는 에디터에서만 활성화한다.
- docs/DEVLOG.md의 각 항목에 [PC 검증 완료] / [VR 검증 필요] / [VR 검증 완료] 태그를 붙인다.
- 각 단계 종료 시 "VR 검증 체크리스트"(확인 항목, 확인 방법, 정상 기준)를 docs/VR_CHECKLIST.md에 추가한다. 대여 세션에서 그대로 따라 할 수 있는 순서로 쓴다.

## Git 규칙
- main에 직접 커밋하지 않는다. 단계마다 main에서 브랜치를 새로 만든다. 이름은 feature/stepN-설명 형식이다.
- 작업 시작 전에 git status와 현재 브랜치를 확인하고 보고한다. 작업 트리가 깨끗하지 않으면 멈추고 알린다.
- 커밋은 작게 나누고, 메시지는 "[stepN] 한 줄 설명" 형식으로 한국어로 쓴다.
- 커밋 전 git status와 diff 요약을 확인한다. Library/, Temp/, Logs/, UserSettings/ 등 생성물이 포함되면 커밋하지 말고 알린다.
- 새로 만든 파일의 .meta 파일은 함께 커밋한다.
- 씬(.unity)/프리팹(.prefab) 변경이 포함된 커밋은 따로 분리하고, 무엇이 바뀌었는지 설명을 붙인다.
- force push, 히스토리 재작성(rebase, reset --hard), 브랜치 삭제, .gitignore 및 LFS 설정 변경은 내 승인 없이 하지 않는다.
- 푸시가 불가능한 환경이면 커밋까지만 하고 그 사실을 알린다.
- 단계가 끝나면 docs/DEVLOG.md에 항목을 추가한다 (날짜, 단계, 한 일, 확인하지 못한 것, 다음 할 일).
- 병합은 내가 GitHub에서 직접 한다. 다음 단계 브랜치는 병합된 최신 main에서 만든다.
