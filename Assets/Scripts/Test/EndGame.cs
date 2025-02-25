using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameManager gameManager;
    public void onClick()
    {
        gameManager.LoadMainMenu();
    }
}
