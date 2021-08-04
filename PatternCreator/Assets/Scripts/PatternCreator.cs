using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PatternCreator : MonoBehaviour
{
    public GameObject patternObject;
    public Transform spawnPoint;
    public Vector3 distance;
    public float amountOfRepeat;
    public string prefabName;

    [Header("Creation options")]
    public bool destroyFromScene;
    public bool createPrefab;
    public void CreatePattern()
    {
        GameObject tempParent = new GameObject();
        tempParent.name = prefabName;
        tempParent.transform.position = spawnPoint.position;

        GameObject[] objectList = new GameObject[(int)amountOfRepeat];
        for (int i = 0; i < amountOfRepeat; i++)
        {
            GameObject temp = Instantiate(patternObject);
            temp.transform.position = spawnPoint.transform.position + (distance * i);
            temp.transform.parent = tempParent.transform;
        }
        if (createPrefab)
        {
            string prefabPath = "Assets/"+ prefabName+".prefab";
            PrefabUtility.SaveAsPrefabAsset(tempParent, prefabPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        if (destroyFromScene)
        {
            DestroyImmediate(tempParent.gameObject);
        }
    }
}
