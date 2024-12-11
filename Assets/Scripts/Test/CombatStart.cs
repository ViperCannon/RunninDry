using UnityEngine;
using SpeakeasyStreet;

public class CombatStart : MonoBehaviour
{
    public GameObject cManager;
    public Canvas combatCanvas;

    public GameObject[] combats;

    public void onClick()
    {
        combats[TutorialManager.combatAmount].SetActive(true);
        TutorialManager.combatAmount++;

        cManager.SetActive(true);

        combatCanvas.transform.GetChild(0).gameObject.SetActive(true);

        transform.parent.parent.gameObject.SetActive(false);
    }
}
