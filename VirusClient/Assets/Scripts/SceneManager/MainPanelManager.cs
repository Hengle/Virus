using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainPanelManager : Manager {
    #region UI对象创建

    private Transform mainPanel;

    //top
    private Text userNameText;
    private Image expSlider;
    private Button headBtn;
    private Text powerText;
    private Button powerBtn;
    private Text diamondText;
    private Button diaMondBtn;
    private Button friendBtn;
    private Button settingBtn;
    private Button wifiBtn;
    private Text noticeText;
    private Button addNoticeBtn;
    //left
    private Text rankText;
    private Button rankBtn;
    //right
    private Button taskBtn;
    private Button informBtn;
    //center
    private Button battleBtn;
    private Button createRoomBtn;
    private Button riskBtn;
    private Button limitTimeBtn;
    //bottom
    private Button signBtn;
    private Button talentBtn;
    private Button geneBtn;
    private Button virusBtn;
    private Button warehouseBtn;
    private Button storeBtn;
    #endregion

    private bool isCreate = false;
    private bool isNoticePanelShow = false;

    public override void Init()
    {
        base.Init();
        isCreate = true;
        //初始化UI
        GameObject go = null;

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/head/userName");
        if (go)
        {
            userNameText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel");
        if (go)
        {
            mainPanel = go.GetComponent<Transform>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/head/expSlider/exp");
        if (go)
        {
            expSlider = go.GetComponent<Image>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/head/headBtn");
        if (go)
        {
            headBtn = go.GetComponent<Button>();
            headBtn.onClick.AddListener(OnheadBtnClick);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/powerPanel/powerText");
        if (go)
        {
            powerText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/powerPanel/powerBtn");
        if (go)
        {
            powerBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/diamondPanel/diamondText");
        if (go)
        {
            diamondText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/diamondPanel/diamondBtn");
        if (go)
        {
            diaMondBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/friendBtn");
        if (go)
        {
            friendBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/settingBtn");
        if (go)
        {
            settingBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/wifiBtn");
        if (go)
        {
            wifiBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/notice/noticeBg/noticeText");
        if (go)
        {
            noticeText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/top/notice/addNoticeBtn");
        if (go)
        {
            addNoticeBtn = go.GetComponent<Button>();
            addNoticeBtn.onClick.AddListener(OnaddNoticeBtnClick);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/left/rank/rankText");
        if (go)
        {
            rankText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/left/rank/rankBtn");
        if (go)
        {
            rankBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/right/taskBtn");
        if (go)
        {
            taskBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/right/informBtn");
        if (go)
        {
            informBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/center/battleBtn");
        if (go)
        {
            battleBtn = go.GetComponent<Button>();
            battleBtn.onClick.AddListener(OnBattleBtnClick);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/center/createRoomBtn");
        if (go)
        {
            createRoomBtn = go.GetComponent<Button>();
            createRoomBtn.onClick.AddListener(OnCreateRoomBtnClick);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/center/riskBtn");
        if (go)
        {
            riskBtn = go.GetComponent<Button>();
            riskBtn.onClick.AddListener(OnristBtnClick);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/center/limitTimeBtn");
        if (go)
        {
            limitTimeBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/bottom/signBtn");
        if (go)
        {
            signBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/bottom/talentBtn");
        if (go)
        {
            talentBtn = go.GetComponent<Button>();
            talentBtn.onClick.AddListener(OnTalentBtnClick);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/bottom/geneBtn");
        if (go)
        {
            geneBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/bottom/virusBtn");
        if (go)
        {
            virusBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/bottom/warehouseBtn");
        if (go)
        {
            warehouseBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/MainPanel/bottom/storeBtn");
        if (go)
        {
            storeBtn = go.GetComponent<Button>();
        }

        mainPanel.localScale = new Vector3(Mathf.Max(Screen.width / 606, 1), Mathf.Max(Screen.height / 272, 1), 0);
        OnPanelHide();
    }

    //进入战斗匹配
    private void OnBattleBtnClick()
    {
        GameKernel.Instance.netManager.SendNetMessage("100100|"+ GameKernel.Instance.UserID+",1");
    } 

    private void OnCreateRoomBtnClick()
    {
        GameKernel.Instance.netManager.SendNetMessage("100100|" + GameKernel.Instance.UserID + ",2");
    }

    private void OnristBtnClick()
    {
        GameKernel.Instance.netManager.SendNetMessage("100100|" + GameKernel.Instance.UserID + ",8");
    }

    private void OnaddNoticeBtnClick()
    {
        if (!isNoticePanelShow)
        {
            isNoticePanelShow = true;
            GameKernel.Instance.noticePanelManager.OnPanelShow();
        }
        else
        {
            isNoticePanelShow = false;
            GameKernel.Instance.noticePanelManager.OnPanelHide();
        }
    }

    public void OnPanelShow()
    {
        mainPanel.gameObject.SetActive(true);
    }

    public void OnPanelHide()
    {
        mainPanel.gameObject.SetActive(false);
    }

    private void OnheadBtnClick()
    {
        GameKernel.Instance.userinforPanelManager.OnPanelShow();
    }

    private void OnTalentBtnClick()
    {
        GameKernel.Instance.talentPanelManager.OnPanelShow();
        OnPanelHide();
    }

    //匹配战斗成功
    public void OnMatchSuccess(string roomID,string skillsID)
    {
        GameKernel.Instance.battlePanelManager.RoomID = roomID;
        string[] strs = skillsID.Split(',');
        for(int i = 0; i < 5; i++)
        {
            GameKernel.Instance.battlePanelManager.skills[i] = strs[i];
        }
        OnPanelHide();
        GameKernel.Instance.battlePanelManager.OnPanelShow();
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
