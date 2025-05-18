# 202505_PortfolioUnitySimpleRPG
Unityプロジェクトで実装した、設計ポートフォリオ用のシンプルなRPGミニゲームです。
以下の画像はゲームプレイ中のスクリーンショットです
![Image](https://github.com/user-attachments/assets/0a48b112-3f79-446f-a02c-0072abb6405f)


---

## 🧠 設計方針

本プロジェクトでは以下の設計パターン・アーキテクチャを採用しています：

### 🎮 インゲーム
- ゲーム内シーケンス管理に **Stateパターン** を採用
- UIには **MVP（Model-View-Presenter）パターン** を適用

### 🛠 アウトゲーム
- **Facadeパターン** を用いた Manager クラスで機能を提供
- アクセスには **シングルトンパターン** を使用  
  ※ ZenjectなどのDIコンテナは、プロジェクトの規模と内容により今回は未使用

---

## 💻 開発環境

- **Unity バージョン**：`2023.1.0b20`

---

## 🔌 使用プラグイン

| プラグイン名             | 用途                                               |
|--------------------------|----------------------------------------------------|
| **R3**                   | UIにMVPパターンを適用するために使用               |
| **SerializableInterface**| `interface` を `SerializeField` に対応させるために使用 |
| **UniTask**              | 非同期処理の記述に使用                             |

---

## 🚀 クイックスタート

1. 以下のシーンファイルを開く：  
   `Assets/_Application/Scenes/RPG`
2. Unityエディタで再生ボタンを押下

---

## 🔍 注目コード（ポートフォリオの中心）

以下の3ファイルは、本プロジェクトの設計意図が最もよく表れている重要なコードです：

### 1. `BattleStateMachine.cs`
- **パス**：`Assets/_Application/Scripts/Core/State/BattleStateMachine.cs`  
- **概要**：StateパターンによるRPGシーンのシーケンス管理を実装

### 2. `BattleWindowPresenter.cs`
- **パス**：`Assets/_Application/Scripts/UI/Window/Battle/BattleWindowPresenter.cs`  
- **概要**：戦闘画面の描画処理を担当。MVPパターンによるUI制御を確認可能

### 3. `AudioManager.cs`
- **パス**：`Assets/_Util/Audio/Scripts/AudioManager.cs`  
- **概要**：音声再生全般を管理。FacadeパターンによりAPIとして機能を提供

---

## 🗂 プロジェクト構成

```Projectフォルダ概要
_Application : プロジェクト専用のアセットを格納。ファイルタイプごとに分けて管理
└Art : デザインリソースを格納
└Fonts : フォントファイルを格納
└Prefabs : プレハブファイルを格納
└Scenes : シーンファイルを格納
└Scripts : 【※１にて詳細】スクリプトファイルを格納
Utils : 他プロジェクトに流用可能な汎用的な機能を格納。機能単位でフォルダを分けて管理
└Audio : 音再生のマネージャー。Factoryパターンで実装。AudioManager.csにて実装内容の確認が可能
└Extension : 汎用的なエクステンションを格納
└GenerateSceneEnum : 登録されているSceneをenumファイルとして自動出力する
Packages
Plugins
```

```Scriptフォルダ構成
Scripts
└Battle : UIに直接関係しない戦闘機能を格納
└Core : ゲームを動かすもとになる基礎機能を格納。ステートパターンの基礎機能やRuntimeInitializeOnLoad機能を用いてどのシーンでもCoreSystemシーンを読み込む機能を格納
└Data : DBサーバーに置くような数値を管理する機能を格納。今プロジェクトはScriptableObjectで管理
└Effect : 演出にあたる機能を管理。ダメージが発生した際のエフェクト機能を格納
└Enum : Enumファイルを格納
└UI : UI機能を格納。スクリーン単位でフォルダを分けて管理。深い階層はView,Presenter,ViewModel,Modelに分けて管理。ViewModel,ModelはMonoBehaviourを継承していたらViewModel,継承していなければModelで分類
```

## ✏️ 備考

- 設計意図の明確さを重視し、小規模構成のプロジェクトで作成しています。