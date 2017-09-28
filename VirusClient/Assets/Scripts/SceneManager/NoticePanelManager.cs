using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NoticePanelManager : Manager {
    #region UI对象创建
    private Transform noticePanel;

    private Text noticeText;
    private InputField noticeInput;
    private Button noticeSendBtn;
    #endregion
    private bool isCreate = false;

    public override void Init()
    {
        base.Init();
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        isCreate = true;
        //初始化UI
        GameObject go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/noticePanel/noticeText");
        if (go)
        {
            noticeText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/noticePanel");
        if (go)
        {
            noticePanel = go.GetComponent<Transform>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/noticePanel/noticeInput");
        if (go)
        {
            noticeInput = go.GetComponent<InputField>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/noticePanel/noticeSendBtn");
        if (go)
        {
            noticeSendBtn = go.GetComponent<Button>();
            noticeSendBtn.onClick.AddListener(OnonoticeSendBtnClick);
        }
        noticePanel.localScale = new Vector3(Mathf.Max(Screen.width / 606, 1), Mathf.Max(Screen.height / 272, 1), 0);
        OnPanelHide();
    }

    private void OnonoticeSendBtnClick()
    {

    }

    public void OnPanelShow()
    {
        noticePanel.gameObject.SetActive(true);
    }

    public void OnPanelHide()
    {
        noticePanel.gameObject.SetActive(false);
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
