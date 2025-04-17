using UnityEngine;
using TMPro;

public class BuffDebuffUI : MonoBehaviour
{
    public TMP_Text turnText;

    public void SetTurns(int turns)
    {
        if(turnText != null)
        {
            turnText.text = turns.ToString();
        }
    }
}
