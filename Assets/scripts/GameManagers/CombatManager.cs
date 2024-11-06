using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeakeasyStreet;

public class CombatManager : MonoBehaviour
{
    public enum CombatPhase
    {
        PlayerTurn,
        EnemyTurn
    }

    [SerializeField]
    CombatPhase currentPhase;
    [SerializeField]
    HandManager handManager;
    [SerializeField]
    DeckManager deckManager;
    [SerializeField]
    GameManager gameManager;

    bool hasEndedTurn = false;

    public List<AllyInstance> players;
    public List<EnemyInstance> enemies;

    int capsRefreshLimit;
    public int currentCaps;

    // Method to start combat and initialize variables
    public void Start()
    {
        currentPhase = CombatPhase.PlayerTurn;

        capsRefreshLimit = 0;

        foreach(AllyInstance p in players)
        {
            capsRefreshLimit += p.caps;
        }

        StartCoroutine(HandleCombatTurns());
    }

    // Method to handle the turn-based combat flow
    IEnumerator HandleCombatTurns()
    {
        while (!IsCombatOver())
        {
            if (currentPhase == CombatPhase.PlayerTurn)
            {
                // Wait for the player(s) to finish their turn
                yield return StartCoroutine(HandlePlayerTurn());

                // Transition to enemy turn
                currentPhase = CombatPhase.EnemyTurn;
            }
            else if (currentPhase == CombatPhase.EnemyTurn)
            {
                // Handle enemies' turn actions
                yield return StartCoroutine(HandleEnemyTurn());

                // Transition back to player turn
                currentPhase = CombatPhase.PlayerTurn;
            }
        }

        EndCombat();
    }

    // Method to handle player turns
    IEnumerator HandlePlayerTurn()
    {
        hasEndedTurn = false;

        currentCaps = capsRefreshLimit;

        // Handle player actions (drawing cards, playing cards, etc.)
        handManager.AttemptDraw(6);

        while (!hasEndedTurn)
        {
            // Wait until the player decides to end their turn
            yield return null;
        }

        handManager.DiscardHand();
    }

    // Method to handle enemy turns
    IEnumerator HandleEnemyTurn()
    {
        foreach (var enemy in enemies)
        {
            enemy.PerformAction(); // Let each enemy perform its action
            yield return new WaitForSeconds(1f); // Wait for a short period between actions
        }
    }

    public void EndTurn()
    {
        hasEndedTurn = true;
    }

    bool IsCombatOver()
    {
        // Check if the game has ended (all enemies defeated or all players dead)
        return players.Exists(p => p.currentHealth <= 0) || enemies.Exists(e => e.currentHealth <= 0);
    }

    void EndCombat()
    {
        // Handle the end of combat (e.g., show results, transition to the next scene, etc.)
    }
}
