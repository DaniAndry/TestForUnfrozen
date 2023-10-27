using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

public class MissionParser
{
    public static List<MissionData> ParseMissionsFromCSV(TextAsset csvFile)
    {
        List<MissionData> missionsData = new List<MissionData>();

        string[] lines = csvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            MissionData missionData = ParseLine(lines[i]);
            missionsData.Add(missionData);
        }

        return missionsData;
    }

    private static MissionData ParseLine(string line)
    {
        string[] values = line.Split(';');

        MissionData data = new MissionData
        {
            Id = float.Parse(values[0], CultureInfo.InvariantCulture),
            Name = values[1],
            Description = values[2],
            Situation = values[3],
            Allies = values[4],
            Enemies = values[5],
            Unlock = values[6],
            HeroesToUnlock = ParseHeroesToUnlock(values[6]),
            Reward = values[7],
            RewardInfo = ParseReward(values[7]),
            xCoord = float.Parse(values[8], CultureInfo.InvariantCulture),
            yCoord = float.Parse(values[9], CultureInfo.InvariantCulture),
            MissionForUnlock = ParseMissionForUnlock(values[10]),
            MissionForBlock = ParseMissionForUnlock(values[11])
        };

        return data;
    }

    private static List<float> ParseMissionForUnlock(string missionForUnlockString)
    {
        List<float> missionIds = new List<float>();

        if (string.IsNullOrWhiteSpace(missionForUnlockString))
            return missionIds;

        string[] missionIdStrings = missionForUnlockString.Split(',');

        foreach (string missionIdStr in missionIdStrings)
        {
            if (float.TryParse(missionIdStr.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out float missionId))
            {
                missionIds.Add(missionId);
            }
        }

        return missionIds;
    }

    private static RewardInfo ParseReward(string rewardString)
    {
        RewardInfo rewardInfo = new RewardInfo();

        string[] parts = rewardString.Split(',');

        if (int.TryParse(parts[0].Trim(), out int defaultLevelChange))
        {
            rewardInfo.DefaultHeroLevelChange = defaultLevelChange;
        }

        Regex heroChangePattern = new Regex(@"(.*?)([-\s])(\d+)");

        for (int i = 1; i < parts.Length; i++)
        {
            Match match = heroChangePattern.Match(parts[i]);
            if (match.Success)
            {
                string heroName = match.Groups[1].Value.Trim();
                int heroLevelChange;

                if (int.TryParse(match.Groups[3].Value, out heroLevelChange))
                {
                    if (match.Groups[2].Value == "-")
                        heroLevelChange *= -1;

                    rewardInfo.SpecificHeroChanges[heroName] = heroLevelChange;
                }
            }
        }

        return rewardInfo;
    }


    private static List<string> ParseHeroesToUnlock(string unlockString)
    {
        List<string> heroes = new List<string>();

        if (string.IsNullOrWhiteSpace(unlockString))
            return heroes;

        string[] heroNames = unlockString.Split(',');

        foreach (string heroName in heroNames)
        {
            heroes.Add(heroName.Trim());
        }

        return heroes;
    }
}
