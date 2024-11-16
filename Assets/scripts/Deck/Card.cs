using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeakeasyStreet
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public string character;
        public CardType cardType;
        public int cost;
        public int damage;
        public int numberOfDice;
        public int sidedDice;
        public int diceModifier;
        public string cardDescription;
        public List<SubType> subTypes;
        public List<CardTarget> validTargets;
        public bool unlocked;

        public enum CardType
        {
            Negotiation,
            Combat
        }

        public enum SubType
        {
            Projectile,
            Melee,
            Diplomacy,
            Intimidation,
            Bribery,
            Buff,
            Debuff,
            Heal,
            Unload //X cost cards that use up the remaining of the player's CAPs
        }

        public enum CardTarget
        {
            Self, 
            Random,
            Enemy, //Any enemy except for the case of an enemy using an ability. The active enemy is excluded as a target in that case.
            Player, //Any ally excluding the ally whose card is being played
            AOE, //card does same effect (before accounting for buffs or debuffs) to either all characters, all enemies, or both
            Generic //card doesnt target an enemy or character. Typically deck/hand manipulation cards
        }
    }
}
