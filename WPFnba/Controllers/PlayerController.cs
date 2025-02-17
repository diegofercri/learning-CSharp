using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Controller class for handling player-related operations.
/// </summary>
public class PlayerController
{
    private PlayerRepository playerRepository;

    /// <summary>
    /// Constructor to initialize the player repository.
    /// </summary>
    public PlayerController(PlayerRepository repository)
    {
        playerRepository = repository;
    }

    /// <summary>
    /// Adds a new player to the database.
    /// </summary>
    /// <param name="playerData">A list of strings containing player data.</param>
    public bool AddPlayer(List<string> playerData)
    {
        if (playerData == null || playerData.Count < 19)
        {
            throw new ArgumentException("Invalid player data provided.");
        }

        try
        {
            int nextId = playerRepository.GetNextId();

            playerData.Insert(0, nextId.ToString());

            return playerRepository.InsertPlayer(playerData);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return false;
        }
    }

    /// <summary>
    /// Updates an existing player in the database.
    /// </summary>
    /// <param name="playerData">A list of strings containing updated player data.</param>
    internal bool UpdatePlayer(List<string> playerData)
    {
        // Llamar al método del repositorio para actualizar el jugador
        return playerRepository.UpdatePlayer(playerData);
    }

    /// <summary>
    /// Deletes a player from the database.
    /// </summary>
    /// <param name="id">The ID of the player to delete.</param>
    public bool DeletePlayer(int id)
    {
        return playerRepository.DeletePlayer(id);
    }

    /// <summary>
    /// Retrieves a player by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the player to retrieve.</param>
    /// <returns>The player object if found; otherwise, null.</returns>
    public DataTable GetPlayer(int id)
    {
        return playerRepository.GetPlayer(id);
    }

    // Examen 3
    /// <summary>
    /// Retrieves a player by their lastname.
    /// </summary>
    /// <param name="lastName">The lastname of the player to retrieve.</param>
    /// <returns>The player object if found; otherwise, null.</returns>
    public int GetPlayerByLastName(string lastName)
    {
        return playerRepository.GetPlayerByLastName(lastName);
    }

    public string GetPlayerPhoto(int id)
    {
        return playerRepository.GetPlayerPhoto(id);
    }

    /// <summary>
    /// Retrieves player data by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the player to retrieve.</param>
    /// <returns>The player data object if found; otherwise, null.</returns>
    public DataTable GetPlayerData(int id)
    {
        return playerRepository.GetPlayerData(id);
    }

    /// <summary>
    /// Retrieves player stats by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the player to retrieve.</param>
    /// <returns>The player stats object if found; otherwise, null.</returns>
    public DataTable GetPlayerStats(int id)
    {
        return playerRepository.GetPlayerStats(id);
    }

    /// <summary>
    /// Retrieves all players belonging to a specific team by team name.
    /// </summary>
    /// <param name="teamName">The name of the team.</param>
    /// <returns>A DataTable players belonging to the specified team.</returns>
    public DataTable GetPlayersByTeam(int teamId)
    {
        return playerRepository.GetPlayersByTeam(teamId);
    }
}