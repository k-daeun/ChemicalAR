using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Element : MonoBehaviour
{
    public string symbol = "";
    [Space(5)]

    public bool isReactive = false;
    public List<GameObject> molecules = new List<GameObject>();
    [Space(5)]

    [HideInInspector] public bool reacted = false;

    [HideInInspector] public GameObject atom = null;
    [HideInInspector] public Dictionary<string, GameObject> reactions = new Dictionary<string, GameObject>();
    List<string> GameObj = new List<string>();

    private void Awake()
    {
        // Setup rigidbody
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;

        // Get atom gameobject (always first in tree, so index = 0)
        atom = transform.GetChild(0).gameObject;

        // Build reactions dictionary
        foreach (var molecule in molecules)
        {
            reactions.Add(molecule.name, molecule);
            GameObj.Add(molecule.name);
        }
    }


    public void Reset()
    {
        if (isReactive)
        {
            reacted = true;
            foreach (var m in GameObj)
            {
                atom.SetActive(true);
                reactions[m].SetActive(false);
            }
        }
    }

    public void React()
    {
        if (reacted)
        {
            reacted = false;
            foreach (var m in GameObj)
            {
                atom.SetActive(false);
                reactions[m].SetActive(true);
            }
        }
    }

}