from Manager import Connecter
from Manager import Wrong
from Manager import Command
from Manager import Calculater
from Manager import Battle
from Manager import DBI
import multiprocessing
import time
import random,string
import threading
class VirusManager:
    _conn=None
    _wrong=None
    _message=None
    _rmessage=None
    mutex=multiprocessing.Lock()
    vmInstance=None

    def __new__(cls):
        cls.mutex.acquire()
        if cls.vmInstance is None:
            cls._wrong=Wrong.Wrong('error.txt')
            cls.vmInstance = super(VirusManager, cls).__new__(cls)
        cls.mutex.release()
        return cls.vmInstance

    def GetRandomCode(self,length):
        #随机出数字的个数
        numOfNum = random.randint(1,length-1)
        numOfLetter = length - numOfNum
        #选中numOfNum个数字
        slcNum = [random.choice(string.digits) for i in range(numOfNum)]
        #选中numOfLetter个字母
        slcLetter = [random.choice(string.ascii_letters) for i in range(numOfLetter)]
        #打乱这个组合
        slcChar = slcNum + slcLetter
        random.shuffle(slcChar)
        #生成密码
        genPwd = ''.join([i for i in slcChar])
        return genPwd

    #添加战斗房间
    def AddBattle(self):
        while(1):
            roomID=VirusManager().GetRandomCode(8)
            battle=Battle.Battle(roomID,self._rmessage)
            match=DBI.DBI().combatmatch.getMatcher('1')
            if(match):
                mat=match.split(',')
                nums=DBI.DBI().combatmatch.getMatcher(mat[0])
                num=nums.split(',')
                playernumber=DBI.DBI().combatmatch.getMatchNumID(num[3])
                pnum=playernumber.split('.')
                ppn=pnum[0].split(',')
                skills=DBI.DBI().hero.getSkill('0',num[1])
                if int(pnum[1])>=int(num[3]):
                    DBI.DBI().combatnews.addHouse(roomID)
                    for row in ppn:
                        battle.addPlayer(row[0],roomID,DBI.DBI())
                        return '100101'+'|'+roomID+skills
                DBI.DBI().combatmatch.deleteMatcher(mat[1])
                roomThread=threading.Thread(target=battle.OnBattle)
                roomThread.start()
                time.sleep(100)

            #从数据库匹配信息表获取1个player
            #添加房间，房间号为roomID
            #通知player房间号VirusManager()._conn.SendMessage()
            #添加多个player undo

    def main(self):
        message=multiprocessing.Queue()
        rmessage=multiprocessing.Queue()
        self._message=message
        self._rmessage=rmessage
        VirusManager()._conn=Connecter.Connecter('',8889,message,rmessage)
        com=Command.Command()
        p1=multiprocessing.Process(target=VirusManager()._conn.Reciver)
        p2=multiprocessing.Process(target=com.getInput)
        p3=multiprocessing.Process(target=VirusManager().AddBattle)
        p1.start()
        #p2.start()
        p3.start()
        i=1
        while(i<5):
            print('计算进程['+str(i)+']开启')
            i=i+1
            ca=Calculater.Calculater(message,rmessage)
            p=multiprocessing.Process(target=ca.calculate)
            p.start()
        DBI.DBI().usermap.deleteAllUsermap()
        DBI.DBI().combatmatch.deleteAllMatch()
        DBI.DBI().combatnews.deleteAllNews()
    def SendMessage(self,message):
        VirusManager()._conn.SendMessage(message)

    def addError(self,error):
        if(error):
            VirusManager()._wrong.addError(error)

if __name__ == '__main__':
    vm=VirusManager()
    vm.main()



