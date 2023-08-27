using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingManager : MonoBehaviour
{
    public GameObject chemiP;    //ȭ�н� �θ�
    public GameObject[] chemiGo; //ȭ�н�
    public bool[] isCheimi;  //ȭ�н� Ȱ��ȭ ����
    public bool[] isInCheimicalInfos;  //chemicalInfos�� ���ִ���
    public Text chemiText;
    public List<ChemicalInfo> chemicalInfos;
    public Button descriptionBtn;

    void Start()
    {
        chemiGo = new GameObject[chemiP.transform.childCount];

        for (int i = 0; i < chemiGo.Length; i++)
        {
            chemiGo[i] = chemiP.transform.GetChild(i).gameObject;
        }

        isCheimi = new bool[chemiGo.Length];
        isInCheimicalInfos = new bool[chemiGo.Length];
    }
    void Update()
    {
        CheckChemi();
        AddDiscripts();
    }

    public void CheckChemi()
    {
        for (int i = 0; i < chemiGo.Length; i++)
        {
            isCheimi[i] = chemiGo[i].activeSelf;
        }
    }

    public void AddDiscripts()
    {
        for (int i = 0; i < chemiGo.Length; i++)
        {
            if (isCheimi[i] && isInCheimicalInfos[i] == false)
            {
                GetChemicalInfo(chemiGo[i].name);
                SetDescriptionText();
                isInCheimicalInfos[i] = true;
            }

            if (!isCheimi[i] && isInCheimicalInfos[i] == true)
            {
                RemoveChemicalInfo(chemiGo[i].name);
                SetDescriptionText();
                isInCheimicalInfos[i] = false;
            }

            descriptionBtn.gameObject.SetActive((chemicalInfos.Count == 0) ?  false : true);
        }
    }

    public void SetDescriptionText()
    {
        chemiText.text = "";

        if (chemicalInfos == null)
            return;

        for (int i = 0; i < chemicalInfos.Count; i++)
        {
            chemiText.text += chemicalInfos[i].description.ToString() + "\n";
        }
    }

    public void GetChemicalInfo(string chemicalName)
    {
        var loadedJson = Resources.Load<TextAsset>("ChemicalJsonDescription/" + chemicalName);
        ChemicalInfo chemicalInfo = JsonUtility.FromJson<ChemicalInfo>(loadedJson.ToString());
        chemicalInfos.Add(chemicalInfo);
    }

    public void RemoveChemicalInfo(string chemicalName)
    {
        ChemicalInfo chemicalInfo = chemicalInfos.Find(x => x.chemicalName == chemicalName);
        chemicalInfos.Remove(chemicalInfo);
    }

}