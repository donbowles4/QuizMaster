using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int intCorrectAnswerIndex;
    bool blnHasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
      // DisplayQuestion();
    }

    void Update() 
    {
        timerImage.fillAmount = timer.fltFillFraction;
        if(timer.blnLoadNextQuestion)
        {
            blnHasAnsweredEarly = false;
            GetNextQuestion();
            timer.blnLoadNextQuestion = false;
        }
        else if(!blnHasAnsweredEarly && !timer.blnIsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        blnHasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if(index == question.intGetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else   
        {
           intCorrectAnswerIndex = question.intGetCorrectAnswerIndex();
           string correctAnswer = question.strGetAnswer(intCorrectAnswerIndex);
           questionText.text = "Sorry, the correct answer was;\n" + correctAnswer;
           buttonImage = answerButtons[intCorrectAnswerIndex].GetComponent<Image>();
           buttonImage.sprite = correctAnswerSprite;
        }
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
         questionText.text = question.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.strGetAnswer(i);
        }
    }

void SetButtonState(bool state)
{
    for(int i = 0; i < answerButtons.Length; i++)
    {
        Button button = answerButtons[i].GetComponent<Button>();
        button.interactable = state;
    }
}
    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

}
