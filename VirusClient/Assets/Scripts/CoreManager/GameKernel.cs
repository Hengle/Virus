using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKernel : MonoBehaviour {
    #region 对象创建
    //单例
    private static GameKernel _instance;
    public static GameKernel Instance
    {
        get
        {
            return _instance;
        }
    }

    private string userID;
    public string UserID
    {
        get
        {
            return userID;
        }
        set
        {
            userID = value;
        }
    }

    //委托事件
    public delegate void OnInit();
    public event OnInit onInitEvent;
    public delegate void OnUpdate();
    public event OnUpdate onUpdateEvent;
    public delegate void OnDestory();
    public event OnDestory onDestoryEvent;

    //Manager对象
    public NetManager netManager;
    public FileManager fileManager;
    public OperationManager operationManager; 
    public CodingManager codingManager;
    public ObjectManager objectManager;
    public LoginPanelManager loginPanelManager;
    public MainPanelManager mainPanelManager;
    public UserinforPanelManager userinforPanelManager;
    public NoticePanelManager noticePanelManager;
    public BattlePanelManager battlePanelManager;
    public TalentPanelManager talentPanelManager;
    #endregion
    private void Awake()
    {
        _instance = this;
        netManager = new NetManager();
        fileManager = new FileManager();
        operationManager = new OperationManager();
        codingManager = new CodingManager();
        objectManager = new ObjectManager();
        loginPanelManager = new LoginPanelManager();
        mainPanelManager = new MainPanelManager();
        userinforPanelManager = new UserinforPanelManager();
        noticePanelManager = new NoticePanelManager();
        battlePanelManager = new BattlePanelManager();
        talentPanelManager = new TalentPanelManager();
        
        onInitEvent();
    }

    void Start () {
        
    }
	
	void Update () {
        onUpdateEvent();

    }
}
