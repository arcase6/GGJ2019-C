using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Scriptable Objects/Variables/newFloat", menuName = "Variables/Float")]
public class FloatVariable : ScriptableObject,ISerializationCallbackReceiver {
    public float StartingValue;

    [NonSerialized]
    public float Value;

    public void OnAfterDeserialize()
    {
        Value = StartingValue;
    }
    
    public void OnBeforeSerialize()
    {

    }
}
