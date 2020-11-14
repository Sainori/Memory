using System;
using UnityEditor;
using UnityEngine;

namespace SaveManager
{
    [CustomEditor(typeof(SaveManager))]
    class SaveManagerInspector : Editor
    {
        private const string ResetButtonName = "Reset Score";
        private const string UpdateButtonName = "Update Score";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var saveManager = (SaveManager) target;
            if (GUILayout.Button(ResetButtonName))
            {
                saveManager.ResetScore();
            }

            if (GUILayout.Button(UpdateButtonName))
            {
                saveManager.UpdateMax();
            }
        }
    }
}