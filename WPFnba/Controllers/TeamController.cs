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
    public TeamController(TeamRepository repository)
    {
        teamRepository = repository;
    }

    /// <summary>
    /// Adds a new team to the database.
    /// </summary>
    /// <param name="teamData">A list of strings containing team data.</param>
    public void AddTeam(List<string> teamData)
    {
        teamRepository.InsertTeam(teamData);
    }

    /// <summary>
    /// Updates an existing team in the database.
    /// </summary>
    /// <param name="teamData">An array of strings containing updated team data.</param>
    internal bool UpdateTeam(List<string> teamData)
    {
        // Llamar al método del repositorio para actualizar el equipo
        return teamRepository.UpdateTeam(teamData);
    }

    /// <summary>
    /// Deletes a team from the database.
    /// </summary>
    /// <param name="id">The ID of the team to delete.</param>
    public void DeleteTeam(int id)
    {
        teamRepository.DeleteTeam(id);
    }

    /// <summary>
    /// Retrieves all teams from the database.
    /// </summary>
    /// <returns>A list of all teams.</returns>
    public DataTable GetTeam(int id)
    {
        return teamRepository.GetTeam(id);
    }

    /// <summary>
    /// Retrieves all teams from the database.
    /// </summary>
    /// <returns>A list of all teams.</returns>
    public DataTable GetTeams()
    {
        return teamRepository.GetTeams();
    }
}
