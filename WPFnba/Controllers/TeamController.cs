using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Controller class for handling team-related operations.
/// </summary>
public class TeamController
{
    private TeamRepository teamRepository;

    /// <summary>
    /// Constructor to initialize the team repository.
    /// </summary>
    /// <param name="repository">The team repository instance.</param>
    public TeamController(TeamRepository repository)
    {
        teamRepository = repository;
    }

    /// <summary>
    /// Adds a new team to the database.
    /// </summary>
    /// <param name="teamData">A list of strings containing team data.</param>
    /// <returns>True if the team was added successfully; otherwise, false.</returns>
    internal bool AddTeam(List<string> teamData)
    {
        if (teamData == null || teamData.Count < 6)
        {
            throw new ArgumentException("Invalid team data provided."); // "Datos de equipo no válidos proporcionados."
        }
        try
        {
            int nextId = teamRepository.GetNextId();
            teamData.Insert(0, nextId.ToString());
            return teamRepository.InsertTeam(teamData);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}"); // "Error: {e.Message}"
            return false;
        }
    }

    /// <summary>
    /// Updates an existing team in the database.
    /// </summary>
    /// <param name="teamData">An array of strings containing updated team data.</param>
    /// <returns>True if the team was updated successfully; otherwise, false.</returns>
    internal bool UpdateTeam(List<string> teamData)
    {
        // Call the repository method to update the team
        return teamRepository.UpdateTeam(teamData);
    }

    /// <summary>
    /// Deletes a team from the database.
    /// </summary>
    /// <param name="id">The ID of the team to delete.</param>
    /// <returns>True if the team was deleted successfully; otherwise, false.</returns>
    public bool DeleteTeam(int id)
    {
        return teamRepository.DeleteTeam(id);
    }

    /// <summary>
    /// Retrieves a team by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the team to retrieve.</param>
    /// <returns>The team object if found; otherwise, null.</returns>
    public DataTable GetTeam(int id)
    {
        return teamRepository.GetTeam(id);
    }

    /// <summary>
    /// Retrieves all teams from the database.
    /// </summary>
    /// <returns>A DataTable containing all teams.</returns>
    public DataTable GetTeams()
    {
        return teamRepository.GetTeams();
    }
}