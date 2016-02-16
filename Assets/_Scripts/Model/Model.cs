using UnityEngine;
using System.Collections;

namespace Model {

    /// <summary>
    /// 玩家信息
    /// </summary>
    public class User
    {
        public int ID;
        public string UserName;
        public string PassWord;
    }

    public class PlayerInfo
    {
        public int Coin;
        public int Diamond;
        public int Exp;
        public int Name;
        public int Level;
    }

    public class Good
    {
        public int ID;
        public string Icon;
        public string Name;
        public int Level;
        public int Rank;
        public bool IsBinding;
        public int Price;
    }

    public class Prop
    {
        public int ID;
        public int Count;
        public string Des;
        public string Access;
        public bool CanUse;
        public int UseBonusID;
    }

    public class Equip
    {
        public int ID;
        public int HeroType;
        public int Position;
        public string BasicAttribute;
    }

    public class Skill
    {
        public int ID;
        public int Level;
        public string Name;
        public string Des;
    }

}
