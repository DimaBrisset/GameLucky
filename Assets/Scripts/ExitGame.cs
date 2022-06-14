#if UNITY_EDITOR
using UnityEngine;
#endif

using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    #region Variables

    public Button ExitButton;

    #endregion


    #region lifecycle

    private void Start()
    {
        ExitButton.onClick.AddListener(ExitButtonClicked);
    }

    #endregion


    #region Private Methods

    private void ExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    #endregion
}


