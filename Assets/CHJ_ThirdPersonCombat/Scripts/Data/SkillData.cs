using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class SkillData : PropertyAttribute
{
    public int Id;
    public string aniStateName;
    public float coolTime;
    public float damage;

#if UNITY_EDITOR
    public int selectedStateIndex = 0;
#endif
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SkillData))]
public class SkillDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var skillIdProp = property.FindPropertyRelative("Id");
        var aniStateNameProp = property.FindPropertyRelative("aniStateName");
        var coolTimeProp = property.FindPropertyRelative("coolTime");
        var damageProp = property.FindPropertyRelative("damage");

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), GUIContent.none);

        float padding = 2;
        float width = position.width / 4 - padding;

        Rect skillIdRect = new Rect(position.x, position.y, width, position.height);
        Rect aniStateNameRect = new Rect(skillIdRect.x + width + padding, position.y, width, position.height);
        Rect coolTimeRect = new Rect(aniStateNameRect.x + width + padding, position.y, width, position.height);
        Rect damageRect = new Rect(coolTimeRect.x + width + padding, position.y, width, position.height);

        EditorGUI.PropertyField(skillIdRect, skillIdProp, GUIContent.none);
        EditorGUI.PropertyField(aniStateNameRect, aniStateNameProp, GUIContent.none);
        EditorGUI.PropertyField(coolTimeRect, coolTimeProp, GUIContent.none);
        EditorGUI.PropertyField(damageRect, damageProp, GUIContent.none);

        EditorGUI.EndProperty();
    }
}
#endif