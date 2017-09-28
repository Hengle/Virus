using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentButton : MonoBehaviour {
    public string talentID;
    public string talentExpend;
    public string talentDesc;

    public bool IsInString(string [] strs)
    {
        foreach(string str in strs)
        {
            if (str == talentID)
                return true;
        }
        return false;
    }

    public void SetButtonIcon(Sprite sprite)
    {
        transform.GetComponent<Image>().sprite = sprite;
    }

    public void OnBtnClick()
    {
        GameKernel.Instance.talentPanelManager.SetskillTipText(talentDesc);
        GameKernel.Instance.netManager.SendNetMessage("300100|" + GameKernel.Instance.talentPanelManager.nowPage + "," + talentExpend);
    }

    public void SetActive()
    {
        transform.GetComponent<Button>().interactable = false;
        transform.GetComponent<Image>().color = Color.red;
    }

    public void SetDisable()
    {
        transform.GetComponent<Button>().interactable = false;
        transform.GetComponent<Image>().color = Color.gray;
    }

    public void SetEnable()
    {
        transform.GetComponent<Button>().interactable = true;
        transform.GetComponent<Image>().color = Color.white;
    }
}

