using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

namespace CMath
{
    public interface IActivatable { public void Activate(); }
    public interface IDeActivatable { public void DeActivate(); }
    public interface IIncluded : IActivatable, IDeActivatable { private void SetActive(bool isActive) { } }

    [Serializable]
    public struct RollbackVar<T>
    {
        public T Current, Default;

        public RollbackVar(T value) => (Current, Default) = (value, value);
        public void Reset() => Current = Default;
    }


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
