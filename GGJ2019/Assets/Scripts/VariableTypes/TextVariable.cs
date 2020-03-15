using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Scriptable Objects/Variables/newText", menuName = "Variables/Text")]
public class TextVariable : ScriptableObject {
    [SerializeField]
    private string value;

    public string Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
        }
    }
}
