using TMPro;
using UnityEngine;

public class Statistic : MonoBehaviour
{
    #region Veriebals

    public TextMeshProUGUI _count;

    #endregion


    #region Life Cycle

    private void Start()
    {
        ShowCount();
    }

    #endregion


    #region Private Methods

    private void ShowCount()
    {
        _count.text =
            $"Steps:     {ScoreManager.Instance.CountStepsSingle}\n " +
            $"CorrectAnswer:     {ScoreManager.Instance.CountCorrectStepsSingle}\n " +
            $"NotCorrectAnswer:     {ScoreManager.Instance.CountWrongStepsSingle}";
    }

    #endregion
}



