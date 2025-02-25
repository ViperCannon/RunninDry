using UnityEngine;

public class Continue : MonoBehaviour
{
    public GameManager gameManager;
    public void onClick()
    {
        gameManager.EndEncounter();

        transform.parent.parent.gameObject.SetActive(false);
    }
}