using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoginPanelManager : Manager {
    #region UI对象创建
    private Transform loginPanel;

    private Text userNameText;
    private Text passwordText;
    private Button registerBtn;
    private Button loginBtn;
    private InputField userNameInput;
    private InputField passwordInput;
    #endregion
    public override void Init()
    {
        base.Init();
        //初始化UI
        GameObject go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/loginPanel/userNameInput/Text");
        if (go)
        {
            userNameText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/loginPanel");
        if (go)
        {
            loginPanel = go.GetComponent<Transform>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/loginPanel/passwordInput/Text");
        if (go)
        {
            passwordText = go.GetComponent<Text>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/loginPanel/registerBtn");
        if (go)
        {
            registerBtn = go.GetComponent<Button>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/loginPanel/loginBtn");
        if (go)
        {
            loginBtn = go.GetComponent<Button>();
            loginBtn.onClick.AddListener(Login);
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/loginPanel/userNameInput");
        if (go)
        {
            userNameInput = go.GetComponent<InputField>();
        }

        go = GameKernel.Instance.objectManager.FindGameObjectByPath("Canvas/loginPanel/passwordInput");
        if (go)
        {
            passwordInput = go.GetComponent<InputField>();
        }

        if (PlayerPrefs.GetString("userName") != null)
        {
            userNameInput.text = PlayerPrefs.GetString("userName");
        }

        if (PlayerPrefs.GetString("password") != null)
        {
            passwordInput.text = PlayerPrefs.GetString("password");
        }

        loginPanel.localScale = new Vector3(Mathf.Max(Screen.width / 606,1), Mathf.Max(Screen.height / 272,1), 0);
    }

    public override void Update()
    {
        base.Update();
    }

    private void Login()
    {
        GameKernel.Instance.netManager.SendNetMessage("000100|" + userNameText.text + "," + passwordText.text);
        PlayerPrefs.SetString("userName", userNameText.text);
        PlayerPrefs.SetString("password", passwordText.text);
    }

    public void LoginSuccess()
    {
        GameKernel.Instance.UserID = userNameText.text;
        OnPanelHide();
        GameKernel.Instance.mainPanelManager.OnPanelShow();
    }

    public void OnPanelShow()
    {
        loginPanel.gameObject.SetActive(true);
    }

    public void OnPanelHide()
    {
        loginPanel.gameObject.SetActive(false);
    }

    public override void Destory()
    {
        base.Destory();
    }
}
