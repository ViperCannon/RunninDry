using UnityEngine;

public class EventStart : MonoBehaviour
{
    public GameManager gameManager;
    public void onClick()
    {
        gameManager.EndEncounter();

        RelationshipsFramework.Instance.cash += 20;
        gameManager.cash.text = RelationshipsFramework.Instance.cash.ToString();

        transform.parent.parent.gameObject.SetActive(false);
    }
}
