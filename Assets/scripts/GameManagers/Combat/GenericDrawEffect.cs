using UnityEngine;
using SpeakeasyStreet;

[CreateAssetMenu(fileName = "New GenericDrawEffect", menuName = "GenericDrawEffect")]
public class GenericDrawEffect : ScriptableObject, CardEffectInterface
{
    public void ResolveEffect(Card card, CharacterInstance target, int cost, CombatManager cManager)
    {
        if(cost > 0) //unload (X-cost) cards
        {
            cManager.handManager.AttemptDraw(cost);
        }
        else if(card.drawAmount > 0) //draw specified by card
        {
            cManager.handManager.AttemptDraw(card.drawAmount);
        }
    }
}
