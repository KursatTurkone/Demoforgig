using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseGenerator : MonoBehaviour
{
    public static CaseGenerator Instance { get; private set; }

    [SerializeField]
    Case caseTemplate;
    [SerializeField]
    CaseTypeListSO caseTypes;
    [SerializeField]
    CaseTypeSO commonCase;

    public int CaseAmount => caseAmount;
    public int CaseListCount => caseList.Count;

    int caseAmount;

    List<Case> caseList;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;

        SetCaseAmount();

        caseList = new List<Case>();

        caseTemplate.gameObject.SetActive(false);
        GenerateCases();
    }

    void SetCaseAmount()
    {
        for (int i = 0; i < caseTypes.CaseList.Count; i++)
            caseAmount += caseTypes.CaseList[i].Size;

        caseAmount += commonCase.Size;
    }

    void GenerateCases()
    {
        for (int i = 0; i < caseAmount; i++)
        {
            Case tmpCase = Instantiate(caseTemplate, transform);
            tmpCase.gameObject.SetActive(true);
            tmpCase.SetCaseType(commonCase);
            caseList.Add(tmpCase);
        }
    }

    public void RemoveItem(Case item)
    {
        caseList.Remove(item);

        if (caseList.Count == 3)
            FillLastThreeItem();
    }

    public void FillLastThreeItem()
    {
        for (int i = 0; i < caseTypes.CaseList.Count; i++)
        {
            for (int j = 0; j < caseTypes.CaseList[i].Size; j++)
            {
                caseList[0].SetCaseType(caseTypes.CaseList[i]);
                caseList.RemoveAt(0);
            }
        }
    }
}
