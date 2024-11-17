using UnityEditor;
using SpeakeasyStreet;

[CustomEditor(typeof(Card))]
public class CardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Card card = (Card)target;

        // If cardEffects is empty, show a warning message
        if (card.cardEffects.Count == 0)
        {
            EditorGUILayout.HelpBox("No card effects added.", MessageType.Warning);
        }

        // Loop through and display the individual card effects
        foreach (var effect in card.cardEffects)
        {
            if (effect != null)
            {
                // Display each effect in your own way here
                EditorGUILayout.ObjectField(effect, typeof(CardEffectInterface), false);
            }
        }
    }
}
