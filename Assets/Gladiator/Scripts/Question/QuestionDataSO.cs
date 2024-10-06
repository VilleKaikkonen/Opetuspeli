using UnityEngine;

/*
 Author: Antti Sironen
This is a ScriptableObject that holds data for questions.
 */

[CreateAssetMenu(fileName = "newQuestionData", menuName = "ScriptableObjects/QuestionData", order = 1)]
public class QuestionDataSO : ScriptableObject
{
    [TextArea] public string questionText;

    public string[] answers; // three answers

    public int correctAnswerIndex; // index of the correct answer (0,1,2)
}
