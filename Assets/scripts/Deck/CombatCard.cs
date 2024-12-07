using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New CombatCard", menuName = "CombatCard")]
public class CombatCard : Card
{
    public PlayableCharacter character;
    public int damage;
    public int secondaryDamage;
    public int selfDamage;
    public int heal;
    public int secondaryHeal;
    public int turnDuration; //for applied effects
    public int chanceEffect; //chance for applied effects (do not use for blind)
    public List<CombatSubType> subTypes;
    public List<CardTarget> validTargets;

    public enum PlayableCharacter
    {
        Pixie,
        Baldwin,
        Barley
    }

    public enum CombatSubType
    {
        Projectile,
        Melee,
        Buff,
        Debuff,
        Heal,
        Unload, //X cost cards that use up the remaining of the player's CAPs
        Draw
    }

    public enum CardTarget
    {
        Self,
        Random,
        Enemy, //Any enemy except for the case of an enemy using an ability. The active enemy is excluded as a target in that case.
        Player, //Any ally excluding the ally whose card is being played
        AllEnemies,
        AllPlayers,
        AllCharacters,
        Generic //card doesnt target an enemy or character. Typically deck/hand manipulation cards
    }

    public bool IsAOE()
    {
        if (validTargets.Contains(CombatCard.CardTarget.AllEnemies) || validTargets.Contains(CombatCard.CardTarget.AllPlayers) || validTargets.Contains(CombatCard.CardTarget.AllCharacters))
        {
            return true;
        }

        return false;
    }

    public bool IsSelfInclusive()
    {
        if (validTargets.Contains(CombatCard.CardTarget.Player) && validTargets.Contains(CombatCard.CardTarget.Self))
        {
            return true;
        }

        return false;
    }
}
