using System;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    [SerializeField]
    Sprite goldenKey, darkKey;

    public static event Action<Keys> OnKeyAmountChanged;
    public static event Action OnKeyLimitFinished;

    int keyAmount;
    Case currentCase;
    bool isFinished;

    public int KeyAmount => keyAmount;
    public Case CurrentCase => currentCase;

    void Awake()
    {
        keyAmount = transform.childCount;
        Case.OnCaseButtonClicked += Case_OnCaseButtonClicked;
        GetKeys.OnGetKeysButtonPressed += GetKeys_OnGetKeysButtonPressed;
    }

    void GetKeys_OnGetKeysButtonPressed()
    {
        keyAmount = transform.childCount;
        isFinished = false;
        for (int i = 0; i < keyAmount; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = goldenKey;
        }
    }

    void Case_OnCaseButtonClicked(Case caseItem)
    {
        if (!isFinished)
            transform.GetChild(keyAmount - 1).GetComponent<Image>().sprite = darkKey;

        currentCase = caseItem;
        keyAmount--;
        OnKeyAmountChanged?.Invoke(this);
    }

    public void OnKeyLimitFinishedFunc()
    {
        OnKeyLimitFinished?.Invoke();
        isFinished = true;
    }
}
