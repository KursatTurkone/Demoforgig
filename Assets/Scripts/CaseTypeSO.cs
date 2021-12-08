using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Case", fileName = "CaseType")]
public class CaseTypeSO : ScriptableObject
{
    [SerializeField]
    string caseName;
    [SerializeField]
    int goldAmount;
    [SerializeField]
    int size;

    public string CaseName => caseName;
    public int GoldAmount => goldAmount;
    public int Size => size;
}
