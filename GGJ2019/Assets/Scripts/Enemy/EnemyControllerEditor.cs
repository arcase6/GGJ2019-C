using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyController))]
public class EnemyControllerEditor : Editor
{
    protected virtual void OnSceneGUI()
    {
        EnemyController enemy = (EnemyController)target;

        EditorGUI.BeginChangeCheck();
        Vector3 handleOnePosition = Handles.PositionHandle(enemy.PatrolPoint1, Quaternion.identity);
        Vector3 handleTwoPosition = Handles.PositionHandle(enemy.PatrolPoint2, Quaternion.identity);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(enemy, "Change Look At Target Position");
            enemy.PatrolPoint1 = handleOnePosition;
            enemy.PatrolPoint2 = handleTwoPosition;

        }
    }


}
