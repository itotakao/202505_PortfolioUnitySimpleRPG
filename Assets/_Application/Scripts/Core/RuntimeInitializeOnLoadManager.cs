using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuntimeInitializeOnLoadManager
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void BeforeSceneLoad()
    {
        Debug.Log("BeforeSceneLoad");
        SceneManager.sceneLoaded += LoadCoreScene;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void AfterSceneLoad() => Debug.Log("AfterSceneLoad");

    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    //static void AfterAssembliesLoaded() => Debug.Log("AfterAssembliesLoaded");

    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    //static void BeforeSplashScreen() => Debug.Log("BeforeSplashScreen");

    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    //static void SubsystemRegistration() => Debug.Log("SubsystemRegistration");

    private static void LoadCoreScene(UnityEngine.SceneManagement.Scene arg0, LoadSceneMode arg1)
    {
        // 全てのシーンに配置するためのCoreSceneを配置する
        var coreSystemSceneName = ESceneType.CoreSystem.ToString();

        //読み込まれているシーンを取得
        bool isExists = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            string sceneName = SceneManager.GetSceneAt(i).name;
            Debug.Log(sceneName);
            if (sceneName == coreSystemSceneName)
            {
                isExists = true;
            }
        }

        if (isExists)
        {
            return;
        }

        SceneManager.LoadScene("CoreSystem", LoadSceneMode.Additive);
    }
}