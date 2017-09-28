from models import User
from models import HeroConfig
from models import Hero
from models import UserMap
from models import SkillConfig
from models import Item
from models import Setting
from models import CombatMatch
from models import CombatNews
from models import fileTable
import multiprocessing
class DBI:
    user=None
    combatmatch=None
    combatnews=None
    usermap=None
    hero=None
    item=None
    heroconfig=None
    setting=None
    skillconfig=None
    filetable=None
    mutex=multiprocessing.Lock()
    dbiInstance=None
    def __new__(cls):
        cls.mutex.acquire()
        if cls.dbiInstance is None:
            cls.user=User.User()
            cls.combatmatch=CombatMatch.CombatMatch()
            cls.combatnews=CombatNews.CombatNews()
            cls.usermap=UserMap.UserMap()
            cls.hero=Hero.Hero()
            cls.item=Item.Item()
            cls.heroconfig=HeroConfig.HeroConfig()
            cls.setting=Setting.Setting()
            cls.skillconfig=SkillConfig.SkillConfig()
            cls.filetable=fileTable.fileTable()
            cls.dbiInstance = super(DBI, cls).__new__(cls)
        cls.mutex.release()
        return cls.dbiInstance
