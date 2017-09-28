
from Manager import DBI
class Player:
    playerinfo=None
    _randomID=None
    _userID=None
    def __init__(self,userid,randomid):
        self._randomID=randomid
        self._userID=userid
        heroid=DBI.DBI().hero.getUserHero(userid)
        if(heroid):
            skill=DBI.DBI().skillconfig.getUserHeroSkill(heroid)#skill中两条数据，skillid,skillDesc中间逗号分隔
            self.playerinfo=heroid+'|'+skill
    def GetPlayer(self,randomID):
        if(self._randomID==randomID):
            return self

