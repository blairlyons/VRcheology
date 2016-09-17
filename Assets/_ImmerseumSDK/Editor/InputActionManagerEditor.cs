using UnityEngine;
using UnityEditor;

namespace Immerseum {
    namespace VRSimulator {

        [CustomEditor(typeof(InputActionManager))]
        public class InputActionManagerEditor : Editor {
            SerializedProperty _createImmerseumDefaults;

            void OnEnable() {
                _createImmerseumDefaults = serializedObject.FindProperty("_createImmerseumDefaults");
            }

            public override void OnInspectorGUI() {
                serializedObject.Update();

                EditorGUIUtility.labelWidth = 160;

                GUIContent createImmerseumDefaultLabel = new GUIContent("Use Immerseum Defaults", "If true, creates Immerseum's default Input Actions using the default input mappings.");
                EditorGUILayout.PropertyField(_createImmerseumDefaults, createImmerseumDefaultLabel);
                if (_createImmerseumDefaults.boolValue == false) {
                    EditorGUILayout.HelpBox("BE CAREFUL! You have decided not to use Immerseum's default input actions. If you want to handle user input, be sure that you have either defined your own custom input actions and registered them with the InputActionManager or handling input outside of the Immerseum SDK.", MessageType.Warning);
                } else {
                    EditorGUILayout.HelpBox("You are using Immerseum's default Input Actions. These input actions will generate input events when the user does something with their input device, but how your VR scene responds to those inputs is configured elsewhere (either in the Movement Manager or in your code).", MessageType.Info);
                }

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
