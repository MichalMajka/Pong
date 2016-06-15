using System;
using System.Collections.Generic;

public static class Scores {
    static Dictionary<Player, int> playerScore = new Dictionary<Player, int>();
    static GameScript gameScript;

    public static void PreparePlayers() {
        playerScore.Add(Player.PLAYER1, 0);
        playerScore.Add(Player.PLAYER2, 0);
    }

    public static void SetGameScript(GameScript script) {
        gameScript = script;
    }

    public static void PlayerScores(Player player) {
        playerScore[player] += 1;
        gameScript.EndGame();
    }

    public static void ResetTable() {
        List<Player> players = new List<Player>(playerScore.Keys);
        foreach(Player player in players) {
            playerScore[player] = 0;
        }
    }

    public static int GetPlayerScore(Player player) {
        return playerScore[player];
    }
}

