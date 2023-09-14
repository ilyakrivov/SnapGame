using UnityEditor;
using UnityEngine;

public class AlexDHCorporation : Editor
{
    public static string ScripPath = $@"{Application.dataPath}\..\ClassTemplates\";

    [UnityEditor.MenuItem("Assets/Create/C# AlexDH Corporation", false, -1)]
    static void CreateClass (MenuCommand command)
    {      
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(ScripPath + "AlexDHCorporationTemplate.txt","AlexDHMonoBehaviour.cs");
    }
}
