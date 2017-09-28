from Manager import Player
from Manager import VirusManager
def login(randomID,mess,dbi):
    mes=mess.split(',')
    try:
        if mess=='':
            VirusManager.VirusManager().addError('11000')
        else:
            if mes[0]=='':
                VirusManager.VirusManager().addError('11001')
            else:
                if mes[1]=='':
                    VirusManager.VirusManager().addError('11002')
                else:
                    result=dbi.user.checkPassword(mes[0],mes[1])
                    if result=='true':
                        dbi.usermap.addUserMap(randomID,mes[0])
                        return '000101'
                    else:
                        return '000102'
    except Exception as e:
        VirusManager.VirusManager().addError('11999')
        VirusManager.VirusManager().addError(e)
def matchBattle(randomID,mess,dbi):
    try:
        if randomID=='':
            VirusManager.VirusManager.addError('12000')
        else:
            if mess=='':
                VirusManager.VirusManager.addError('12001')
            else:
                mes=mess.split(',')
                if mes[0]=='':
                    VirusManager.VirusManager().addError('')
                else:
                    if mes[1]=='':
                        VirusManager.VirusManager.addError('')
                    else:
                        num=dbi.combatmatch.getmaxID()
                        if num==None:
                            idnum=1
                        else:
                            idnum=num+1
                        dbi.combatmatch.addMatcher(idnum,randomID,mes[0],mes[1])
    except Exception as e:
        VirusManager.VirusManager().addError('12999')
        VirusManager.VirusManager().addError(e)
def addPlayerNews(randomID,mess,dbi):
    try:
        if randomID=='':
            VirusManager.VirusManager().addError('13000')
        else:
            if mess=='':
                VirusManager.VirusManager().addError('13001')
            else:
                mes=mess.split(',')
                if mes[0]=='':
                    VirusManager.VirusManager.addError('13002')
                else:
                    if mes[1]=='':
                        VirusManager.VirusManager().addError('13003')
                    else:
                        news=randomID+','+mes[1]+' '
                        dbi.combatnews.addNews(mes[0],news)
    except Exception as e:
        VirusManager.VirusManager().addError('13999')
        VirusManager.VirusManager().addError(e)
def getValidateVersion(randomID,mess,dbi):
    try:
        if randomID=='':
            VirusManager.VirusManager().addError('14000')
        else:
            if mess=='':
                VirusManager.VirusManager().addError('14001')
            else:
                maxVerson=dbi.filetable.getMaxVersion()
                if maxVerson:
                    maxVersonstr=str(maxVerson)
                else:
                    maxVersonstr='0'
                if maxVersonstr==mess:
                    return '200101'
                else:
                    return '200102'+'|'+maxVersonstr
    except Exception as e:
        VirusManager.VirusManager().addError('14999')
        VirusManager.VirusManager().addError(e)
def sendVersionFile(randomID,mess,dbi):
    try:
        if randomID=='':
            VirusManager.VirusManager().addError('15000')
        else:
            if mess=='':
                VirusManager.VirusManager().addError('15001')
            else:
                mes=int(mess)
                filenews=dbi.filetable.getRealFile(mes)
                row=dbi.filetable.readFile(mes)
                file='200202'+'|'+filenews+'|'+row
                return file
    except Exception as e:
        VirusManager.VirusManager().addError('15999')
        VirusManager.VirusManager().addError(e)
def talentSkill(randomID,mess,dbi):
    try:
        if randomID=='':
            VirusManager.VirusManager().addError()
        else:
            if mess=='':
                VirusManager.VirusManager().addError()
            else:
                mes=mess.split(',')
                if mes[0]=='':
                    VirusManager.VirusManager().addError()
                else:
                    if mes[1]=='':
                        VirusManager.VirusManager().addError()
                    else:
                        if mes[2]=='':
                            VirusManager.VirusManager().addError()
                        else:
                            if mes[3]=='':
                                VirusManager.VirusManager().addError()
                            else:
                                userid=dbi.usermap.getUserID(randomID)
                                herolevel=dbi.hero.getHerolevel(mes[0],userid)
                                num=int(mes[1])+int(mes[2])+int(mes[3])
                                if(herolevel):
                                    if int(herolevel)<num:
                                        return '300101'
                                    else:
                                        preskill=dbi.skillconfig.getPreskill(mes[1],mes[2],mes[3],mes[0],userid)
                                        needskill=dbi.skillconfig.getNeedskill(mes[0],userid)
                                        return '300102'+'|'+needskill+'|'+preskill
    except Exception as e:
        VirusManager.VirusManager().addError('')
        VirusManager.VirusManager().addError(e)
def reSelectSkill(randomID,mess,dbi):
    try:
        if randomID=='':
            VirusManager.VirusManager().addError('')
        else:
            if mess=='':
                VirusManager.VirusManager().addError('')
            else:
                userid=dbi.usermap.getUserID(randomID)
                dbi.hero.updateTalent(userid,'1|1|1')
                preskill='0001'+','+'0008'+','+'0020'
                return '300102'+'|'+''+'|'+preskill
    except Exception as e:
        VirusManager.VirusManager().addError('')
        VirusManager.VirusManager().addError(e)
def getSkill(randomID,mess,dbi):
    try:
        if randomID=='':
            VirusManager.VirusManager().addError('')
        else:
            if mess=='':
                VirusManager.VirusManager().addError('')
            else:
                userid=dbi.usermap.getUserID(randomID)
                skill=dbi.hero.getSkill(mess,userid)
                return '300202'+'|'+skill
    except Exception as e:
        VirusManager.VirusManager().addError('')
        VirusManager.VirusManager().addError(e)
def selectSkill(randomID,mess,dbi):#这里目前还是加了一个heroid， mess=heroid,skillid,num
    try:
        if randomID=='':
            VirusManager.VirusManager().addError('')
        else:
            if mess=='':
                VirusManager.VirusManager().addError('')
            else:
                mes=mess.split(',')
                if mes[0]=='':
                    VirusManager.VirusManager().addError('')
                else:
                    if mes[1]=='':
                        VirusManager.VirusManager().addError('')
                    else:
                        if mes[2]=='':
                            VirusManager.VirusManager().addError('')
                        else:
                            userid=dbi.usermap.getUserID(randomID)
                            skill=dbi.hero.addSkill(userid,mes[0],mes[1],mes[0])
                            if(skill):
                                return '300204'
                            else:
                                return '300205'
    except Exception as e:
        VirusManager.VirusManager().addError('')
        VirusManager.VirusManager().addError(e)

code={
        '000100':login,
        '100100':matchBattle,
        '100102':addPlayerNews,
        '200100':getValidateVersion,
        '200201':sendVersionFile,
        '300100':talentSkill,
        '300103':reSelectSkill,
        '300201':getSkill,
        '300203':selectSkill
    }