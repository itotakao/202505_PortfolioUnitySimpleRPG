/**
 *  FileName    :   SceneTypeGenerator.cs
 *  Description :   ビルド設定に置かれたSceneを元にEnumを作成するScript
 *
 *  Copyright 2023 H.Nakata. All rights reserved.
 */

using System.Collections.Generic;
using System.IO;
using System.Text;

using UnityEngine;
using UnityEditor;

namespace NasanUtility.Editor.SceneTypeGenerator
{

    public class SceneTypeGenerator : MonoBehaviour
    {
        /// <summary> ESceneType生成 </summary>
        [InitializeOnLoadMethod]
        static void SceneTypeGenerate()
        {
            EditorBuildSettings.sceneListChanged += () =>
            {
                // コード生成
                List<string> writeCodes = new List<string>();
                writeCodes.Add("// SceneTypeGenerator.csで生成\n");
                writeCodes.Add("[System.Serializable]");
                writeCodes.Add("public enum ESceneType");
                writeCodes.Add("{");
                writeCodes.Add("\tNone = -1,");

                // シーン一覧からシーン名と状態を取得
                foreach (var scene in EditorBuildSettings.scenes)
                {
                    string sceneName = scene.path;
                    sceneName = sceneName.Remove(0, sceneName.LastIndexOf("/") + 1).Replace(".unity", "").Replace(" ", "_");
                    writeCodes.Add("\t" + sceneName + ",");
                }

                writeCodes.Add("}");

                // 生成
                string filePath = Application.dataPath + "/_Application/Scripts/Enum/ESceneType.cs";
                FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(stream, Encoding.UTF8);
                sw.Write("");
                foreach (var code in writeCodes)
                {
                    sw.WriteLine(code);
                }

                sw.Close();

                AssetDatabase.Refresh();
                Debug.Log("シーンリスト更新終了");
            };
        }

    }

}