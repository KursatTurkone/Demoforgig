using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetKeys : MonoBehaviour
{
    public static event System.Action OnGetKeysButtonPressed;

    Button button;
    void Awake()
    {

        Keys.OnKeyLimitFinished += Keys_OnKeyLimitFinished;
        GameManager.OnCaseLimitFinished += GameManager_OnCaseLimitFinished;
        gameObject.SetActive(false);
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);

    }
    void GameManager_OnCaseLimitFinished()
    {
        gameObject.SetActive(false);
    }

    void Keys_OnKeyLimitFinished()
    {
        gameObject.SetActive(true);
    }
    void ButtonClicked()
    {
        OnGetKeysButtonPressed?.Invoke();
        gameObject.SetActive(false);
    }
}
