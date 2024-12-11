using UnityEngine;

public class Continue : MonoBehaviour
{
    public GameManager gameManager;
    public void onClick()
    {
        gameManager.endEncounter();

        transform.parent.parent.gameObject.SetActive(false);
    }
}