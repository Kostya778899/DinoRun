using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

namespace CMath
{
    public class CMath : MonoBehaviour
    {
        
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
}
