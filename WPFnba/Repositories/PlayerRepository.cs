using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using WPFnba;

/// <summary>
/// Repository class for handling CRUD operations on the Player entity.
/// </summary>
public class PlayerRepository
{
    private DataContext dataContext;
    private DataTable player_dt;
    private DataTable playerData_dt;
    private DataTable playerStats_dt;
    private DataTable teamPlayers_dt;

    /// <summary>
    /// Constructor to initialize the data context.
    /// </summary>
    public PlayerRepository()
    {
        dataContext = Database.GetContext();
        DataTable player_dt = new DataTable();
        DataTable teamPlayers_dt = new DataTable();
        DataTable playerData_dt = new DataTable();
        DataTable playerStats_dt = new DataTable();
    }

    /// <summary>
    /// Inserts a new player into the database.
    /// </summary>
    /// <param name="playerData">A list of strings containing player data.</param>
    public void InsertPlayer(List<string> playerData)
    {
        if (playerData == null || playerData.Count < 19)
        {
            throw new ArgumentException("Invalid player data provided.");
        }

        Player player = new Player();
        for (int i = 0; i < playerData.Count; i++)
        {
            switch (i)
            {
                case 0:
                    player.Id = int.Parse(playerData[i]);
                    break;
                case 1:
                    player.FirstName = playerData[i];
                    break;
                case 2:
                    player.LastName = playerData[i];
                    break;
                case 3:
                    player.Team = playerData[i];
                    break;
                case 4:
                    player.Position = playerData[i];
                    break;
                case 5:
                    player.JerseyNumber = playerData[i];
                    break;
                case 6:
                    player.Age = playerData[i];
                    break;
                case 7:
                    player.DateOfBirth = playerData[i];
                    break;
                case 8:
                    player.Height = playerData[i];
                    break;
                case 9:
                    player.Weight = playerData[i];
                    break;
                case 10:
                    player.CareerPoints = string.IsNullOrEmpty(playerData[i]) ? 0 : decimal.Parse(playerData[i]);
                    break;
                case 11:
                    player.CareerBlocks = string.IsNullOrEmpty(playerData[i]) ? 0 : decimal.Parse(playerData[i]);
                    break;
                case 12:
                    player.CareerAssists = string.IsNullOrEmpty(playerData[i]) ? 0 : decimal.Parse(playerData[i]);
                    break;
                case 13:
                    player.CareerRebounds = string.IsNullOrEmpty(playerData[i]) ? 0 : decimal.Parse(playerData[i]);
                    break;
                case 14:
                    player.CareerTurnovers = string.IsNullOrEmpty(playerData[i]) ? 0 : decimal.Parse(playerData[i]);
                    break;
                case 15:
                    player.CareerPercentageThree = string.IsNullOrEmpty(playerData[i]) ? 0 : decimal.Parse(playerData[i]);
                    break;
                case 16:
                    player.CareerPercentageFreethrow = string.IsNullOrEmpty(playerData[i]) ? 0 : decimal.Parse(playerData[i]);
                    break;
                case 17:
                    player.CareerPercentageFieldGoal = string.IsNullOrEmpty(playerData[i]) ? 0 : decimal.Parse(playerData[i]);
                    break;
                case 18:
                    player.HeadShotUrl = playerData[i];
                    break;
                case 19:
                    player.DateLastUpdated = string.IsNullOrEmpty(playerData[i]) ? DateTime.Now.ToString() : playerData[i];
                    break;
            }
        }

        dataContext.GetTable<Player>().InsertOnSubmit(player);
        dataContext.SubmitChanges();
    }

