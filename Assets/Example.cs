﻿//Create a folder (right click in the Assets directory, click Create>New Folder) and name it “Editor” if one doesn’t exist already.
//Place this script in that folder

//This script creates a new menu and a new menu item in the Editor window
// Use the new menu item to create a prefab at the given path. If a prefab already exists it asks if you want to replace it
//Click on a GameObject in your Hierarchy, then go to Examples>Create Prefab to see it in action.

using UnityEngine;
using UnityEditor;

public class Example : EditorWindow
{
    //Creates a new menu (Examples) with a menu item (Create Prefab)
    [MenuItem("Examples/Create Prefab")]
    static void CreatePrefab()
    {
        //Keep track of the currently selected GameObject(s)
        GameObject[] objectArray = Selection.gameObjects;

        //Loop through every GameObject in the array above
        foreach (GameObject gameObject in objectArray)
        {
            gameObject.hideFlags = HideFlags.None;
            
            //Set the path as within the Assets folder, and name it as the GameObject's name with the .prefab format
            string localPath = "Assets/" + gameObject.name + ".prefab";

            //Check if the Prefab and/or name already exists at the path
            if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
            {
                //Create dialog to ask if User is sure they want to overwrite existing prefab
                if (EditorUtility.DisplayDialog("Are you sure?",
                        "The prefab already exists. Do you want to overwrite it?",
                        "Yes",
                        "No"))
                //If the user presses the yes button, create the Prefab
                {
                    CreateNew(gameObject, localPath);
                }
            }
            //If the name doesn't exist, create the new Prefab
            else
            {
                Debug.Log(gameObject.name + " is not a prefab, will convert");
                CreateNew(gameObject, localPath);
            }
        }
        foreach (GameObject gameObject in objectArray)
        {
            gameObject.hideFlags = HideFlags.DontSave;
        }
    }

    // Disable the menu item if no selection is in place
    [MenuItem("Examples/Create Prefab", true)]
    static bool ValidateCreatePrefab()
    {
        return Selection.activeGameObject != null;
    }

    static void CreateNew(GameObject obj, string localPath)
    {
        //Create a new prefab at the path given
        Object prefab = PrefabUtility.CreatePrefab(localPath, obj);
        PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
    }
}
