from Manager import VirusManager
import time
class Wrong:
    _file=''
    _fileObject=''
    _errorDict={}
    def __init__(self,file='error.txt'):
        try:
            self._file=file
            self._fileObject=open(self._file,'a')
            print('错误信息文件打开成功')
        except :
            VirusManager.VirusManager().addError('错误信息文件打开失败')
            print('错误信息文件打开失败')

    def __del__(self):
        for err in self._errorDict.values():
            self._fileObject.writelines(str(err))
            self._fileObject.writelines('\n')
        self._fileObject.flush()
        self._fileObject.close()
        print('关闭错误信息文本')

    def addError(self,error):
        self._errorDict[time.time]=error
        if(len(self._errorDict)>0):
            self._fileObject.writelines(str(time.time()))
            self._fileObject.writelines('\n')
            for err in self._errorDict.values():
                self._fileObject.writelines(str(err))
                self._fileObject.writelines('\n')
            self._fileObject.flush()
            self._errorDict.clear()
