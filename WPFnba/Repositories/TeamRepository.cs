using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using WPFnba;

/// <summary>
/// Repository class for handling CRUD operations on the Team entity.
/// </summary>
public class TeamRepository
{
    private DataContext dataContext;
    private DataTable teams_dt;
    private DataTable team_dt;

    /// <summary>
    /// Constructor to initialize the data context.
    /// </summary>
    public TeamRepository()
    {
        dataContext = Database.GetContext();
        DataTable teams_dt = new DataTable();
        DataTable team_dt = new DataTable();
    }

    /// <summary>
    /// Inserts a new team into the database.
    /// </summary>
    /// <param name="teamData">A list of strings containing team data.</param>
    /// <returns>True if the team was successfully inserted; otherwise, false.</returns>
    internal bool InsertTeam(List<string> teamData)
    {
        // Validate that the data is valid
        if (teamData == null || teamData.Count < 6) // We only need 5 elements without the ID
        {
            throw new ArgumentException("Invalid team data provided."); // "Datos de equipo no válidos proporcionados."
        }
        try
        {
            team team = new team();
            for (int i = 0; i < teamData.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        team.id = int.Parse(teamData[i]);
                        break;
                    case 1:
                        team.name = teamData[i];
                        break;
                    case 2:
                        team.conference = teamData[i];
                        break;
                    case 3:
                        team.record = teamData[i];
                        break;
                    case 4:
                        team.teamLogoUrl = teamData[i];
                        break;
                    case 5:
                        team.dateLastUpdated = teamData[i];
                        break;
                }
            }
            // Add the team to the database
            dataContext.GetTable<team>().InsertOnSubmit(team);
            dataContext.SubmitChanges();
            return true; // Indicates success
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}"); // "Error: {e.Message}"
            return false; // Indicates failure
        }
    }

    /// <summary>
    /// Updates an existing team in the database.
    /// </summary>
    /// <param name="teamData">A list of strings containing updated team data.</param>
    /// <returns>True if the team was successfully updated; otherwise, false.</returns>
    internal bool UpdateTeam(List<string> teamData)
    {
        if (teamData == null || teamData.Count < 6)
        {
            throw new ArgumentException("Invalid team data provided."); // "Datos de equipo no válidos proporcionados."
        }
        try
        {
            team team = new team();
            for (int i = 0; i < teamData.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        team.id = int.Parse(teamData[i]);
                        break;
                    case 1:
                        team.name = teamData[i];
                        break;
                    case 2:
                        team.conference = teamData[i];
                        break;
                    case 3:
                        team.record = teamData[i];
                        break;
                    case 4:
                        team.teamLogoUrl = teamData[i];
                        break;
                    case 5:
                        team.dateLastUpdated = teamData[i];
                        break;
                }
            }
            team teamSearch = dataContext.GetTable<team>().First(t => t.id == team.id);
            foreach (var prop in team.GetType().GetProperties())
            {
                if (prop.Name != "id")
                {
                    prop.SetValue(teamSearch, prop.GetValue(team));
                }
            }
            dataContext.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}"); // "Error: {e.Message}"
            return false;
        }
    }

    /// <summary>
    /// Deletes a team from the database.
    /// </summary>
    /// <param name="id">The ID of the team to delete.</param>
    /// <returns>True if the team was successfully deleted; otherwise, false.</returns>
    internal bool DeleteTeam(int id)
    {
        try
        {
            team _team = dataContext.GetTable<team>().First(t => t.id == id);
            dataContext.GetTable<team>().DeleteOnSubmit(_team);
            dataContext.SubmitChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}"); // "Error: {e.Message}"
            return false;
        }
    }

    /// <summary>
    /// Retrieves a team by their unique ID.
    /// </summary>
    /// <param name="id">The ID of the team to retrieve.</param>
    /// <returns>The team object as a DataTable if found; otherwise, null.</returns>
    internal DataTable GetTeam(int id)
    {
        try
        {
            // Search for the team by ID
            team team = dataContext.GetTable<team>().First(t => t.id == id);

            // Initialize DataTable if it is null
            if (team_dt == null)
            {
                team_dt = new DataTable();
                team_dt.Columns.Add("Id", typeof(int));
                team_dt.Columns.Add("Name", typeof(string));
                team_dt.Columns.Add("Conference", typeof(string));
                team_dt.Columns.Add("Record", typeof(string));
                team_dt.Columns.Add("TeamLogoUrl", typeof(string));
                team_dt.Columns.Add("DateLastUpdated", typeof(DateTime));
            }
            // Clear the DataTable if it is not null
            else
            {
                team_dt.Rows.Clear();
            }

            // Convert the team to a DataTable
            team_dt.Rows.Add(
                team.id,
                team.name,
                team.conference,
                team.record,
                team.teamLogoUrl,
                team.dateLastUpdated
            );

            return team_dt;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    /// <summary>
    /// Retrieves all teams from the database.
    /// </summary>
    /// <returns>A DataTable containing all teams.</returns>
    public DataTable GetTeams()
    {
        try
        {
            // Search for teams and order them by conference and name
            List<team> teams = dataContext.GetTable<team>()
                .OrderBy(t => t.conference)
                .ThenBy(t => t.name)
                .ToList();

            // Initialize DataTable if it is null
            if (teams_dt == null)
            {
                teams_dt = new DataTable();
                teams_dt.Columns.Add("Id", typeof(int));
                teams_dt.Columns.Add("Name", typeof(string));
                teams_dt.Columns.Add("Conference", typeof(string));
                teams_dt.Columns.Add("Record", typeof(string));
                teams_dt.Columns.Add("TeamLogoUrl", typeof(string));
                teams_dt.Columns.Add("DateLastUpdated", typeof(DateTime));
            }
            else
            {
                teams_dt.Rows.Clear();
            }

            // Convert the list of teams to a DataTable
            foreach (team t in teams)
            {
                teams_dt.Rows.Add(
                    t.id,
                    t.name,
                    t.conference,
                    t.record,
                    t.teamLogoUrl,
                    t.dateLastUpdated
                );
            }

            // Return the DataTable
            return teams_dt;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}"); // "Error: {e.Message}"
            return null;
        }
    }

    /// <summary>
    /// Retrieves the maximum ID from the teams table.
    /// </summary>
    /// <returns>The maximum ID or 0 if no records exist.</returns>
    public int GetNextId()
    {
        // Retrieve the maximum ID from the database
        var maxId = dataContext.GetTable<team>().Max(t => (int?)t.id) ?? 0;

        // Return the next ID
        return maxId + 1;
    }
}