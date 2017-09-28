from models import dba
from Manager import VirusManager
class CombatMatch():
    def __init__(self):
        pass
    def getUserID(self,userrandom):
        try:
            if userrandom=='':
                VirusManager.VirusManager().addError('80001')
            else:
                cur=dba.dba().excute('select userID from combatmatch WHERE userRandom='+"'"+userrandom+"'")
                for row in cur.fetchall():
                    return row[0]
        except Exception as e:
            VirusManager.VirusManager().addError('88888')
            VirusManager.VirusManager().addError(e)
    def getMatcher(self,id):
        try:
            if id=='':
                VirusManager.VirusManager().addError('80001')
            else:
                cur=dba.dba().excute('select * from combatmatch where id='+"'"+id+"'")
                for row in cur.fetchall():
                    return row[0]+','+row[1]+','+row[2]+','+row[3]
        except Exception as e:
            VirusManager.VirusManager().addError('88888')
            VirusManager.VirusManager().addError(e)
    def getMatchRandom(self,num):
        try:
            if num=='':
                VirusManager.VirusManager().addError('')
            else:
                cur=dba.dba().excute('select userRandom from combatmatch where playerNumber='+"'"+num+"'")
                randoms=''
                i=0
                for row in cur.fetchall():
                    randoms=randoms+row[0]+','
                    i=i+1
                return randoms+'.'+i
        except Exception as e:
            VirusManager.VirusManager().addError('88888')
            VirusManager.VirusManager().addError(e)
    def addMatcher(self,id,userRandom,userid,num):
        try:
            if id=='':
                VirusManager.VirusManager().addError('80001')
            else:
                if userRandom=='':
                    VirusManager.VirusManager().addError('80002')
                else:
                    if userid=='':
                        VirusManager.VirusManager().addError('80003')
                    else:
                        if num=='':
                            VirusManager.VirusManager().addError('')
                        else:
                            print('111')
                            cur=dba.dba().excute("insert into combatmatch(id,userRandom,userID,userNumber) VALUE ('"+str(id)+"','"+str(userRandom)+"','"+str(userid)+"','"+str(num)+"')")
                            print('212')
        except Exception as e:
            VirusManager.VirusManager().addError('88888')
            print(e)
            VirusManager.VirusManager().addError(e)
    def getmaxID(self):
        try:
            cur=dba.dba().excute('select Max(id) as id FROM combatmatch')
            for row in cur.fetchall():
                return row[0]
        except Exception as e:
             VirusManager.VirusManager().addError(e)
    def deleteMatcher(self,randomID):
        try:
            if randomID=='':
                VirusManager.VirusManager().addError('80002')
            else:
                cur=dba.dba().excute('delete FROM combatmatch WHERE userRandom='+"'"+randomID+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('88888')
            VirusManager.VirusManager().addError(e)
    def deleteAllMatch(self):
        try:
             cur=dba.dba().excute('delete from combatmatch')
        except Exception as e:
             VirusManager.VirusManager().addError('88888')
             VirusManager.VirusManager().addError(e)
if __name__ == '__main__':
    u=CombatMatch()
    #u.getmaxID()
    #u.getMatcher('1')
    #u.getUserID('11')
    u.addMatcher('2','11','2',4)
    #u.deleteMatcher('2')