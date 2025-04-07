 :closed_lock_with_key: Google Sign-In Integration for Unity (Android)
This guide walks you through integrating **Google Sign-In** into your Unity Android project using the official SDK and Google Cloud Console.
---
## :white_check_mark: Step 1: Unity Project Setup
1. Create a **new Unity project**.
2. Switch platform to **Android**:
   - `File → Build Settings → Android → Switch Platform`
---
## :art: Step 2: UI Setup in Scene
### :jigsaw: Panels
- Create two panels in your scene:
  - `LoginPanel`
  - `ProfilePanel`
### :arrow_down_small: Inside LoginPanel:
- `Title` (Text for Login)
- `Profile Image` (Google icon)
- `Login Button`
### :arrow_up_small: Inside ProfilePanel:
- `Title` (Text for Profile)
- `Full Name & Email` (TextMeshPro Texts)
- `Logout Button`
- `Profile Image` (User profile picture)
---
## :package: Step 3: Script Setup
1. Create an **empty GameObject** and name it `GoogleAuthentication`.
2. Create a script also named `GoogleAuthentication` and attach it to the GameObject.
3. Download and use the script from the link below:
:link: [GoogleAuthentication.cs Script](https://pastebin.com/raw/RNcQuBwW)
*(Replace with your actual Pastebin/Gist/Repo link if different)*
---
## :inbox_tray: Step 4: Download SDKs
### :link: Google Sign-In SDK
- Download from:
  [https://github.com/googlesamples/google-signin-unity/releases](https://github.com/googlesamples/google-signin-unity/releases)
- Import this package:
  `google-signin-plugin-1.0.4.unitypackage`
---
## :hammer_and_wrench: Step 5: Fix Import Errors
1. Go to:
   `Assets → Parse → Unity.Compat` and `Unity.Tasks`
   - Uncheck all checkboxes and click **Apply**.
2. Delete the **PlayServicesResolver** folder from `Assets`.
---
## :file_folder: Step 6: External Dependency Manager
- Download and import:
  [External Dependency Manager (v1.2.181)](https://teal-kat-32.tiiny.site/)
---
## :cloud: Step 7: Setup Google Cloud Console
> Follow these steps on [https://console.cloud.google.com](https://console.cloud.google.com)
1. **Create New Project**
2. **Configure OAuth Consent Screen**
   - Choose **External**
   - Enter your App Name and Email
   - Accept terms and create
3. **Add Scopes**
   - Add recommended scopes shown in screenshot (email, profile, openid)
4. **Add Test Users**
   - Add your own email
5. **Create OAuth Client ID**
   - Type: **Android**
   - Enter:
     - **App Name**
     - **Package Name**
     - **SHA-1 Key**
### :key: Get SHA-1 Key:
1. Open CMD and navigate to Java's `bin` folder.
2. Run:
   ```bash
   keytool -list -v -keystore <your-keystore-path>
GitHubGitHub
GitHub - googlesamples/unity-jar-resolver: Unity plugin which resolves Android & iOS dependencies and performs version management
Unity plugin which resolves Android & iOS dependencies and performs version management - googlesamples/unity-jar-resolver (56 kB)
https://github.com/googlesamples/unity-jar-resolver

accounts.google.comaccounts.google.com
Google Cloud Platform
Google Cloud Platform lets you build, deploy, and scale applications, websites, and services on the same infrastructure as Google.
