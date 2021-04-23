using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MainDatabase))]
public class DataBaseExpansion : Editor
{

    public string nameAdd = "";
    public string count = "";
    public Font font;
    public GUIStyle style;
    public GUISkin skin;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MainDatabase database = (MainDatabase)target;
        style = database.style;
        font = Resources.Load<Font>("Fonts/joystix monospace");

        if (GUILayout.Button("Add item"))
        {

            database.AddItem(new Item());

        }

        GUILayout.Space(40);
        GUILayout.BeginVertical("Box", style);
        

        GUILayout.Label("Match item", style);

        if (GUILayout.Button("Add count"))
        {
            if (nameAdd != "" && count != "")
                database.AddCount(nameAdd, Convert.ToInt32(count));
        }
        if (GUILayout.Button("Remove count"))
        {
            if (nameAdd != "" && count != "")
                database.RemoveCount(nameAdd, Convert.ToInt32(count));
        }
        if (GUILayout.Button("Craft"))
        {
            if (nameAdd != "")
                database.Craft(nameAdd);
        }

        nameAdd = GUILayout.TextField(nameAdd, 25);
        count = GUILayout.TextField(count, 25);

        GUILayout.EndVertical();

    }

}
