import time
from Manager import Player
from Manager import VirusManager
from Manager import Skill
from Manager import DBI
class Battle:
    _index=''
    _players=[]
    _map=[]
    _capacity=8
    _rmessage=None
    _randomID=None
    def __init__(self,index,rmessage):
        self._index=index
        self._rmessage=rmessage
    def addPlayer(self,randomID,roomID,dbi):
        if(len(self._players)<self._capacity and randomID):
            userid=dbi.combatmatch.getUserID(randomID)
            player=Player.Player(userid,randomID)
            self._randomID=randomID
            self._players.append(player)
            self.reply(randomID+'@100101|'+roomID)

    def reply(self,message):
        if(message):
            self._rmessage.put(message)

    def OnBattle(self):
         randomID=self._randomID
         roomID=self._index
         news=DBI.DBI().combatnews.getNews(roomID)
         newatts=news.split('|')
         for i in newatts:
             newatt=newatts[i].split(',')
             if newatt[0]==randomID:
                func=Skill.skill.get(newatt[1])
                rep=func(randomID,roomID,DBI.DBI())
                if(rep):
                    self.reply(randomID+'@'+rep)
         return '100103'+news+'|'+''+'|'+''
            #读取数据库，依次通过player执行skill！