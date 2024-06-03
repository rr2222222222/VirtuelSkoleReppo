using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MultipleChoice))]
public class MultipleChoiceEditor : Editor
{
    private SerializedProperty questionToShow;
    private string buttonText = "Enable advanced settings?";

    private void OnEnable()
    {
        questionToShow = serializedObject.FindProperty("question");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        #region Answer possibilites
        GUI.color = Color.yellow;
        EditorGUILayout.LabelField("What happens after you click the wrong answer?", EditorStyles.boldLabel);
        GUI.color = Color.white;

        EditorGUILayout.Space(5);

        #region Descriptive text
        GUI.color = Color.cyan;
        EditorGUILayout.LabelField("Remember not to enable more than one of these elements, or it");
        EditorGUILayout.Space(-8);
        EditorGUILayout.LabelField("might mess up your MultipleChoices script...");
        GUI.color = Color.white;
        #endregion

        EditorGUILayout.Space(5);

        EditorGUIUtility.labelWidth = 180;
        MultipleChoice multipleChoice = (MultipleChoice)target;
        multipleChoice.tryAgain = EditorGUILayout.Toggle("Try the question again.", multipleChoice.tryAgain);
        multipleChoice.startAgain = EditorGUILayout.Toggle("Start over from the beginning.", multipleChoice.startAgain);
        multipleChoice.goBack = EditorGUILayout.Toggle("Go back one question.", multipleChoice.goBack);
        EditorGUIUtility.labelWidth = 0;

        EditorGUILayout.Space(15);
        #endregion

        #region Questions
        GUI.color = Color.yellow;
        EditorGUILayout.LabelField("Questions", EditorStyles.boldLabel);
        GUI.color = Color.white;

        EditorGUILayout.Space(5);

        EditorGUILayout.PropertyField(questionToShow);

        EditorGUILayout.Space(15);
        #endregion

        #region Advanced Settings
        if (multipleChoice.advancedSettings)
        {
            GUI.color = Color.yellow;
            EditorGUILayout.LabelField("Advanced variables", EditorStyles.boldLabel);
            GUI.color = Color.white;

            EditorGUILayout.Space(5);

            EditorGUIUtility.labelWidth = 215;
            multipleChoice.movable = EditorGUILayout.Toggle("Is object movable?", multipleChoice.movable);
            multipleChoice.changeViewModel = EditorGUILayout.Toggle("Change viewmodel when activating.", multipleChoice.changeViewModel);
            EditorGUIUtility.labelWidth = 0;

            if (multipleChoice.changeViewModel)
                multipleChoice.cam = EditorGUILayout.ObjectField("Camera viewmodel.", multipleChoice.cam, typeof(MultipleChoice)) as GameObject;
        }

        EditorGUILayout.Space(15);

        if (multipleChoice.advancedSettings)
            buttonText = "Disable advanced settings";
        else
            buttonText = "Enable advanced settings";

        if (GUILayout.Button(buttonText))
        {
            if (multipleChoice.advancedSettings)
            {
                multipleChoice.advancedSettings = false;
                multipleChoice.changeViewModel = false;
                multipleChoice.movable = false;
            }
            else
                multipleChoice.advancedSettings = true;
        }
        #endregion

        serializedObject.ApplyModifiedProperties();
    }
}
