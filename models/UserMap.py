from models import dba
from Manager import VirusManager
class UserMap():
    def __init__(self):
        pass
    def getUserID(self,random):
        try:
            if random=='':
                VirusManager.VirusManager().addError('70001')
            else:
                cur=dba.dba().excute('select userID from usermap where random= '+"'"+random+"'")
                for row in cur.fetchall():
                    return row[0]
        except Exception as e:
            VirusManager.VirusManager().addError('77777')
            VirusManager.VirusManager().addError(e)
    def deleteUserMap(self,random):
        try:
            if random=='':
                VirusManager.VirusManager().addError('70001')
            else:
                cur=dba.dba().excute('delete from usermap where random='+"'"+random+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('77777')
            VirusManager.VirusManager().addError(e)
    def addUserMap(self,random,userid):
        try:
            if random=='':
                VirusManager.VirusManager().addError('70001')
            else:
                if userid=='':
                    VirusManager.VirusManager().addError('70002')
                else:
                    cur=dba.dba().excute("insert into usermap(random,userID) VALUE ('"+str(random)+"','"+str(userid)+"')")
        except Exception as e:
            VirusManager.VirusManager().addError('77777')
            VirusManager.VirusManager().addError(e)
    def deleteAllUsermap(self):
        try:
             cur=dba.dba().excute('delete from usermap')
        except Exception as e:
             VirusManager.VirusManager().addError('77777')
             VirusManager.VirusManager().addError(e)


if __name__ == '__main__':
    u=UserMap()
    #u.getUserID('11')
    #u.addUserMap('11','2')
    #u.deleteUserMap('11')
    #u.deleteUserMap('11')
    #u.getUserID('11')
