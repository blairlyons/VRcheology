using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Parser
{
    [MenuItem("Data/ParseDig")]
    static void ParseDig ()
    {
        string textData = GetTextData();
        if (!string.IsNullOrEmpty(textData))
        {
            JObject data = JObject.Parse(textData);

            Debug.Log(data["1"]);
            //new Feature(new Vector3(0, 5, 2), FeatureType.Pottery, null);


        }
    }

    static string GetTextData ()
    {
        string filepath = EditorUtility.OpenFilePanel("Select JSON data", "Assets/Data", "txt");
        filepath = filepath.Substring(filepath.IndexOf("Assets"));

        TextAsset data = (TextAsset)AssetDatabase.LoadAssetAtPath(filepath, typeof(TextAsset));
        if (data != null)
        {
            return data.text;
        }
        Debug.LogWarning("JSON data was not imported");
        return "";
    }
}
