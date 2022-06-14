using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Configs/Steps")]
public class Step : ScriptableObject
{
    #region Public Field

    [TextArea(1, 2)]
    public string QuestionLabel;

    [TextArea(1, 2)]
    public string Answer1;

    [TextArea(1, 2)]
    public string Answer2;

    [TextArea(1, 2)]
    public string Answer3;

    [TextArea(1, 2)]
    public string Answer4;
    public int Check;

    public Step[] Choices;

    #endregion
}



