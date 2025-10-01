using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;

public class HowToPlayStatement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text HowToPlayText;

    public string tableName = "Table";
    public string entryKey = "HowToPlay_Hotseat";
    private LocalizedString localizedString;
    private bool onUI = false;

    private void Start()
    {
        localizedString = new LocalizedString(tableName, entryKey);
        localizedString.StringChanged += OnStringChanged;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onUI = true;
        HowToPlayText.text = localizedString.GetLocalizedString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onUI = false;
        HowToPlayText.text = "";
    }

    void OnStringChanged(string updatedText)
    {
        if (onUI)
            HowToPlayText.text = localizedString.GetLocalizedString();
    }
}
