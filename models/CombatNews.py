from models import dba
from Manager import VirusManager
class CombatNews():
    def __init__(self):
        pass
    def getNews(self,houseid):
        try:
            if houseid=='':
                VirusManager.VirusManager().addError('90001')
            else:
                cur=dba.dba().excute('select * from combatnews where houseID='+"'"+houseid+"'")
                for row in cur.fetchall():
                    return  str(row[1])
        except Exception as e:
            VirusManager.VirusManager().addError('99999')
            VirusManager.VirusManager().addError(e)
    def addHouse(self,houseid):
        try:
            if houseid=='':
                VirusManager.VirusManager().addError('90001')
            else:
                cur=dba.dba().excute("insert into combatnews(houseid,news) VALUE ('"+str(houseid)+"','')")
        except Exception as e:
            VirusManager.VirusManager().addError('99999')
            VirusManager.VirusManager().addError(e)
    def addNews(self,houseid,news):
        houseid=houseid
        oldNews=self.getNews(houseid)
        try:
            if houseid=='':
                VirusManager.VirusManager().addError('90001')
            else:
                if news=='':
                    VirusManager.VirusManager().addError('90002')
                else:
                    cur=dba.dba().excute('update combatnews set news="'+oldNews+'|'+news+'"where houseID='+"'"+houseid+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('99999')
            VirusManager.VirusManager().addError(e)
    def deleteNews(self,houseid):
        try:
            if houseid=='':
                VirusManager.VirusManager().addError('90001')
            else:
                cur=dba.dba().excute('delete FROM combatnews WHERE houseID='+"'"+houseid+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('99999')
            VirusManager.VirusManager().addError(e)
    def deleteAllNews(self):
        try:
             cur=dba.dba().excute('delete from combatnews')
        except Exception as e:
             VirusManager.VirusManager().addError('99999')
             VirusManager.VirusManager().addError(e)
if __name__ == '__main__':
    u=CombatNews()
    #u.addHouse('3')
    #u.deleteAllNews()
    #u.addNews('1','123')
    #u.getNews('1')
    #u.addNews('2','bandc')
    #u.deleteNews('2')