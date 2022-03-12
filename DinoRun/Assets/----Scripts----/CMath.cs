using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

namespace CMath
{
    public interface IActivatable { public void Activate(); }
    public interface IDeActivatable { public void DeActivate(); }
    public interface IIncluded : IActivatable, IDeActivatable { private void SetActive(bool isActive) { } }

    #region RollbackVar
    [Serializable]
    public struct RollbackVar<T>
    {
        public T Current, Default;

        public RollbackVar(T value) => (Current, Default) = (value, value);
        public void Reset() => Current = Default;
    }
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RollbackVar<bool>))]
    [CustomPropertyDrawer(typeof(RollbackVar<int>))]
    [CustomPropertyDrawer(typeof(RollbackVar<float>))]
    [CustomPropertyDrawer(typeof(RollbackVar<string>))]
    public class RollbackVarDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            EditorGUI.PropertyField(new Rect(position.x, position.y, 50f, position.height),
                property.FindPropertyRelative("Default"), GUIContent.none);
            EditorGUI.PropertyField(new Rect(position.x + 55f, position.y, 120f, position.height),
                property.FindPropertyRelative("Current"), GUIContent.none);

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
#endif
    #endregion


    public class CMath : MonoBehaviour
    {
        
    }

    public static class CConvert
    {
        private const int _millisecondsPerSecond = 1000;

        public static float Seconds(int milliseconds) => milliseconds / _millisecondsPerSecond;
        public static int Milliseconds(float seconds) => Convert.ToInt32(seconds * _millisecondsPerSecond);
    }
    public class TagSelectorAttribute : PropertyAttribute
    {
        public bool UseDefaultTagFieldDrawer = false;
    }
    public static class CAnimationCurve
    {
        public static Keyframe GetFirstKey(this AnimationCurve curve) => curve.keys[0];
        public static Keyframe GetLastKey(this AnimationCurve curve) => curve.keys[curve.length - 1];
    }
    public static class CInvoke
    {
        public static void Invoke(this MonoBehaviour monoBehaviour, Action action, float time) => monoBehaviour.Invoke(action.Method.Name, time);
    }
    public static class CArray
    {
        public static List<T> Copy<T>(this IEnumerator enumerator)
        {
            List<T> array = new(1);
            enumerator.Reset();
            while (enumerator.MoveNext()) array.Add((T)enumerator.Current);
            return array;
        }
        public static List<T> Copy<T>(this IEnumerable enumerable) => Copy<T>(enumerable.GetEnumerator());
    }
    public class CEditor
    {
        public static void SetObjectDirty(GameObject @object)
        {
            EditorUtility.SetDirty(@object);
            EditorSceneManager.MarkSceneDirty(@object.scene);
        }
    }

    //    public class ShowIfActionAttribute : PropertyAttribute
    //    {

    //    }
    //#if UNITY_EDITOR
    //    [CustomPropertyDrawer(typeof(ShowIfActionAttribute))]
    //    public class ShowIfActionAttributeDrawer : PropertyDrawer
    //    {
    //        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    //        {

    //        }
    //    }
    //#endif
}
