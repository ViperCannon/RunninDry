using UnityEngine;

[CreateAssetMenu(fileName = "New GenericDrawEffect", menuName = "GenericDrawEffect")]
public class GenericDrawEffect : ScriptableObject, ICardEffect
{
    public void ResolveEffect(CardDisplay cardInstance, CharacterInstance target, CombatManager cManager)
    {
        Effect((CombatCardDisplay)cardInstance, target, cManager);
    }

    public void Effect(CombatCardDisplay card, CharacterInstance target, CombatManager cManager)
    {
        if (card.cardData.subTypes.Contains(CombatCard.CombatSubType.Unload)) //unload (X-cost) cards
        {
            cManager.handManager.AttemptDraw(card.unload);
        }
        else //draw specified by card
        {
            cManager.handManager.AttemptDraw(card.cardData.drawAmount);
        }
    }
}
