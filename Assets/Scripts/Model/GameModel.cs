using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameModel
{
    public AttributeGroup[] Attributes;

}
[Serializable]
public class AttributeGroup
{
    public string GroupTitle;
    public Attribute[] Attributes;
}
[Serializable]
public class Attribute
{
    public string Name;
    public int[] Costs;
    public bool Enabled = true;
}

[Serializable]
public class League
{
    public string Id;
    public string Name;
    public string Abbreviation;
    public string Season;
}

[Serializable]
public class Conference
{
    public string Id;
    public string League;
    public string Name;
    public string Season;
}

[Serializable]
public class Division
{
    public string Id;
    public string League;
    public string Conference;
    public string Name;
    public string Season;
}

[Serializable]
public class Team
{
    public string Id;
    public string League;
    public string Conference;
    public string Division;
    public string Name;
    public string Abbreviation;
    public string Location;
    public TeamColors Colors;
}

[Serializable]
public class TeamColors
{
    public string Primary;
    public string Secondary;
    public string Tertiary;
}

[Serializable]
public class PlayerData
{
    public string Id;
    public string Draft;
    public string Name;
    public string Team;
    public int Height;
    public int Weight;
    public string Birthplace;
    public string User;

}

[Serializable]
public class PlayerRecord
{
    public string Player;
    public string Position;
    public string League;
    public string Season;
    public string Team;
    public int GamesPlayed;
    public int TimeOnIce; //seconds
    public int Goals;
    public int Assists;
    public int Points; //goals plus assists
    public int PlusMinus;
    public int Pim;
    public int PPGoals;
    public int PPAssists;
    public int PPPoints;
    public int PPTimeOnIce;
    public int SHGoals;
    public int SHAssists;
    public int SHTimeOnIce;
    public int Fights;
    public int FightWins;
    public int FightLosses;
    public int Hits;
    public int Giveaways;
    public int Takeaways;
    public int ShotsBlocked;
    public int ShotsOnGoal;
    public int GameRating;
    public int OffensiveGameRating;
    public int DefensiveGameRating;
}

public class PlayerRatings
{
    public string Player; //id;
    public PlayerAttribute[] PlayerAttributes;
}

public class PlayerAttribute
{
    public string Name; //should be equal to an Attribute name;
    public int Value;
}
