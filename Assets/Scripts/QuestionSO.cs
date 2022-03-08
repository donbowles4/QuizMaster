using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "NewQuestion")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string strQuestion = "Enter new question text here";
    [SerializeField] string[] strAnswers = new string[4];
    [SerializeField] int intCorrectAnswerIndex;
    public string GetQuestion()
    {
        return strQuestion;
    }
    public string strGetAnswer(int index)
    {
        return strAnswers[index];
    }
    public int intGetCorrectAnswerIndex()
    {
        return intCorrectAnswerIndex;
    }
}
