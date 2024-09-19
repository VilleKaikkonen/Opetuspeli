using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance { get; private set; } // Singleton


    public QuestionDataSO[] questions; // List of all questions
    public TMP_Text questionText; // UI element for displaying the question
    public Button[] answerButtons; // Buttons for player to answer

    private int currentQuestionIndex = 0; //Which question is currently being asked


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("More than one instance of QuestionManager found!" + Instance + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        //DisplayQuestion();
    }

    private void OnEnable()
    {
        DisplayQuestion();
    }


    //Show question and set answers to buttons
    void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            QuestionDataSO currentQuestion = questions[currentQuestionIndex];

            questionText.text = currentQuestion.questionText;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];
                int index = i; // Local copy of i for lambda
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
            }
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }

    //Check if the player's chosen answer was correct
    public void CheckAnswer(int chosenIndex)
    {
        QuestionDataSO currentQuestion = questions[currentQuestionIndex];

        if (chosenIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Right answer!");
        }
        else
        {
            Debug.Log("Wrong answer!");
        }

        currentQuestionIndex++;
        DisplayQuestion();
    }
}
