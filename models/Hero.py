from models import dba
from Manager import VirusManager
class Hero():
    def __init__(self):
        pass
    def getHeroID(self,id):
        try:
            if id=='':
                VirusManager.VirusManager().addError('20001')
            else:
                cur=dba.dba().excute('select heroID from hero where id='+"'"+id+"'")
                for row in cur.fetchall():
                    return row[0]
        except Exception as e:
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
    def getTalent(self,heroID,userID):
        try:
            if heroID=='':
                VirusManager.VirusManager().addError('20002')
            else:
                if userID=='':
                    VirusManager.VirusManager.addError('20006')
                else:
                    cur=dba.dba().excute('select userID from hero where heroID='+"'"+heroID+"'")
                    for row in cur.fetchall():
                        if str(row[0])==userID:
                            curs=dba.dba().excute('select talent from hero where userID='+"'"+str(row[0])+"'")
                            for row in curs.fetchall():
                                return row[0]
        except Exception as e:
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
    def getHerolevel(self,heroID,userID):
        try:
            if heroID=='':
                VirusManager.VirusManager().addError('20002')
            else:
                if userID=='':
                    VirusManager.VirusManager.addError('20006')
                else:
                    cur=dba.dba().excute('select userID from hero where heroID='+"'"+heroID+"'")
                    for row in cur.fetchall():
                        if str(row[0])==userID:
                            curs=dba.dba().excute('select heroLevel from hero where userID='+"'"+str(row[0])+"'")
                            for row in curs.fetchall():
                                return row[0]
        except Exception as e:
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
    def showHero(self):
        try:
            cur=dba.dba().excute('select * from hero')
            for row in cur.fetchall():
                return str(row)
        except Exception as e:
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
    def addHero(self,id,heroid,heroname,userid):
        try:
            if id=='':
                VirusManager.VirusManager().addError('20001')
                #print('s1')
            else:
                if heroid=='':
                    VirusManager.VirusManager().addError('20002')
                    #print('s2')
                else:
                    if heroname=='':
                        VirusManager.VirusManager().addError('20003')
                    else:
                        if userid=='':
                            VirusManager.VirusManager().addError('20006')
                            #print('s6')
                        else:
                            cur=dba.dba().excute("insert into hero(id,heroID,heroName,userID) VALUE ('"+str(id)+"','"+str(heroid)+"','"+str(heroname)+"','"+str(userid)+"')")
        except Exception as e:
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
    def updateTalent(self,heroid,userid,talent):
        try:
            if userid=='':
                VirusManager.VirusManager().addError('20006')
            else:
                if heroid=='':
                    VirusManager.VirusManager().addError('')
                else:
                    if talent=='':
                        VirusManager.VirusManager().addError('20005')
                    else:
                        cur=dba.dba().excute('select userID from hero where heroID='+"'"+heroid+"'")
                        for row in cur.fetchall():
                            if str(row[0])==userid:
                                curs=dba.dba().excute('update hero set talent=+"'+talent+'"where userID='+"'"+userid+"'")
                                print('执行成功')
        except Exception as e:
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
            print(e)
    def deleteHero(self,id):
        try:
            if id=='':
                VirusManager.VirusManager().addError('20002')
            else:
                cur=dba.dba().excute('delete FROM hero WHERE id='+"'"+id+"'")
        except Exception as e:
            #print('s8')
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
    def getUserHero(self,userid):
        try:
            if userid=='':
                VirusManager.VirusManager().addError('20006')
            else:
                cur=dba.dba().excute('select heroID from hero where userID='+"'"+userid+"'")
                for row in cur.fetchall():
                    return row[0]
        except Exception as e:
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
    def getSkill(self,heroid,userid):
        try:
            if heroid=='':
                VirusManager.VirusManager().addError('20002')           #print('s2')
            else:
                if userid=='':
                    VirusManager.VirusManager().addError('20006')
                else:
                    cur=dba.dba().excute('select userID from hero where heroID='+"'"+str(heroid)+"'")
                    for row in cur.fetchall():
                        if str(row[0])==str(userid):
                            curs=dba.dba().excute('select * from hero where userID='+"'"+str(row[0])+"'")
                            for row in curs.fetchall():
                                 return row[5]+','+row[6]+','+row[7]+','+row[8]+','+row[9]
        except Exception as e:
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
    def addSkill(self,heroid,userid,skillid,num):
        try:
            if skillid=='':
                VirusManager.VirusManager().addError('')
            else:
                if num=='':
                    VirusManager.VirusManager().addError('')
                else:
                    if heroid=='':
                        VirusManager.VirusManager().addError('')
                    else:
                        if userid=='':
                            VirusManager.VirusManager().addError('')
                        else:
                            cur=dba.dba().excute('select userID from hero where heroID='+"'"+heroid+"'")
                            for row in cur.fetchall():
                                if str(row[0])==userid:
                                    if num==1:
                                        curs=dba.dba().excute('update hero set skill1=+"'+skillid+'"where userID='+"'"+str(row[0])+"'")
                                    if num==2:
                                        curs=dba.dba().excute('update hero set skill2=+"'+skillid+'"where userID='+"'"+str(row[0])+"'")
                                    if num==3:
                                        curs=dba.dba().excute('update hero set skill3=+"'+skillid+'"where userID='+"'"+str(row[0])+"'")
                                    if num==4:
                                        curs=dba.dba().excute('update hero set skill4=+"'+skillid+'"where userID='+"'"+str(row[0])+"'")
                                    if num==5:
                                        curs=dba.dba().excute('update hero set skill5=+"'+skillid+'"where userID='+"'"+str(row[0])+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('22222')
            VirusManager.VirusManager().addError(e)
if __name__ == '__main__':
    uu=Hero()
    #uu.getSkill('0','2')
    uu.updateTalent('1','3','nibaba')
    #uu.getTalent('0','2')
    #uu.getHero)ID('1')
    #uu.updateTalent('3','123545')
    #uu.deleteHero('2')
    #uu.showHero()
    #uu.addHero('2','b','ss','3')
    #uu.getHeroName('3')
    #VirusManager.VirusManager().addError('12345')
    #uu.addHero('4','b','sun',10,'da','2')
    #uu.deleteHero('1')
    #uu.getHeroID('2')
    #uu.getHeroName('2')
    #uu.showHero()
    #uu.updateHeroSkill('3','erzi')
    #uu.updateHeroLevel('2','100')
