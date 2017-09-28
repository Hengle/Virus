from models import dba
from Manager import VirusManager
from Manager import DBI
class SkillConfig():
    def __init__(self):
        pass
    def getSkill(self,skillid):
        try:
            if skillid=='':
                VirusManager.VirusManager().addError('60001')
            else:
                cur=dba.dba().excute('select * from skillconfig where skillID='+"'"+skillid+"'")
                for row in cur.fetchall():
                    return row[1]
        except Exception as e:
            VirusManager.VirusManager().addError('66666')
            VirusManager.VirusManager().addError(e)
    '''def addSkill(self,skillid,skillname,heroid):
        try:
            if skillid=='':
                VirusManager.VirusManager().addError('60001')
            else:
                if skillname=='':
                    VirusManager.VirusManager().addError('60002')
                else:
                    if heroid=='':
                        VirusManager.VirusManager().addError('60003')
                    else:
                        cur=dba.dba().excute("insert into skillconfig(skillID,skillDesc,heroID) VALUE ('"+str(skillid)+"','"+str(skillname)+"','"+str(heroid)+"')")
        except Exception as e:
            VirusManager.VirusManager().addError('66666')
            VirusManager.VirusManager().addError(e)'''
    '''def updateShillDepict(self,skillid,skilldesc):
        try:
            if skillid=='':
                VirusManager.VirusManager().addError('60001')
            else:
                if skilldesc=='':
                    VirusManager.VirusManager().addError('60002')
                else:
                    cur=dba.dba().excute('update skillconfig set skillDesc="'+str(skilldesc)+'" where skillID='+"'"+skillid+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('66666')
            VirusManager.VirusManager().addError(e)'''''
    def getPreskill(self,a,b,c,heroid,userid):
        try:
            if a=='':
                VirusManager.VirusManager().addError('')
            else:
                if b=='':
                    VirusManager.VirusManager().addError('')
                else:
                    if c=='':
                        VirusManager.VirusManager().addError('')
                    else:
                        if heroid=='':
                            VirusManager.VirusManager().addError('')
                        else:
                            if userid=='':
                                VirusManager.VirusManager().addError('')
                            else:
                                talent=DBI.DBI().hero.getTalent(heroid,userid)
                                tal=talent.split('|')
                                num1=int(a)+int(tal[0])
                                num2=int(b)+int(tal[1])
                                num3=int(c)+int(tal[2])
                                rows=''
                                cur=dba.dba().excute('select skillID from skillconfig where preSkill1<='+"'"+str(num1)+"'" 'and preSkill2<='+"'"+str(num2)+"'"'and preSkill3<='+"'"+str(num3)+"'")
                                for row in cur.fetchall():
                                    rows=rows+str(row[0])+','
                                return rows
        except Exception as e:
            VirusManager.VirusManager().addError('66666')
            VirusManager.VirusManager().addError(e)
    def getNeedskill(self,heroid,userid):
        try:
            if heroid=='':
                VirusManager.VirusManager().addError('')
            else:
                if userid=='':
                    VirusManager.VirusManager().addError('')
                else:
                    level=DBI.DBI().hero.getHerolevel(heroid,userid)
                    array=['1','3','6','10','15','21','28']
                    talent=DBI.DBI().hero.getTalent(heroid,userid)
                    tal=talent.split('|')
                    ss=''
                    if array.index(tal[0])<6:
                        a=array[array.index(tal[0])+1]
                        str1=self.getPreskill(str(int(a)-int(tal[0])),'0','0',heroid,userid)
                        str2=self.getPreskill('0','0','0',heroid,userid)
                        strs1=str1.split(',')
                        strs2=str2.split(',')
                        strs1.sort()
                        strs2.sort()
                        strs1.remove('')
                        strs2.remove('')
                        for st in strs2:
                            if st in strs1:
                                strs1.remove(st)
                        for st in strs1:
                            ss+=st+','
                    if array.index(tal[1])<6:
                        a=array[array.index(tal[1])+1]
                        str1=self.getPreskill('0',str(int(a)-int(tal[1])),'0',heroid,userid)
                        str2=self.getPreskill('0','0','0',heroid,userid)
                        strs1=str1.split(',')
                        strs2=str2.split(',')
                        strs1.remove('')
                        strs2.remove('')
                        strs1.sort()
                        strs2.sort()
                        for st in strs2:
                            if st in strs1:
                                strs1.remove(st)
                        for st in strs1:
                            ss+=st+','
                    if array.index(tal[2])<6:
                        a=array[array.index(tal[2])+1]
                        str1=self.getPreskill('0','0',str(int(a)-int(tal[2])),heroid,userid)
                        str2=self.getPreskill('0','0','0',heroid,userid)
                        strs1=str1.split(',')
                        strs2=str2.split(',')
                        strs1.remove('')
                        strs2.remove('')
                        strs1.sort()
                        strs2.sort()
                        for st in strs2:
                            if st in strs1:
                                strs1.remove(st)
                        for st in strs1:
                            ss+=st+','
                    return ss

        except Exception as e:
            print (e)
            VirusManager.VirusManager().addError('66666')
            VirusManager.VirusManager().addError(e)
    def deleteSkill(self,skillid):
        try:
            if skillid=='':
                VirusManager.VirusManager().addError('60001')
            else:
                cur=dba.dba().excute('delete from skillconfig where skillID='+"'"+skillid+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('66666')
            VirusManager.VirusManager().addError(e)
    def getUserHeroSkill(self,heroid):
        try:
            if heroid=='':
                VirusManager.VirusManager().addError('60003')
            else:
                cur=dba.dba().excute('select * from skillconfig where heroID='+"'"+heroid+"'")
                for row in cur.fetchall():
                    return row[0]+','+row[1]
        except Exception as e:
            VirusManager.VirusManager().addError('66666')
            VirusManager.VirusManager().addError(e)

if __name__ == '__main__':
    s=SkillConfig()
    s.getNeedskill('0','2')
    #s.getPreskill('10','0','0')
    #s.getSkill('lee')
    #s.addSkill('fee','your','c')
