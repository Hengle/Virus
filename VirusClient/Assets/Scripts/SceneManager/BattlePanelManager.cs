using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class BattlePanelManager : Manager {
    #region UI对象创建
    private Transform battlePanel;
    private Transform battleMap;
    private GameObject battleMapPoint;

    private GameObject[][] battleMapPoints;

    private Text topText;
    private Button settingBtn;
    private Button informBtn;
    private Text playerInformText;
    private Button choiceSkillBtn;
    private Button[] skillsBtn;
    private Text countDownText;
    private Button nextRoundBtn;
    #endregion

    public string[] skills = new string[5];
    private string roomID;
    public string RoomID
    {
        get
        {
            return roomID;
        }
        set
        {
            if (value.Length == 8)
                roomID = value;
        }
    }

    private bool isCreate = false;

    public override void Init()
    {
        base.Init();
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        isCreate = true;
        //初始化UI
        GameObject go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel/topText");
        if (go)
        {
            topText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel");
        if (go)
        {
            battlePanel = go.GetComponent<Transform>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel/battleMap");
        if (go)
        {
            battleMap = go.GetComponent<Transform>();
        }

        go = Resources.Load("battleMapPoint") as GameObject;
        if (go)
        {
            battleMapPoint = go;
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel/settingBtn");
        if (go)
        {
            settingBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel/informBtn");
        if (go)
        {
            informBtn = go.GetComponent<Button>();
            informBtn.onClick.AddListener(OninformBtnClick);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel/playerInformText");
        if (go)
        {
            playerInformText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel/skillPanel/choiceSkillBtn");
        if (go)
        {
            choiceSkillBtn = go.GetComponent<Button>();
            choiceSkillBtn.onClick.AddListener(OnchoiceSkillBtnClick);
        }

        skillsBtn = new Button[5];
        for (int i = 1; i <= 5; i++)
        {
            go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel/skillPanel/skill"+i.ToString());
            if (go)
            {
                skillsBtn[i-1] = go.GetComponent<Button>();
                skillsBtn[i - 1].onClick.AddListener(delegate () { this.OnskillBtnClick(skills[i-1]); });
            }
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel/skillPanel/countDownText");
        if (go)
        {
            countDownText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/BattlePanel/skillPanel/nextRoundBtn");
        if (go)
        {
            nextRoundBtn = go.GetComponent<Button>();
            nextRoundBtn.onClick.AddListener(OnnextRoundBtnClick);
        }

        battleMapPoints = new GameObject[32][];
        for (int i = 0; i < 32; i++)
        {
            battleMapPoints[i] = new GameObject[32];
            for (int j = 0; j < 32; j++)
            {
                go = GameObject.Instantiate(battleMapPoint, battleMap);
                go.transform.position = new Vector3(1630-64*i,64*j-752,0);
                battleMapPoints[i][j] = go;
            }
        }
        battlePanel.localScale = new Vector3(Mathf.Max(Screen.width / 606, 1), Mathf.Max(Screen.height / 272, 1), 0);
        OnPanelHide();
    }

    private void OnchoiceSkillBtnClick()
    {
        choiceSkillBtn.transform.parent.DOMove(new Vector3(0, 40, 0), 1);
    }

    private void OnnextRoundBtnClick()
    {
        nextRoundBtn.transform.parent.DOMove(new Vector3(0, -22, 0), 1);
    }

    public bool GetPanelActive()
    {
        return battlePanel.gameObject.activeSelf;
    }

    public void OnPanelShow()
    {
        battlePanel.gameObject.SetActive(true);
    }

    public void OnPanelHide()
    {
        battlePanel.gameObject.SetActive(false);
    }

    //undo
    public void OnBattleResultRecive(string useSkills, string resource, string battleMaps)
    {
        string []strs1 = useSkills.Split(' ');
        string[] strs2;
        string[] strs3;
        playerInformText.text = "";
        foreach (string str in strs1)
        {
            if (str != null)
            {
                strs2 = str.Split(',');
                playerInformText.text += strs2[0].ToString() + "使用了" + strs2[1].ToString();
            }
        }
        strs1 = battleMaps.Split(' ');
        foreach (string str in strs1)
        {
            if (str != null)
            {
                strs2 = str.Split(',');
                strs3 = strs2[1].Split('.');
                ChangeMap(strs2[0], int.Parse(strs3[0]), int.Parse(strs3[1]), int.Parse(strs3[2]));
            }
        }
    }

    private void ChangeMap(string userId,int x,int y,int conquerPercent)
    {
        //battleMapPoints[x][y]
    }

    public void OnBattleMapMove(Vector3 pos)
    {
        battleMap.position += pos;
    }

    public void OnBattleMapScale(float scale)
    {
        battleMap.DOScale(scale*battleMap.localScale, 0);
    }

    private void OnskillBtnClick(string skillID)
    {
        GameKernel.Instance.netManager.SendNetMessage("100102|" + RoomID + "," + skillID);
        choiceSkillBtn.transform.parent.DOMove(new Vector3(0, -22, 0), 1);
    }

    private void OninformBtnClick()
    {

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
