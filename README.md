# Sparta Metaverse

## ✅ 개요 
Unity 기반의 2D 메타버스 프로젝트로, 플레이어는 가상의 공간을 자유롭게 탐험하고,
NPC와 상호작용하며 다양한 미니게임에 참여할 수 있습니다.

## 주요 기능 🎮
-  캐릭터 이동, 점프, 상호작용 (Input System)
-  NPC와 대화 시스템 (타이핑 효과 포함)
-  입장/취소 UI 및 상태 기반 UI 전환
-  미니게임 포탈 및 씬 전환 기능
-  점수 저장 및 불러오기 (PlayerPrefs 사용)
-  ESC 키로 게임 종료 메뉴 열기

## 프로젝트 구조 📁

- `Scenes/`: 스타트 씬, 메인 씬, 미니게임 씬
- `Scripts/Manager`: GameManager, UIManager 등 매니저 클래스
- `Scripts/UI`: TalkUI, EnterUI 등 UI 클래스
- `Scripts/Entity`: MainPlayer, EnterControl, CameraFollow 등 플레이어,카메라 조작/상호작용 클래스
- `Scripts/Interface`: IInteract, ICancel 등 상호작용 인터페이스
- `Scripts/Shared`: 모든 씬 공통으로 쓰이는 BaseUI
- `Prefabs/`: UI 프리팹

## 실행 방법 ▶️
1. Unity 2022.3 LTS 이상 버전으로 프로젝트 열기
2. StartScene 실행하면 게임이이 시작됩니다

## 사용한 기술 및 패키지 🛠
- Unity 2D URP
- TextMeshPro
- Unity Input System
- PlayerPrefs
