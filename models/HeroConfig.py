from models import dba
from Manager import VirusManager
class HeroConfig():
    def __init__(self):
        pass
    def addHeroAtt(self,heroid,heroatt,heroname,herodesc):
        try:
            if heroid=='':
                VirusManager.VirusManager().addError('50001')
            else:
                if heroatt=='':
                    VirusManager.VirusManager().addError('50002')
                else:
                    if heroname=='':
                        VirusManager.VirusManager().addError('50003')
                    else:
                        if herodesc=='':
                            VirusManager.VirusManager().addError('50004')
                        else:
                            cur=dba.dba().excute("insert into heroconfig(heroID,heroAtt,heroName,heroDesc) VALUE ('"+str(heroid)+"','"+str(heroatt)+"','"+str(heroname)+"','"+str(herodesc)+"')")
        except Exception as e:
            VirusManager.VirusManager().addError('55555')
            VirusManager.VirusManager().addError(e)
    def deleteHero(self,heroid):
        try:
            if heroid=='':
                VirusManager.VirusManager().addError('50001')
            else:
                cur=dba.dba().excute('delete FROM heroconfig WHERE heroID='+"'"+heroid+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('55555')
            VirusManager.VirusManager().addError(e)
    def updateHero(self,heroid,heroatt):
        try:
            if heroid=='':
                VirusManager.VirusManager().addError('50001')
            else:
                if heroatt=='':
                    VirusManager.VirusManager().addError('50002')
                else:
                    cur=dba.dba().excute("update heroconfig set heroAtt="'+str(heroatt)+'" where heroID="+"'"+heroid+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('55555')
            VirusManager.VirusManager().addError(e)
    def getUserHero(self,heroid):
        try:
            if heroid=='':
                VirusManager.VirusManager().addError('50001')
            else:
                cur=dba.dba().excute('select * from heroconfig where heroID='+"'"+heroid+"'")
                for row in cur.fetchall(self):
                    return row[0]+','+row[1]+','+row[2]
        except Exception as e:
            VirusManager.VirusManager().addError(e)

if __name__ == '__main__':
    h=HeroConfig()
    #h.getHeroAtt('a')
    #h.addHeroAtt('c','wei','eee','das')
    #h.deleteHero('c')
