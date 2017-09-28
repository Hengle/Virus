using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TalentPanelManager : Manager {
    #region UI对象创建
    private Transform talentPanel;

    private Button backBtn;
    private Button[] talentPageBtns;
    private Button resetBtn;
    private Button[] skillBtns;
    private Text[] skillTexts;
    private Transform[] talentTransforms;

    private Text talentPageText;
    private Text skillTipText;

    private Transform skillPanel;
    #endregion
    private bool isCreate = false;
    public string nowPage="1";
    public string canUseSkills;

    private Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();

    public override void Init()
    {
        base.Init();
        isCreate = true;
        GameObject go = null;

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel/backBtn");
        if (go)
        {
            backBtn = go.GetComponent<Button>();
            backBtn.onClick.AddListener(OnbackBtnClick);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel");
        if (go)
        {
            talentPanel = go.transform;
        }

        talentPageBtns = new Button[3];
        for(int i = 1; i <= 3; i++)
        {
            go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel/talentPage"+i.ToString()+"Btn");
            if (go)
            {
                talentPageBtns[i-1] = go.GetComponent<Button>();
                talentPageBtns[i - 1].onClick.AddListener(delegate () { this.OntalentPageBtnClick(talentPageBtns[i - 1].gameObject); });
                //talentPageBtns[i - 1].onClick.AddListener(OntalentPageBtnClick);
            }
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel/talentPageText");
        if (go)
        {
            talentPageText= go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel/resetBtn");
        if (go)
        {
            resetBtn = go.GetComponent<Button>();
            resetBtn.onClick.AddListener(ReSetTalentPage);
        }

        skillBtns = new Button[5]; 
        for (int i = 1; i <= 5; i++)
        {
            go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel/Skill" + i.ToString());
            if (go)
            {
                skillBtns[i - 1] = go.GetComponent<Button>();
                skillBtns[i - 1].onClick.AddListener(delegate () { this.ShowSkillPanel(i); });
            }
        }

        skillTexts = new Text[5];
        for (int i = 1; i <= 5; i++)
        {
            go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel/Skill" + i.ToString()+"/Text");
            if (go)
            {
                skillTexts[i - 1] = go.GetComponent<Text>();
            }
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel/talents/talentBtn/");
        talentTransforms = go.GetComponentsInChildren<Transform>();

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel/talents/skillTipText");
        if (go)
        {
            skillTipText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/TalentPanel/SkillPanel");
        if (go)
        {
            skillPanel = go.GetComponent<Transform>();
            skillPanel.gameObject.SetActive(false);
        }

        talentPanel.localScale = new Vector3(Mathf.Max(Screen.width / 606, 1), Mathf.Max(Screen.height / 272, 1), 0);
        OnPanelHide();
    }

    //显示可携带技能面板
    string[] skillsID;
    private void ShowSkillPanel(int skillTenth)
    {
        skillPanel.gameObject.SetActive(true);
        Button[] skillBtn = skillPanel.GetComponentsInChildren<Button>();
        skillsID = canUseSkills.Split(',');
        SetTalentPage(nowPage, "0,0,0");
        int i = 0;
        foreach(Button btn in skillBtn)
        {
            if(i<skillsID.Length)
                if (btn.name == skillsID[i])
                {
                    btn.onClick.AddListener(delegate () { this.CarrySkill( skillsID[i],skillTenth); });
                    btn.interactable = true;
                    i++;
                }
                else
                {
                    btn.interactable = false;
                }
        }
    }

    private void HideSkillPanel()
    {
        skillPanel.gameObject.SetActive(false);
    }

    private void CarrySkill(string skillID,int skillTenth)
    {
        GameKernel.Instance.netManager.SendNetMessage("300203|" + "," + nowPage + skillID +","+skillTenth.ToString());
        HideSkillPanel();
    }

    private void SetAllSkillIcon()
    {
        foreach(Transform tran in talentTransforms)
        {
            Sprite sprite = new Sprite();
            /*spriteDict.TryGetValue(tran.GetComponent<TalentButton>().talentID, out sprite);
            if (sprite != null)
            {
                tran.GetComponent<TalentButton>().SetButtonIcon(sprite);
            }*/
        }
    }

    //从服务器端获取天赋技能信息并修改按钮状态
    public void GetSkill(string canChoiceSkills,string haveSkills)
    {
        canUseSkills = haveSkills;
        string[] ccs = canChoiceSkills.Split(',');
        string[] hs = haveSkills.Split(',');
        foreach(Transform tran in talentTransforms)
        {
            if (tran != null)
            {
                if (tran.GetComponent<TalentButton>())
                {
                    if (tran.GetComponent<TalentButton>().IsInString(ccs))
                    {
                        tran.GetComponent<TalentButton>().SetEnable();
                    }
                    else
                    if (tran.GetComponent<TalentButton>().IsInString(hs))
                    {
                        tran.GetComponent<TalentButton>().SetActive();
                    }
                    else
                        tran.GetComponent<TalentButton>().SetDisable();
                }
            }
        }
    }

    private void OntalentPageBtnClick(GameObject go)
    {
        SetAllSkillIcon();
        nowPage = go.GetComponentInChildren<Text>().text;
        talentPageText.text ="天赋页"+ go.GetComponentInChildren<Text>().text;
        SetTalentPage(nowPage, "0,0,0");
    }

    public void SetskillTipText(string str)
    {
        skillTipText.text = str;
    }

    //初始化天赋页面
    private void SetTalentPage(string heroID,string talent)
    {
        GameKernel.Instance.netManager.SendNetMessage("300100|"+heroID + "," + talent);
    }

    private void ReSetTalentPage()
    {
        GameKernel.Instance.netManager.SendNetMessage("300103|"+nowPage);
    }

    private void OnbackBtnClick()
    {
        GameKernel.Instance.mainPanelManager.OnPanelShow();
        OnPanelHide();
    }

    private Sprite GetSprite(string key)
    {
        if (key != null)
        {
            Sprite sprite = new Sprite();
            spriteDict.TryGetValue(key, out sprite);
            if (sprite != null)
            {
                return sprite;
            }
            else
            {
                sprite = Resources.Load(key) as Sprite;
                spriteDict.Add(key,sprite);
                return sprite;
            }
        }
        return null;
    }
    
    public void GetCanUseSkills(string skill)
    {
        string[] skills = skill.Split(',');
        for(int i = 0; i < 5; i++)
        {
            if (skills[i] != null)
            {
                skillBtns[i].image.sprite = GetSprite(skills[i]);
            }
        }
    }

    public void OnPanelShow()
    {
        OntalentPageBtnClick(talentPageBtns[0].gameObject);
        talentPanel.gameObject.SetActive(true);
    }

    public void OnPanelHide()
    {
        talentPanel.gameObject.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
        if (!isCreate)
        {
            Init();
        }
    }

    public override void Destory()
    {
        base.Destory();
    }
}
