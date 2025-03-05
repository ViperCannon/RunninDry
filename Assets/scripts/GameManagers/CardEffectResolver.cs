using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeakeasyStreet
{
    public class CardEffectResolver : MonoBehaviour
    {
        public static CardEffectResolver Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void ResolveCardEffects(CardDisplay cardInstance, CharacterInstance target)
        {
            if (cardInstance is CombatCardDisplay)
            {
                CombatCardDisplay card = (CombatCardDisplay)cardInstance;

                foreach (ICardEffect effect in card.cardData.GetCardEffects())
                {
                    effect.ResolveEffect(card, target);
                }
            }
            else
            {

                NegotiationCardDisplay card = (NegotiationCardDisplay)cardInstance;

                Debug.Log(card.cardData.GetCardEffects().Count);



                foreach (ICardEffect effect in card.cardData.GetCardEffects())
                {
                    Debug.Log("resolving");
                    effect.ResolveEffect(card);
                }
            }


        }

        public void ResolveEnemyEffect(CombatCard action, CharacterInstance target)
        {
            foreach (IEnemyEffect effect in action.GetEnemyEffects())
            {
                Debug.Log("Enemy attack processing");
                effect.ResolveEffect(action, target);
            }
        }
    }
}
