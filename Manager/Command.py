class Command:
    def __init__(self):
        print('命令模式开启')

    def _help(self):
        print('输入help\n')

    def getInput(self):
        while(1):
            command=input("in")
            print(command)
            if(command=='help'):
                self._help()

