using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/CaseTypeList",fileName ="CaseTypeList")]
public class CaseTypeListSO : ScriptableObject
{
    [SerializeField]
    List<CaseTypeSO> caseList;

    public List<CaseTypeSO> CaseList  => caseList;
}
