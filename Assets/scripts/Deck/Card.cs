using System.Collections.Generic;
using UnityEngine;

namespace SpeakeasyStreet
{
    public class Card : ScriptableObject
    {
        public string cardName;
        public Sprite cardArt;
        public int cost;
        public int drawAmount;
        [TextArea] 
        public string cardDescription;
        public List<ScriptableObject> cardEffects;
        public bool unlocked;

        public List<ICardEffect> GetCardEffects()
        {
            List<ICardEffect> effects = new List<ICardEffect>();
            foreach (var effect in cardEffects)
            {
                if (effect is ICardEffect cardEffect)
                {
                    effects.Add(cardEffect);
                }
            }
            return effects;
        }
    }
}
