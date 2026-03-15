
### **📄 README.md (英文版)**

```markdown
# 🥽 Unity VR Grabbing Game (for Meta Quest 3)
```
[![Unity Version](https://img.shields.io/badge/Unity-2022.3+-blueviolet?style=for-the-badge&logo=unity)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-Meta%20Quest%203-4267B2?style=for-the-badge&logo=meta)](https://www.meta.com/quest/)

This is a **VR grabbing game** developed with Unity, specifically designed and coded for **Meta Quest 3**. The core mechanic revolves around intuitive hand interaction and object grabbing, offering two distinct and creative gameplay phases.

## 🎮 Game Overview

The game is divided into two unique parts, each showcasing different aspects of VR interaction:

1.  **Part 1: Craft the Car**
    *   **Objective**: Search for and grab individual car components scattered in the environment.
    *   **Mechanic**: Use your hands to physically pick up parts like wheels, chassis, and engine.
    *   **Goal**: Assemble all the parts to successfully "craft" a complete car. This phase focuses on precision grabbing and assembly logic.

2.  **Part 2: Become the Car!**
    *   **Objective**: After the car is built, you transition into the perspective of the car itself.
    *   **Mechanic**: Now, as the car, you use grabs to interact with the world—likely by grabbing blocks or other objects.
    *   **Goal**: To grab and manipulate blocks, possibly for stacking, moving, or solving a simple puzzle. This phase offers a playful shift in perspective and interaction style.

## ✨ Key Features

*   **Dual-Phase Gameplay**: Two completely different experiences in one game—from assembly to action.
*   **Designed for Meta Quest 3**: Optimized for the hardware and controllers, focusing on hand tracking and immersion.
*   **Core Grabbing Mechanics**: The central interaction is physics-based grabbing, demonstrating fundamental VR interaction design.
*   **Perspective Shift**: A unique twist where the player's role changes from a human builder to a sentient car.

## 🛠️ Built With

*   **Engine**: Unity
*   **Target Platform**: Meta Quest 3 (Android build target)
*   **SDKs**: Likely utilizes the **Meta XR All-in-One SDK** for platform integration, hand tracking, and interaction components.
*   **Language**: C# for all gameplay scripts.

## 🚀 Getting Started

These instructions will help you get a copy of the project up and running on your local machine for development and testing.

### Prerequisites

*   **Unity Hub** and **Unity Editor** (version 2022.3 LTS or later recommended).
*   **Meta XR All-in-One SDK** (should be imported via the Package Manager. The project's `Packages/manifest.json` might list it).
*   An understanding of Unity's XR Interaction Toolkit (likely used in the project).
*   (Optional) A **Meta Quest 3** headset for testing, or use the Link cable/Air Link for in-editor play mode.

### Installation

1.  **Clone the repository** (or download the ZIP).
    ```bash
    git clone https://github.com/LeoTheAuJai/Unity_VR_grabbing_game.git
    ```

2.  **Open the project in Unity Hub**:
    *   Launch Unity Hub.
    *   Click on the "Open" button and navigate to the folder where you cloned the project.
    *   Select the folder and let Unity Hub open it with a compatible Unity version.

3.  **Import necessary packages**:
    *   Once the project is open in Unity, go to **Window > Package Manager**.
    *   Check if all required packages (especially the **Meta XR All-in-One SDK** and **XR Interaction Toolkit**) are installed. If they are listed but not installed, click the "Install" button. The project might prompt you to install missing dependencies.

4.  **Configure for Meta Quest 3**:
    *   Go to **File > Build Settings**.
    *   Ensure the platform is set to **Android**.
    *   Under **Player Settings > Other Settings**, confirm the following:
        *   **Rendering** is set to OpenGLES or Vulkan (Quest 3 supports both).
        *   **Minimum API Level** is at least 29 (Android 10).
        *   **Scripting Backend** is set to **IL2CPP**.
        *   **Target Architectures** includes **ARM64**.
    *   Under **XR Plug-in Management**, ensure **Oculus** (or the Meta XR provider) is checked for the Android settings.

5.  **Play in Editor (Optional)**:
    *   If you have a Quest 3 connected via Link or Air Link, you can click the "Play" button in the Unity Editor to test the game directly.

## 🎥 Demo Video (Coming Soon)

A demonstration of the gameplay will be linked here once available.

## 📄 License

This project is open-source under the standard license found in the repository. See the `LICENSE` file for more details.

## 📬 Contact

Created by **LeoTheAuJai**. Feel free to reach out via GitHub.

---
```

### **📄 README.zh.md (中文版)**

```markdown
# 🥽 Unity VR 抓取遊戲 (for Meta Quest 3)

[![Unity 版本](https://img.shields.io/badge/Unity-2022.3+-blueviolet?style=for-the-badge&logo=unity)](https://unity.com/)
[![平台](https://img.shields.io/badge/平台-Meta%20Quest%203-4267B2?style=for-the-badge&logo=meta)](https://www.meta.com/quest/)

這是一款使用 **Unity** 開發，專為 **Meta Quest 3** 設計的 **VR 抓取遊戲**。其核心機制圍繞著直觀的手部互動與物件抓取，並提供兩種截然不同且富有創意的遊戲階段。

## 🎮 遊戲簡介

遊戲分為兩個獨特的階段，每個階段都展示了 VR 互動的不同面向：

1.  **第一階段：組裝賽車**
    *   **目標**：在環境中尋找並抓取散落的賽車零件。
    *   **機制**：使用雙手實際撿起輪胎、底盤、引擎等零件。
    *   **目的**：組裝所有零件，成功「打造」出一輛完整的賽車。此階段專注於精確抓取與組裝邏輯。

2.  **第二階段：化身為賽車！**
    *   **目標**：賽車完成後，你將轉變為賽車的視角來進行遊戲。
    *   **機制**：化身為賽車後，你透過「抓取」來與世界互動——可能是抓取方塊或其他物件。
    *   **目的**：抓取並操控方塊，可能用於堆疊、移動或解決簡單的謎題。這個階段提供了有趣的視角轉換和互動風格。

## ✨ 主要特色

*   **雙階段玩法**：一款遊戲包含兩種完全不同的體驗——從組裝到動作。
*   **專為 Meta Quest 3 設計**：針對該硬體和控制器進行優化，專注於手部追蹤與沉浸感。
*   **核心抓取機制**：主要的互動是基於物理的抓取，展示了基礎的 VR 互動設計。
*   **視角轉換**：獨特的玩法轉折，玩家的角色從人類建造者變成了有知覺的賽車。

## 🛠️ 使用技術

*   **遊戲引擎**：Unity
*   **目標平台**：Meta Quest 3 (Android 建置目標)
*   **SDKs**：可能使用了 **Meta XR All-in-One SDK** 來整合平台功能、手部追蹤和互動組件。
*   **程式語言**：C#（用於所有遊戲邏輯腳本）

## 🚀 本地安裝與執行

以下說明將幫助你在本機電腦上取得並執行此專案，以便進行開發或測試。

### 環境需求

*   **Unity Hub** 和 **Unity Editor**（建議使用 2022.3 LTS 或更新版本）。
*   **Meta XR All-in-One SDK**（應透過 Package Manager 導入。專案的 `Packages/manifest.json` 檔案中可能已列出）。
*   了解 Unity 的 XR Interaction Toolkit（本專案很可能使用了此工具包）。
*   （選擇性）一個用於測試的 **Meta Quest 3** 頭戴裝置，或使用 Link 線 / Air Link 進行編輯器內的即時遊玩。

### 安裝步驟

1.  **複製專案**（或下載 ZIP 檔）。
    ```bash
    git clone https://github.com/LeoTheAuJai/Unity_VR_grabbing_game.git
    ```

2.  **在 Unity Hub 中開啟專案**：
    *   啟動 Unity Hub。
    *   點擊「開啟 (Open)」按鈕，瀏覽到你複製專案的資料夾。
    *   選取該資料夾，讓 Unity Hub 用相容的 Unity 版本開啟它。

3.  **導入必要套件**：
    *   專案在 Unity 中開啟後，前往 **Window > Package Manager**。
    *   檢查所有必要的套件（特別是 **Meta XR All-in-One SDK** 和 **XR Interaction Toolkit**）是否已安裝。如果它們列在清單中但未安裝，請點擊「Install」按鈕。專案可能會提示你安裝缺少的依賴項。

4.  **針對 Meta Quest 3 進行設定**：
    *   前往 **File > Build Settings**。
    *   確認平台已設為 **Android**。
    *   在 **Player Settings > Other Settings** 中，確認以下設定：
        *   **Rendering** 設為 OpenGLES 或 Vulkan（Quest 3 兩者皆支援）。
        *   **Minimum API Level** 至少設為 29 (Android 10)。
        *   **Scripting Backend** 設為 **IL2CPP**。
        *   **Target Architectures** 包含 **ARM64**。
    *   在 **XR Plug-in Management** 中，確保在 Android 設定下勾選了 **Oculus**（或 Meta XR 提供者）。

5.  **在編輯器中遊玩（選擇性）**：
    *   如果你已透過 Link 或 Air Link 連接 Quest 3，可以直接點擊 Unity 編輯器中的「Play」按鈕進行測試。

## 🎥 示範影片 (即將推出)

遊戲玩法的示範影片準備好後會在此處提供連結。

## 📄 授權條款

此專案為開源專案，採用 repository 中的標準授權。詳細內容請參閱 `LICENSE` 檔案。

## 📬 聯絡我

此專案由 **LeoTheAuJai** 建立。歡迎透過 GitHub 與我聯繫。

---
```
