using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MapEditor
{

    [MenuItem("CustomMenu/MapEditors")]
    static void MapEditors()
    {
        Sprite[] sprite = Resources.LoadAll<Sprite>("Mapdata");
        GameObject parents = GameObject.Find("Stage");
        GameObject tilePrefab = Resources.Load<GameObject>("Prefab/Map");
        GameObject tilePrefab1 = Resources.Load<GameObject>("Prefab/Map1");
        GameObject tilePrefab2 = Resources.Load<GameObject>("Prefab/Map3");
        GameObject tilePrefab3 = Resources.Load<GameObject>("Prefab/Map4");

        TextAsset csvFile;
        csvFile = Resources.Load("CSV/stage") as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(csvFile.text);
        int y = 0;
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] lines=line.Split(','); // リストに入れる
            for(int i = 0; i < lines.Length; i++)
            {
                
                int a = int.Parse(lines[i]);
                if (a >= 0) { 
                        GameObject tile = null;

                        if (a == 0 || (a >= 7 && a <= 9) || (a >= 12 && a <= 14) || a == 17 || a == 19 || a==20||a==21||a == 22)
                            tile = UnityEditor.PrefabUtility.InstantiatePrefab(tilePrefab1) as GameObject;
                        else if (a == 15)
                            tile = UnityEditor.PrefabUtility.InstantiatePrefab(tilePrefab2) as GameObject;
                        else if (a == 16)
                            tile = UnityEditor.PrefabUtility.InstantiatePrefab(tilePrefab3) as GameObject;
                        else tile = UnityEditor.PrefabUtility.InstantiatePrefab(tilePrefab) as GameObject;
                        SpriteRenderer sp = tile.GetComponent<SpriteRenderer>();
                        sp.sprite = sprite[a];
                        tile.transform.parent = parents.transform;
                        tile.transform.localPosition = new Vector2(i, -y);
                    if (a == 22) tile.tag = "Floor";
                    tile.isStatic = true;

                    
                }
            }
            y++;
        }
    }
}
