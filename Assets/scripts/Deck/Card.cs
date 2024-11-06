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
        public List<SubType> subTypes;
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
            Heal
        }
    }
}
