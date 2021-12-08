using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Case : MonoBehaviour
{
    public static event System.Action<Case> OnCaseButtonClicked;

    [SerializeField]
    Image caseSprite;
    [SerializeField]
    TextMeshProUGUI goldAmountText;
    [SerializeField]
    Image goldIcon;
    [SerializeField]
    Sprite caseOpened;

    Button button;

    CaseTypeSO caseType;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        OnCaseButtonClicked?.Invoke(this);
    }

    public void OpenCase()
    {
        button.enabled = false;
        caseSprite.sprite = caseOpened;
        goldIcon.gameObject.SetActive(true);
        goldAmountText.gameObject.SetActive(true);
        goldAmountText.SetText(caseType.GoldAmount.ToString());
        goldAmountText.text = "1000"; 
    }

    public void SetCaseType(CaseTypeSO caseType)
    {
        this.caseType = caseType;
    }
}
