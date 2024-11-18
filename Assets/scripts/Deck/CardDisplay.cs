using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SpeakeasyStreet;

public abstract class CardDisplay : MonoBehaviour
{
    public Card cardData;

    public Image cardImage;
    public Image[] characterFlair;

    public TMP_Text nameText;
    public TMP_Text descText;

    public void UpdateCardDisplay()
    {

    }
}
