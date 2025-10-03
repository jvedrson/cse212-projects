/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    // Your goal is to write a program that will determine the total number of points scored by a player over all the years that they played, and then summarize this in a table showing the top 10 players with the highest total points scored.
    // Add logic to this program to use a Map to determine the total points for each player.
    // Once you have built the map you can convert it to an array, sort it, and then display the top 10 players with the highest point total.
    // When you are done, compare your approach to the one in the BasketballSolution.cs file and discuss it together.

    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId))
            {
                players[playerId] = players[playerId] + points;
            }
            else
            {
                players.Add(playerId, points);
            }
        }

        // Solution #1
        var topPlayers = players.OrderByDescending(p => p.Value).ToArray();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{topPlayers[i].Key} - {topPlayers[i].Value}");
        }

        // Solution #2
        // var topPlayers = players.ToArray();

        // Array.Sort(topPlayers, (player1, player2) => player2.Value - player1.Value);

        // for (int i = 0; i < 10; i++)
        // {
        //     Console.WriteLine($"{topPlayers[i].Key} - {topPlayers[i].Value}");
        // }
    }
}