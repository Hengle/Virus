from models import dba
from Manager import VirusManager
class Item():
    def __init__(self):
        pass
    def getItemID(self,id):
        try:
            if id=='':
                VirusManager.VirusManager().addError('30001')
            else:
                cur=dba.dba().excute('select itemID from item where id='+"'"+id+"'")
                for row in cur.fetchall():
                    return row[0]
        except Exception as e:
            VirusManager.VirusManager().addError('33333')
            VirusManager.VirusManager().addError(e)
    def getItemNumber(self,itemid):
         try:
            if itemid=='':
                VirusManager.VirusManager().addError('30002')
            else:
                cur=dba.dba().excute('select itemNumber from item where itemID='+"'"+itemid+"'")
                for row in cur.fetchall():
                    return row[0]
         except Exception as e:
             VirusManager.VirusManager().addError('33333')
             VirusManager.VirusManager().addError(e)
    def updateItemNumber(self,itemid,itemnumber):
        try:
            if itemid=='':
                VirusManager.VirusManager().addError('30002')
            else:
                if itemnumber=='':
                    VirusManager.VirusManager().addError('30003')
                else:
                    cur=dba.dba().excutecur=dba.dba().excute('update item set itemNumber="'+str(itemnumber)+'"where itemID='+"'"+itemid+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('33333')
            VirusManager.VirusManager().addError(e)
    def addItem(self,id,itemid,itemnumber,userid):
       try:
            if id=='':
                VirusManager.VirusManager().addError('30001')
            else:
                if itemid=='':
                    VirusManager.VirusManager().addError('30002')
                else:
                    if itemnumber=='':
                        VirusManager.VirusManager().addError('30003')
                    else:
                        if userid=='':
                            VirusManager.VirusManager().addError('30004')
                        else:
                            cur=dba.dba().excute("insert into item(id,itemID,itemNumber,userID) VALUE ('"+str(id)+"','"+str(itemid)+"','"+str(itemnumber)+"','"+str(userid)+"')")
       except Exception as e:
            VirusManager.VirusManager().addError('33333')
            VirusManager.VirusManager().addError(e)
    def deleteItem(self,id):
        try:
            if id=='':
                VirusManager.VirusManager().addError('30001')
            else:
                #print(userid)
                cur=dba.dba().excute('delete from item where id='+"'"+id+"'")
        except Exception as e:
            VirusManager.VirusManager().addError('33333')
            VirusManager.VirusManager().addError(e)
if __name__ == '__main__':
    u=Item()
    #u.getItemID('1')
    #u.getItemNumber('44')
    #u.addItem('2','a',66,'3')
    #u.deleteItem('1')