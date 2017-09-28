from models import dba
from Manager import VirusManager
import os
class fileTable():
    def __init__(self):
        pass

    def getFile(self,id):
        try:
            if id=='':
                VirusManager.VirusManager().addError('100000')
            else:
                cur=dba.dba().excute('select * from filetable where id='+"'"+str(id)+"'")
                for row in cur.fetchall():
                    return row[1]+'|'+row[2]+'|'+row[3]
        except Exception as e:
            VirusManager.VirusManager().addError('101111')
            VirusManager.VirusManager().addError(e)

    def getRealFile(self,id):
        try:
            if id=='':
                VirusManager.VirusManager().addError('100000')
            else:
                cur=dba.dba().excute('select * from filetable where id='+"'"+str(id)+"'")
                for row in cur.fetchall():
                    return row[1]+'|'+row[4]+'|'+row[3]
        except Exception as e:
            VirusManager.VirusManager().addError('101111')
            VirusManager.VirusManager().addError(e)

    def readFile(self,id):
        try:
            if id=='':
                VirusManager.VirusManager().addError('100000')
            else:
                file=self.getFile(id)
                fileatt=file.split('|')
                fg=open(fileatt[1]+fileatt[0]+'.'+fileatt[2],'r')
                row=fg.read()
                return row
                '''f.read(size)参数size表示读取的数量，如果size省略，则表示读所有的内容
                 f.readline()读取一行
                 f.readlines()读取所有的行到数组里面[line1,line2,...lineN]。在避免将所有文件内容加载到内存中。'''
        except Exception as e:
            VirusManager.VirusManager().addError('101111')
            VirusManager.VirusManager().addError(e)
    def getMaxVersion(self):
         try:
             cur=dba.dba().excute('select Max(id) as id FROM filetable')
             for row in cur.fetchall():
                 return row[0]
         except Exception as e:
             VirusManager.VirusManager().addError('101111')
             VirusManager.VirusManager().addError(e)
if __name__ == '__main__':
    f=fileTable()
    #f.getMaxVersion()
    f.getFile(1)
    #f.readFile('1')

