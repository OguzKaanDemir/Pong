using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class DataManager
{
    private static string m_ParentDirectory = Directory.GetParent(Application.dataPath).FullName;
    private static string m_FullPath = Path.Combine(m_ParentDirectory, "MatchesData.json");

    public static void SaveMatchData(string player1Name, int player1Score, string player2Name, int player2Score)
    {
        var matchList = LoadMatches();

        var player1 = new PlayerData(player1Name, player1Score);
        var player2 = new PlayerData(player2Name, player2Score);

        var newMatch = new MatchData(player1, player2);

        matchList.matches.Add(newMatch);

        var updatedJsonData = JsonUtility.ToJson(matchList, true);
        File.WriteAllText(m_FullPath, updatedJsonData);
    }

    public static MatchDataList GetMatchDataList()
    {
        var matchList = LoadMatches();

        if (matchList.matches.Count > 0)
            return matchList;

        return null;
    }

    private static MatchDataList LoadMatches()
    {
        if (File.Exists(m_FullPath))
        {
            string json = File.ReadAllText(m_FullPath);
            return JsonUtility.FromJson<MatchDataList>(json);
        }
        else
            return new MatchDataList();
    }

    [System.Serializable]
    public class MatchDataList
    {
        public List<MatchData> matches = new List<MatchData>();
    }

    [System.Serializable]
    public class MatchData
    {
        public PlayerData Player1;
        public PlayerData Player2;

        public MatchData(PlayerData player1, PlayerData player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public string Name;
        public int Score;

        public PlayerData(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}
