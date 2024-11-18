using System.Collections.Generic;
using UnityEngine;

namespace SpeakeasyStreet
{
    public class Card : ScriptableObject
    {
        public string cardName;
        public int cost;
        public int drawAmount;
        [TextArea] 
        public string cardDescription;
        public List<ScriptableObject> cardEffects;
        public bool unlocked;
    }
}
