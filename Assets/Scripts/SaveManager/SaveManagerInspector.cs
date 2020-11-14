using UnityEditor;
using UnityEngine;

namespace SaveManager
{
    [CustomEditor(typeof(SaveManager))]
    class SaveManagerInspector : Editor
    {
        private const string ResetButtonName = "Reset Score";

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button(ResetButtonName))
            {
                ((SaveManager) target).ResetScore();
            }

            base.OnInspectorGUI();
        }
    }
}