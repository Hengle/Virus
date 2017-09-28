import socket
from Manager import VirusManager
import threading
import time
from Manager import DBI
import random,string
class Connecter:
    _HOST = ''
    _PORT = ''
    _soc=''
    _connDict={}#socket连接的字典
    _isConn=False
    _message=None
    _rmessage=None
    rr=None
    def __init__(self,HOST,PORT,message,rmessage):
        self._HOST=HOST
        self._PORT=PORT
        self._message=message
        self._rmessage=rmessage

    def __del__(self):
        self._soc.close()
        print('关闭socket连接')

    #初始化服务器，开启socket，等待连接
    def Reciver(self):
        self._soc = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        try:
            self._soc.bind((self._HOST, self._PORT))
            self._soc.listen(100)#最大连接数，由数据库的setting表控制
            print('socket开启成功！')
            #开启新线程
            tt=threading.Thread(target=self.ReturnMessage)
            tt.start()
            while 1:
                if(self._isConn==False):
                    t=threading.Thread(target=self.GetMessage)
                    t.start()
        except socket.error as e:
            print(e)
            VirusManager.VirusManager().addError(e)


    def GetMessage(self):
        self._isConn=True
        conn, addr = self._soc.accept()
        #生成随机码，用来标识用户,并将其返回至玩家
        randomID=''
        while(1):
            randomID=VirusManager.VirusManager().GetRandomCode(16)
            if(randomID in self._connDict):
                pass
            else:
                break;
        self._connDict[randomID]=conn
        self.rr=randomID
        self._rmessage.put(randomID+'@'+randomID)
        while(1):
            data=conn.recv(1024).decode("utf-8")
            data=data.split('~')[0]
            if(len(data)<=0):#长度小于等于0表示远程连接断开
                conn.close()
                self._connDict.pop(randomID)
                break;
            self._message.put(data)


    #向相应的socket对象发送消息
    def SendMessage(self,rID,message):
        if(message and rID):
            message=message+'~'
            conn=self._connDict.get(rID[0:16])#通过rID获取conn
            if(conn):
                conn.sendall(message.encode(encoding="utf-8"))

    #将队列中的消息返回前端
    def ReturnMessage(self):
        while(1):
            if(self._rmessage.empty()):
                time.sleep(1)
            else:
                mes=self._rmessage.get()
                mess=mes.split('@')
                if(len(mess)==2):
                    self.SendMessage(mess[0],mess[1])
