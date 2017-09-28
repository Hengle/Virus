from models import dba
from Manager import VirusManager
class User():
    user=''
    password=''
    def __init__(self):
        pass
    def setUser(self,user,password):
        self.user=user
        self.password=password
    def checkPassword(self,userid,userpassward):
        try:
            if userid=='':
                VirusManager.VirusManager().addError('10001')
            else:
                if userpassward=='':
                    VirusManager.VirusManager().addError('10003')
                else:
                    cur=dba.dba().excute('select userPassward from user where userID='+"'"+userid+"'")
                    for row in cur.fetchall():
                        if row[0]==userpassward:
                            return 'true'
                        else :
                            return 'false'
        except Exception as e:
            VirusManager.VirusManager().addError('11111')
            VirusManager.VirusManager().addError(e)
    def  getCoin(self,userid):
        try:
            if userid=='':
                VirusManager.VirusManager().addError('10001')
            else:
                cur=dba.dba().excute('select userCoin from user where userID='+"'"+userid+"'")
                for row in cur.fetchall():
                        return row[0]
        except Exception as e:
            VirusManager.VirusManager().addError('11111')
            VirusManager.VirusManager().addError(e)
    def showUsers(self):
        try:
            cur=dba.dba().excute('select * from user')
            for row in cur.fetchall():
                return str(row)
        except Exception as e:
            VirusManager.VirusManager().addError('11111')
            VirusManager.VirusManager().addError(e)
    def updateCoin(self,userid,usercoin):
        try:
            if userid =='':
                VirusManager.VirusManager().addError('10001')
            else:
                if usercoin=='':
                    VirusManager.VirusManager().addError('10004')
                else:
                    cur=dba.dba().excute('update user set userCoin=usercoin where userID='+"'"+userid+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('11111')
            VirusManager.VirusManager().addError(e)
    def deleteUser(self,userid):
        try:
            if userid=='':
                VirusManager.VirusManager().addError('10001')
            else:
                #print(userid)
                cur=dba.dba().excute('delete from user where userID='+"'"+userid+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('11111')
            VirusManager.VirusManager().addError(e)
    def addUser(self,userid,username,userpassward,usercoin):
        try:
            if userid=='':
                VirusManager.VirusManager().addError('10001')
            else:
                if username=='':
                    VirusManager.VirusManager().addError('10002')
                else:
                    if userpassward=='':
                        VirusManager.VirusManager().addError('10003')
                    else:
                        if usercoin=='':
                            VirusManager.VirusManager().addError('10004')
                        else:
                            cur=dba.dba().excute("insert into user(userID,userName,userPassward,userCoin) VALUE ('"+str(userid)+"','"+str(username)+"','"+str(userpassward)+"','"+str(usercoin)+"')")
        except Exception as e:
            VirusManager.VirusManager().addError('11111')
            VirusManager.VirusManager().addError(e)

if __name__ == '__main__':
    u=User()
    #u.getCoin('2')
    #u.addUser('2','sun','123',50)
    #u.showUsers()
    #u.deleteUser('1')
    #u.updateCoin('3',60)
    #u.checkPassword('3','123')
    #cur=u.excute('select * from User')
    #for row in cur.fetchall():
        #print(row[0])