    /// <summary>
    /// Updates an existing player in the database.
    /// </summary>
    /// <param name="playerData">A list of strings containing updated player data.</param>
    public bool UpdatePlayer(List<string> playerData)
    {
        if (playerData == null || playerData.Count < 19)
        {
            throw new ArgumentException("Invalid player data provided.");
        }

        try
        {

            player player = new player();
            for (int i = 0; i < playerData.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        player.id = int.Parse(playerData[i]);
                        break;
                    case 1:
                        player.firstName = playerData[i];
                        break;
                    case 2:
                        player.lastName = playerData[i];
                        break;
                    case 3:
                        player.team = playerData[i];
                        break;
                    case 4:
                        player.position = playerData[i];
                        break;
                    case 5:
                        player.jerseyNumber = playerData[i];
                        break;
                    case 6:
                        player.age = playerData[i];
                        break;
                    case 7:
                        player.dateOfBirth = playerData[i];
                        break;
                    case 8:
                        player.height = playerData[i];
                        break;
                    case 9:
                        player.weight = playerData[i];
                        break;
                    case 10:
                        player.careerPoints = decimal.Parse(playerData[i]);
                        break;
                    case 11:
                        player.careerBlocks = decimal.Parse(playerData[i]);
                        break;
                    case 12:
                        player.careerAssists = decimal.Parse(playerData[i]);
                        break;
                    case 13:
                        player.careerRebounds = decimal.Parse(playerData[i]);
                        break;
                    case 14:
                        player.careerTurnovers = decimal.Parse(playerData[i]);
                        break;
                    case 15:
                        player.careerPercentageThree = decimal.Parse(playerData[i]);
                        break;
                    case 16:
                        player.careerPercentageFreethrow = decimal.Parse(playerData[i]);
                        break;
                    case 17:
                        player.careerPercentageFieldGoal = decimal.Parse(playerData[i]);
                        break;
                    case 18:
                        player.headShotUrl = playerData[i];
                        break;
                    case 19:
                        player.dateLastUpdated = playerData[i];
                        break;
                }
            }

            player playerSearch = dataContext.GetTable<player>().First(p => p.id == player.id);
            foreach (var prop in player.GetType().GetProperties())
            {
                if (prop.Name != "id")
                {
                    prop.SetValue(playerSearch, prop.GetValue(player));
                }
            }

            dataContext.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return false;
        }
    }

    /// <summary>
    /// Deletes a player from the database.
    /// </summary>
    /// <param name="id">The ID of the player to delete.</param>
    public void DeletePlayer(int id)
    {
        Player player = dataContext.GetTable<Player>().First(p => p.Id == id);
        dataContext.GetTable<Player>().DeleteOnSubmit(player);
        dataContext.SubmitChanges();
    }

    /// <summary>
    /// Retrieves a player by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the player to retrieve.</param>
    /// <returns>The player object if found; otherwise, null.</returns>
    internal DataTable GetPlayer(int id)
    {
        try {
            // Search for the player by ID
            player player = dataContext.GetTable<player>().First(p => p.id == id);

            // Initialize DataTable if it is null
            if (player_dt == null)
            {
                player_dt = new DataTable();
                player_dt.Columns.Add("Id", typeof(int));
                player_dt.Columns.Add("FirstName", typeof(string));
                player_dt.Columns.Add("LastName", typeof(string));
                player_dt.Columns.Add("Team", typeof(string));
                player_dt.Columns.Add("Position", typeof(string));
                player_dt.Columns.Add("DateOfBirth", typeof(string));
                player_dt.Columns.Add("Height", typeof(string));
                player_dt.Columns.Add("Weight", typeof(string));
                player_dt.Columns.Add("JerseyNumber", typeof(string));
                player_dt.Columns.Add("Age", typeof(string));
                player_dt.Columns.Add("CareerPoints", typeof(decimal));
                player_dt.Columns.Add("CareerBlocks", typeof(decimal));
                player_dt.Columns.Add("CareerAssists", typeof(decimal));
                player_dt.Columns.Add("CareerRebounds", typeof(decimal));
                player_dt.Columns.Add("CareerTurnovers", typeof(decimal));
                player_dt.Columns.Add("CareerPercentageThree", typeof(decimal));
                player_dt.Columns.Add("CareerPercentageFreethrow", typeof(decimal));
                player_dt.Columns.Add("CareerPercentageFieldGoal", typeof(decimal));
                player_dt.Columns.Add("HeadShotUrl", typeof(string));
                player_dt.Columns.Add("DateLastUpdated", typeof(DateTime));
            }
            // Clear the DataTable if it is not null
            else
            {
                player_dt.Rows.Clear();
            }

            // Convert the player to a DataTable
            player_dt.Rows.Add(
                    player.id,
                    player.firstName,
                    player.lastName,
                    player.team,
                    player.position,
                    player.dateOfBirth,
                    player.height,
                    player.weight,
                    player.jerseyNumber,
                    player.age,
                    player.careerPoints,
                    player.careerBlocks,
                    player.careerAssists,
                    player.careerRebounds,
                    player.careerTurnovers,
                    player.careerPercentageThree,
                    player.careerPercentageFreethrow,
                    player.careerPercentageFieldGoal,
                    player.headShotUrl,
                    player.dateLastUpdated
            );

            return player_dt;
        }
        catch (Exception e)
        {
            return null;
        }
    }


    /// <summary>
    /// Retrieves player data by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the player to retrieve.</param>
    /// <returns>The player data object if found; otherwise, null.</returns>
    internal DataTable GetPlayerData(int id)
    {
        try
        {
            // Search for the player by ID
            player player = dataContext.GetTable<player>().First(p => p.id == id);

            // Initialize DataTable if it is null
            if (playerData_dt == null)
            {
                playerData_dt = new DataTable();
                playerData_dt.Columns.Add("Id", typeof(int));
                playerData_dt.Columns.Add("FirstName", typeof(string));
                playerData_dt.Columns.Add("LastName", typeof(string));
                playerData_dt.Columns.Add("Team", typeof(string));
                playerData_dt.Columns.Add("Position", typeof(string));
                playerData_dt.Columns.Add("DateOfBirth", typeof(string));
                playerData_dt.Columns.Add("Height", typeof(string));
                playerData_dt.Columns.Add("Weight", typeof(string));
                playerData_dt.Columns.Add("JerseyNumber", typeof(string));
                playerData_dt.Columns.Add("Age", typeof(string));
            }
            // Clear the DataTable if it is not null
            else
            {
                playerData_dt.Rows.Clear();
            }

            // Convert the player to a DataTable
            playerData_dt.Rows.Add(
                    player.id,
                    player.firstName,
                    player.lastName,
                    player.team,
                    player.position,
                    player.dateOfBirth,
                    player.height,
                    player.weight,
                    player.jerseyNumber,
                    player.age
            );

            return playerData_dt;
        }
        catch (Exception e)
        {
            return null;
        }
    }


    /// <summary>
    /// Retrieves a player stats by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the player to retrieve.</param>
    /// <returns>The player stats object if found; otherwise, null.</returns>
    internal DataTable GetPlayerStats(int id)
    {
        try
        {
            // Search for the player by ID
            player player = dataContext.GetTable<player>().First(p => p.id == id);

            // Initialize DataTable if it is null
            if (playerStats_dt == null)
            {
                playerStats_dt = new DataTable();
                playerStats_dt.Columns.Add("CareerPoints", typeof(decimal));
                playerStats_dt.Columns.Add("CareerBlocks", typeof(decimal));
                playerStats_dt.Columns.Add("CareerAssists", typeof(decimal));
                playerStats_dt.Columns.Add("CareerRebounds", typeof(decimal));
                playerStats_dt.Columns.Add("CareerTurnovers", typeof(decimal));
                playerStats_dt.Columns.Add("CareerPercentageThree", typeof(decimal));
                playerStats_dt.Columns.Add("CareerPercentageFreethrow", typeof(decimal));
                playerStats_dt.Columns.Add("CareerPercentageFieldGoal", typeof(decimal));
            }
            // Clear the DataTable if it is not null
            else
            {
                playerStats_dt.Rows.Clear();
            }

            // Convert the player to a DataTable
            playerStats_dt.Rows.Add(
                    player.careerPoints,
                    player.careerBlocks,
                    player.careerAssists,
                    player.careerRebounds,
                    player.careerTurnovers,
                    player.careerPercentageThree,
                    player.careerPercentageFreethrow,
                    player.careerPercentageFieldGoal
            );

            return playerStats_dt;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    /// <summary>
    /// Retrieves all players belonging to a specific team by team name.
    /// </summary>
    /// <param name="teamName">The name of the team.</param>
    /// <returns>A DataTable containing all players from the specified team.</returns>
    internal DataTable GetPlayersByTeam(int teamId)
    {
        try
        {
            // Search for the team by ID
            team team = dataContext.GetTable<team>().First(t => t.id == teamId);

            // Search for players belonging to the specified team
            List<player> teamPlayers = dataContext.GetTable<player>()
                .Where(p => p.team == team.name)
                .OrderBy(p => p.position)
                .ThenBy(p => p.lastName)
                .ToList();

            // Initialize DataTable if it is null
            if (teamPlayers_dt == null)
            {
                teamPlayers_dt = new DataTable();
                teamPlayers_dt.Columns.Add("Id", typeof(int));
                teamPlayers_dt.Columns.Add("FirstName", typeof(string));
                teamPlayers_dt.Columns.Add("LastName", typeof(string));
                teamPlayers_dt.Columns.Add("Team", typeof(string));
                teamPlayers_dt.Columns.Add("Position", typeof(string));
                teamPlayers_dt.Columns.Add("DateOfBirth", typeof(string));
                teamPlayers_dt.Columns.Add("Height", typeof(string));
                teamPlayers_dt.Columns.Add("Weight", typeof(string));
                teamPlayers_dt.Columns.Add("JerseyNumber", typeof(string));
                teamPlayers_dt.Columns.Add("Age", typeof(string));
                teamPlayers_dt.Columns.Add("CareerPoints", typeof(decimal));
                teamPlayers_dt.Columns.Add("CareerBlocks", typeof(decimal));
                teamPlayers_dt.Columns.Add("CareerAssists", typeof(decimal));
                teamPlayers_dt.Columns.Add("CareerRebounds", typeof(decimal));
                teamPlayers_dt.Columns.Add("CareerTurnovers", typeof(decimal));
                teamPlayers_dt.Columns.Add("CareerPercentageThree", typeof(decimal));
                teamPlayers_dt.Columns.Add("CareerPercentageFreethrow", typeof(decimal));
                teamPlayers_dt.Columns.Add("CareerPercentageFieldGoal", typeof(decimal));
                teamPlayers_dt.Columns.Add("HeadShotUrl", typeof(string));
                teamPlayers_dt.Columns.Add("DateLastUpdated", typeof(DateTime));
            }
            // Clear the DataTable if it is not null
            else
            {
                teamPlayers_dt.Rows.Clear();
            }

            // Convert the list of players to a DataTable
            foreach (player p in teamPlayers)
            {
                teamPlayers_dt.Rows.Add(
                    p.id,
                    p.firstName,
                    p.lastName,
                    p.team,
                    p.position,
                    p.dateOfBirth,
                    p.height,
                    p.weight,
                    p.jerseyNumber,
                    p.age,
                    p.careerPoints,
                    p.careerBlocks,
                    p.careerAssists,
                    p.careerRebounds,
                    p.careerTurnovers,
                    p.careerPercentageThree,
                    p.careerPercentageFreethrow,
                    p.careerPercentageFieldGoal,
                    p.headShotUrl,
                    p.dateLastUpdated
                );
            }

            // Return the DataTable
            return teamPlayers_dt;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return null;
        }
    }
}