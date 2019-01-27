using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Scriptable Objects/Variables/newInt", menuName = "Variables/Int")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver{

    public int StartingValue;

    [NonSerialized]
    public int Value;

    public void OnAfterDeserialize()
    {
        Value = StartingValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
