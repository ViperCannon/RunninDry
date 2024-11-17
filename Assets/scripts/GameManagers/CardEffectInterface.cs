using SpeakeasyStreet;

public interface CardEffectInterface
{
    void ResolveEffect(Card card, CharacterInstance target, int cost, CombatManager cManager);
}
