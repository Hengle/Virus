from Manager import DeCode
import time
from Manager import DBI
class Calculater:
    _message=None
    _rmessage=None
    _dbi=None
    def __init__(self,message,rmessage):
        self._message=message
        self._rmessage=rmessage
        self._dbi=DBI.DBI()

    def _deCode(self,message):#通过DeCode对code和方法进行映射调用不同方法
        if(message):
            mes=message.split('@')
            if(len(mes)==2):
                randomID=mes[0]
                mess=mes[1].split('|')
                if(len(mess)==2):
                    func=DeCode.code.get(mess[0])
                    rep=func(mes[0][0:16],mess[1],self._dbi)
                    if(rep):
                        self.reply(randomID+'@'+rep)
    def calculate(self):
        while(1):
            if(self._message.empty()):
                time.sleep(1)
            else:
                self._deCode(self._message.get())

    def reply(self,message):
        if(message):
            self._rmessage.put(message)
