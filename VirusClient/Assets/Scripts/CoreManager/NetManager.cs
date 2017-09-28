using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.Net;
using System.Threading;

public class NetManager : Manager {
    IPAddress ip = IPAddress.Parse("127.0.0.1");
    Socket clientSocket;
    int size = 512;
    string randomID = null;
    Thread recThread;
    byte[] recMessage = null;
    bool isRecive = false;

    public override void Init()
    {
        base.Init();
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(new IPEndPoint(ip, 8889)); //配置服务器IP与端口 
            Debug.Log("连接服务器成功");
            byte[] data = null;
            data = new byte[size];
            clientSocket.Receive(data, size, SocketFlags.None);
            randomID = System.Text.Encoding.UTF8.GetString(data).Split('~')[0];
        }
        catch
        {
            Debug.Log("连接服务器失败");
            return;
        }
        recThread = new Thread(RecMessage);
        recThread.Start();
    }

    public override void Update()
    {
        base.Update();
        if (isRecive)
        {
            string str = System.Text.Encoding.UTF8.GetString(recMessage);
            str = str.Split('~')[0];
            Debug.Log("客户端收到："+str);
            GameKernel.Instance.codingManager.AddCoding(str);
            isRecive = false;
        }
    }

    public override void Destory()
    {
        base.Destory();
    }

    private void RecMessage()
    {
        while (true)
        {
            if (!isRecive)
            {
                recMessage = new byte[size];
                clientSocket.Receive(recMessage, size, SocketFlags.None);
                isRecive = true;
            }
        }
    }

    public void SendNetMessage(string message)
    {
        //通过 clientSocket 发送数据  
        try
        {
            clientSocket.Send(System.Text.Encoding.UTF8.GetBytes(randomID+'@'+ message+"~"));
            Debug.Log("向服务器发送消息" + message);
        }
        catch
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            return;
        }
    }
}
