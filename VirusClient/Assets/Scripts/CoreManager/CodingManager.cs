using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingManager : Manager {
    private List<string> codingList;
    public override void Init()
    {
        base.Init();
        codingList = new List<string>();
    }

    public override void Update()
    {
        base.Update();
        foreach(string code in codingList)
        {
            deCoding(code);
        }
        codingList.Clear();
    }
    
    //向待发送消息列表中添加消息
    public void AddCoding(string message)
    {
        codingList.Add(message);
    }

    //将code对应函数
    private string deCoding(string code)
    {
        string[] operation = code.Split('|');
        switch (operation[0])
        {
            case "000101": GameKernel.Instance.loginPanelManager.LoginSuccess(); break;
            case "100101": GameKernel.Instance.mainPanelManager.OnMatchSuccess(operation[1], operation[2]); break;
            case "100103":GameKernel.Instance.battlePanelManager.OnBattleResultRecive(operation[1], operation[2], operation[3]); break;
            case "200102":GameKernel.Instance.fileManager.GetVersion(int.Parse(operation[1]));break;
            case "200101":GameKernel.Instance.fileManager.SetLua();break;
            case "200202":GameKernel.Instance.fileManager.GetFile(operation[1], operation[2], operation[3], operation[4]);break;
            case "300102":GameKernel.Instance.talentPanelManager.GetSkill(operation[1], operation[2]);break;
            case "300202":GameKernel.Instance.talentPanelManager.GetCanUseSkills(operation[1]);break;
        }

        return "";
    } 

    public override void Destory()
    {
        base.Destory();
    }
}
