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
        public DamageType damageType;
        public bool starter;

        public enum CardType
        {
            Negotiation,
            Combat
        }

        public enum DamageType
        {
            Projectile,
            Melee,
            Diplomacy,
            Intimidation,
            Bribery
        }
    }
}
