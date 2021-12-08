using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event System.Action OnCaseLimitFinished;

    int caseOpened;

    void Awake()
    {
        GetKeys.OnGetKeysButtonPressed += GetKeys_OnGetKeysButtonPressed;
        Keys.OnKeyAmountChanged += Keys_OnKeyAmountChanged;
    }

    void GetKeys_OnGetKeysButtonPressed()
    {
        Keys.OnKeyAmountChanged += Keys_OnKeyAmountChanged;
    }

    void Keys_OnKeyAmountChanged(Keys keys)
    {
        caseOpened++;
        keys.CurrentCase.OpenCase();
        CaseGenerator.Instance.RemoveItem(keys.CurrentCase);

        if (keys.KeyAmount <= 0)
        {
            Keys.OnKeyAmountChanged -= Keys_OnKeyAmountChanged;
            keys.OnKeyLimitFinishedFunc();
        }

        if (caseOpened == CaseGenerator.Instance.CaseAmount)
            OnCaseLimitFinished?.Invoke();
    }
}
