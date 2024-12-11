using UnityEngine;

public class EventStart : MonoBehaviour
{
    public GameManager gameManager;
    public void onClick()
    {
        gameManager.endEncounter();

        gameManager.relations.cash += 20;
        gameManager.cash.text = gameManager.relations.cash.ToString();

        transform.parent.parent.gameObject.SetActive(false);
    }
}
