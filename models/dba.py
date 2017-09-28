import  pymysql
import  pymysql.cursors
import multiprocessing
class dba:
    _connection=''
    _cursor=''
    mutex=multiprocessing.Lock()
    dbaInstance=None
    def __new__(cls):
        cls.mutex.acquire()
        if cls.dbaInstance is None:
            cls.dbaInstance = super(dba, cls).__new__(cls)
        cls.mutex.release()
        return cls.dbaInstance

    def _getConn(self):
        if self._connection=='':
                self._connection=pymysql.connect(host='123.206.74.177',
                                       user='syf',
                                       password='syf123456',
                                       db='virus',
                                       port=3306)
        return self._connection

    def _getCursor(self):
        if self._cursor=='':
            self._cursor=self._getConn().cursor()
        return self._cursor

    def excute(self,sql):
        self._getCursor().execute(sql)
        self._getConn().commit()
        return self._getCursor()
