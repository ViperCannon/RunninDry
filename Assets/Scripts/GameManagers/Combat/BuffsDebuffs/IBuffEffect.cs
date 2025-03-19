public interface IBuffEffect
{
    void ResolveEffect(CombatCardDisplay cardInstance, CharacterInstance target);
    void ResolveEffect(CombatCard action, CharacterInstance target);
    void ResolveEffect(NegotiationCardDisplay cardInstance);
}