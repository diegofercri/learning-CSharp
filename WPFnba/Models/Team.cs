using System;

/// <summary>
/// Represents a Team entity.
/// </summary>
public class Team
{
    // Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Conference { get; set; }
    public string Record { get; set; }
    public string TeamLogoUrl { get; set; }
    public string DateLastUpdated { get; set; }

    /// <summary>
    /// Default constructor for the Team class.
    /// </summary>
    public Team() { }

    /// <summary>
    /// Parameterized constructor for the Team class.
    /// </summary>
    /// <param name="id">The unique identifier for the team.</param>
    /// <param name="name">The name of the team.</param>
    /// <param name="conference">The conference to which the team belongs.</param>
    /// <param name="record">The team's win-loss record.</param>
    /// <param name="teamLogoUrl">The URL of the team's logo.</param>
    /// <param name="dateLastUpdated">The date when the team's information was last updated.</param>
    public Team(int id, string name, string conference, string record, string teamLogoUrl, string dateLastUpdated)
    {
        Id = id;
        Name = name;
        Conference = conference;
        Record = record;
        TeamLogoUrl = teamLogoUrl;
        DateLastUpdated = dateLastUpdated;
    }

    /// <summary>
    /// Returns a string representation of the Team object.
    /// </summary>
    /// <returns>A string containing the team's details.</returns>
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Conference: {Conference}, Record: {Record}, TeamLogoUrl: {TeamLogoUrl}, DateLastUpdated: {DateLastUpdated}";
    }
}