using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Serialization<T>
{
    public List<T> target;
    public Serialization(List<T> _target) => target = _target;
}

[System.Serializable]
public class ChemicalInfo
{
    public string chemicalName;
    public string description;

    public ChemicalInfo(string _chemicalName, string _description)
    {
        chemicalName = _chemicalName;
        description = _description;
    }
}