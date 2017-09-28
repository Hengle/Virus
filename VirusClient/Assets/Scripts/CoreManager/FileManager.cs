using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager : Manager {
    private int version;
    private bool canUpdate = false;
    private bool isUpdate = false;
    xLuaInstance xi;
    public override void Init()
    {
        base.Init();
        //PlayerPrefs.SetInt("version", 0);
        GameKernel.Instance.netManager.SendNetMessage("200100|" + PlayerPrefs.GetInt("version", 1).ToString());
        xi = new xLuaInstance();
    }

    public void GetVersion(int version)
    {
        this.version = version;
        if (PlayerPrefs.GetInt("version", 1) < version)
        {
            SendVersion(PlayerPrefs.GetInt("version", 1) + 1);
        }
    }

    public void SetLua()
    {
        canUpdate = true;
    }

    public void SendVersion(int version)
    {
        GameKernel.Instance.netManager.SendNetMessage("200201|" + version.ToString());
    }

    public void GetFile(string fileName,string fileSrc,string fileType,string file)
    {
        if (fileName != null && fileSrc != null && fileType != null && file != null)
        {
            OutputFile of = new OutputFile();
            of.outputFile(fileSrc + fileName, System.Text.Encoding.UTF8.GetBytes(file));
            PlayerPrefs.SetInt("version", PlayerPrefs.GetInt("version", 1) + 1);
            if (PlayerPrefs.GetInt("version", 1) < version)
            {
                SendVersion(PlayerPrefs.GetInt("version", 1) + 1);
            }
            else
            {
                canUpdate = true;
            }
        }
    }

    public override void Update()
    {
        base.Update();
        if (canUpdate)
        {
            if (!isUpdate)
            {
                DirectoryInfo direction = new DirectoryInfo("Assets/Scripts/temp/");
                FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    if(files[i].Name.Split('.').Length!=2)
                        xi.Fixing("Assets/Scripts/temp/"+files[i].Name);
                    //Debug.Log( "FullName:" + files[i].FullName );  
                    //Debug.Log( "DirectoryName:" + files[i].DirectoryName );  
                }
                isUpdate = true;
            }
        }
    }

    public override void Destory()
    {
        base.Destory();
    }
}
