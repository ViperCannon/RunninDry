using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckBuilderReciept : MonoBehaviour
{
    public static DeckBuilderReciept Instance { get; private set; }

    List<TextMeshProUGUI> CardList;
    List<TextMeshProUGUI> CardQuantities;

    void Start()
    {
        CardList = new List<TextMeshProUGUI>(); //TEMP JUST SO I CAN PUSH WITH NO COMPILATION ERRORS AND GO EAT DINNER
        CardQuantities = new List<TextMeshProUGUI>(); //TEMP JUST SO I CAN PUSH WITH NO COMPILATION ERRORS AND GO EAT DINNER
    }

    void Update()
    {
        
    }
}
