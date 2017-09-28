using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UserinforPanelManager : Manager {
    #region UI对象创建
    private Transform userinforPanel;

    private Button backBtn;
    private Image userHeadImage;
    private Image[] virusImages;
    private Text userNameText;
    private Image expSlider;
    private Text expText;
    private Text signText;
    #endregion
    private bool isCreate = false;

    public override void Init()
    {
        base.Init();
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        isCreate = true;
        //初始化UI
        GameObject go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/userinfoPanel/top/backBtn");
        if (go)
        {
            backBtn = go.GetComponent<Button>();
            backBtn.onClick.AddListener(OnbackBtnClick);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/userinfoPanel");
        if (go)
        {
            userinforPanel = go.GetComponent<Transform>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/userinfoPanel/top/userHeadImage");
        if (go)
        {
            userHeadImage = go.GetComponent<Image>();
        }

        virusImages = new Image[4];
        for (int i = 1; i < 5; i++)
        {
            go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/userinfoPanel/bottom/virusTipText/virus"+i.ToString());
            if (go)
            {
                virusImages[i-1] = go.GetComponent<Image>();
            }
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/userinfoPanel/center/userNameText");
        if (go)
        {
            userNameText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/userinfoPanel/center/expSlider");
        if (go)
        {
            expSlider = go.GetComponent<Image>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/userinfoPanel/center/expText");
        if (go)
        {
            expText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/userinfoPanel/center/signText");
        if (go)
        {
            signText = go.GetComponent<Text>();
        }
        userinforPanel.localScale = new Vector3(Mathf.Max(Screen.width / 606, 1), Mathf.Max(Screen.height / 272, 1), 0);
        OnPanelHide();
    }

    private void OnbackBtnClick()
    {
        OnPanelHide();
    }

    public void OnPanelShow()
    {
        userinforPanel.gameObject.SetActive(true);
    }

    public void OnPanelHide()
    {
        userinforPanel.gameObject.SetActive(false);
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
