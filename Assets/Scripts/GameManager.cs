using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Veriebals

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _questionLabel;
    [SerializeField] private TextMeshProUGUI _answerLabel1;
    [SerializeField] private TextMeshProUGUI _answerLabel2;
    [SerializeField] private TextMeshProUGUI _answerLabel3;
    [SerializeField] private TextMeshProUGUI _answerLabel4;

    [SerializeField] private Button _buttonA;
    [SerializeField] private Button _buttonB;
    [SerializeField] private Button _buttonC;
    [SerializeField] private Button _buttonD;
    [SerializeField] private Button _buttonPrompt;
    [SerializeField] private TextMeshProUGUI _statLabel;

    [Header("Initial Elements")]
    [SerializeField] private Step _startStep;

    [Header("External Components")]
    private Step _currentStep;
    private int _countSteps;
    private int _correctSteps;
    private int _notCorrectSteps;
    private int _life = 3;

    #endregion


    #region LifeCycle

    private void Start()
    {
        _buttonA.onClick.AddListener(ButtonOnClickA);
        _buttonB.onClick.AddListener(ButtonOnClickB);
        _buttonC.onClick.AddListener(ButtonOnClickC);
        _buttonD.onClick.AddListener(ButtonOnClickD);
        _buttonPrompt.onClick.AddListener(ButtonOnClickPrompt);
        SetCurrentStep(_startStep);
    }
    
    

    private void Update()
    {
        CountDecisionSingleTone();
        StatsList();
        GameOver();
    }
 
    #endregion


    #region Private Methods

    private void ButtonOnClickA()
    {
        ButtonOnShow();
        CheckAnswer(0);
        SetCurrentStep(0);
        CountDecisionSingleTone();
    }

    private void ButtonOnClickB()
    {
        ButtonOnShow();
        CheckAnswer(1);
        SetCurrentStep(1);
        CountDecisionSingleTone();
        CountDecision();
    }

    private void ButtonOnClickC()
    {
        ButtonOnShow();
        CheckAnswer(2);
        SetCurrentStep(2);
        CountDecisionSingleTone();
        CountDecision();
    }

    private void ButtonOnClickD()
    {
        ButtonOnShow();
        CheckAnswer(3);
        SetCurrentStep(3);
        CountDecisionSingleTone();
        CountDecision();
    }

    private void SetCurrentStep(Step step)
    {
        if (step == null)
            return;
        _currentStep = step;

        _questionLabel.text = step.QuestionLabel;
        _answerLabel1.text = step.Answer1;
        _answerLabel2.text = step.Answer2;
        _answerLabel3.text = step.Answer3;
        _answerLabel4.text = step.Answer4;
    }

    private void SetCurrentStep(int choiceIndex)
    {
        if (_currentStep.Choices.Length <= choiceIndex)
            return;
        Step nextStep = _currentStep.Choices[choiceIndex];
        SetCurrentStep(nextStep);
    }

    private void CountDecisionSingleTone()
    {
        ScoreManager.Instance.CountWrongStepsSingle = _notCorrectSteps;
        ScoreManager.Instance.CountCorrectStepsSingle = _correctSteps;
        ScoreManager.Instance.CountStepsSingle = _countSteps;
    }

    private void CountDecision()
    {
        _countSteps++;
    }

    private void StatsList()
    {
        _statLabel.text =
            $"Steps:{_countSteps} " +
            $"Life:{_life}," +
            $"Correct:{_correctSteps}, " +
            $"noCorrect:{_notCorrectSteps}";
    }

    private void CheckAnswer(int checkAnswer)
    {
        if (_currentStep.Check == checkAnswer)
            _correctSteps++;
        else
        {
            _notCorrectSteps++;
            _life--;
        }
    }

    private void GameOver()
    {
        if (_life == 0)
        {
            SceneManager.LoadScene("ExitScene");
        }
    }

    private void ButtonOnShow()
    {
        _buttonA.gameObject.SetActive(true);
        _buttonB.gameObject.SetActive(true);
        _buttonC.gameObject.SetActive(true);
        _buttonD.gameObject.SetActive(true);
        _buttonPrompt.gameObject.SetActive(true);
    }

    private void ButtonOnClickPrompt()
    {
        _buttonPrompt.gameObject.SetActive(false);
        switch (_currentStep.Check!)
        {
            case 0:
                _buttonB.gameObject.SetActive(false);
                _buttonC.gameObject.SetActive(false);
                break;
            case 1:
                _buttonC.gameObject.SetActive(false);
                _buttonD.gameObject.SetActive(false);
                break;
            case 2:
                _buttonD.gameObject.SetActive(false);
                _buttonA.gameObject.SetActive(false);
                break;
            case 3:
                _buttonA.gameObject.SetActive(false);
                _buttonB.gameObject.SetActive(false);
                break;
        }
    }

    #endregion
}