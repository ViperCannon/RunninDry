using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeakeasyStreet
{
    public class CardEffectResolver : MonoBehaviour
    {
        CombatManager cManager;

        void Start()
        {
            cManager = GetComponent<CombatManager>();
        }

        public void ResolveCardEffects(CardDisplay cardInstance, CharacterInstance target)
        {

        }
    }
}
