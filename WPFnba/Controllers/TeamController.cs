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
    public bool AddTeam(List<string> teamData)
    {
        return teamRepository.InsertTeam(teamData);
    }

    /// <summary>
    /// Updates an existing team in the database.
    /// </summary>
    /// <param name="teamData">A list of strings containing updated team data.</param>
    internal bool UpdateTeam(List<string> teamData)
    {
        // Call the repository method to update the team
        return teamRepository.UpdateTeam(teamData);
    }

    /// <summary>
    /// Deletes a team from the database.
    /// </summary>
    /// <param name="id">The ID of the team to delete.</param>
    public bool DeleteTeam(int id)
    {
        return teamRepository.DeleteTeam(id);
    }

    /// <summary>
    /// Retrieves a team by its unique ID.
    /// </summary>
    /// <param name="id">The ID of the team to retrieve.</param>
    /// <returns>A DataTable containing the team's information if found; otherwise, null.</returns>
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