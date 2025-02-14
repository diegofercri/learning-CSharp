/// <summary>
/// Represents a Player entity.
/// </summary>
public class Player
{
    // Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Team { get; set; }
    public string Position { get; set; }
    public string DateOfBirth { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string JerseyNumber { get; set; }
    public string Age { get; set; }
    public decimal CareerPoints { get; set; }
    public decimal CareerBlocks { get; set; }
    public decimal CareerAssists { get; set; }
    public decimal CareerRebounds { get; set; }
    public decimal CareerTurnovers { get; set; }
    public decimal CareerPercentageThree { get; set; }
    public decimal CareerPercentageFreethrow { get; set; }
    public decimal CareerPercentageFieldGoal { get; set; }
    public string HeadShotUrl { get; set; }
    public string DateLastUpdated { get; set; }

    /// <summary>
    /// Default constructor for the Player class.
    /// </summary>
    public Player() { }

    /// <summary>
    /// Parameterized constructor for the Player class.
    /// </summary>
    /// <param name="id">The unique identifier for the player.</param>
    /// <param name="firstName">The player's first name.</param>
    /// <param name="lastName">The player's last name.</param>
    /// <param name="team">The team the player belongs to.</param>
    /// <param name="position">The player's position on the team.</param>
    /// <param name="dateOfBirth">The player's date of birth.</param>
    /// <param name="height">The player's height.</param>
    /// <param name="weight">The player's weight.</param>
    /// <param name="jerseyNumber">The player's jersey number.</param>
    /// <param name="age">The player's age.</param>
    /// <param name="careerPoints">The total points scored by the player in their career.</param>
    /// <param name="careerBlocks">The total blocks made by the player in their career.</param>
    /// <param name="careerAssists">The total assists made by the player in their career.</param>
    /// <param name="careerRebounds">The total rebounds made by the player in their career.</param>
    /// <param name="careerTurnovers">The total turnovers made by the player in their career.</param>
    /// <param name="careerPercentageThree">The player's career three-point shooting percentage.</param>
    /// <param name="careerPercentageFreethrow">The player's career free-throw shooting percentage.</param>
    /// <param name="careerPercentageFieldGoal">The player's career field goal shooting percentage.</param>
    /// <param name="headShotUrl">The URL of the player's headshot image.</param>
    /// <param name="dateLastUpdated">The date when the player's information was last updated.</param>
    public Player(int id, string firstName, string lastName, string team, string position, string dateOfBirth, string height, string weight, string jerseyNumber, string age, decimal careerPoints, decimal careerBlocks, decimal careerAssists, decimal careerRebounds, decimal careerTurnovers, decimal careerPercentageThree, decimal careerPercentageFreethrow, decimal careerPercentageFieldGoal, string headShotUrl, string dateLastUpdated)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Team = team;
        Position = position;
        DateOfBirth = dateOfBirth;
        Height = height;
        Weight = weight;
        JerseyNumber = jerseyNumber;
        Age = age;
        CareerPoints = careerPoints;
        CareerBlocks = careerBlocks;
        CareerAssists = careerAssists;
        CareerRebounds = careerRebounds;
        CareerTurnovers = careerTurnovers;
        CareerPercentageThree = careerPercentageThree;
        CareerPercentageFreethrow = careerPercentageFreethrow;
        CareerPercentageFieldGoal = careerPercentageFieldGoal;
        HeadShotUrl = headShotUrl;
        DateLastUpdated = dateLastUpdated;
    }

    /// <summary>
    /// Returns a string representation of the Player object.
    /// </summary>
    /// <returns>A string containing the player's details.</returns>
    public override string ToString()
    {
        return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Team: {Team}, Position: {Position}, DateOfBirth: {DateOfBirth}, Height: {Height}, Weight: {Weight}, JerseyNumber: {JerseyNumber}, Age: {Age}, CareerPoints: {CareerPoints}, CareerBlocks: {CareerBlocks}, CareerAssists: {CareerAssists}, CareerRebounds: {CareerRebounds}, CareerTurnovers: {CareerTurnovers}, CareerPercentageThree: {CareerPercentageThree}, CareerPercentageFreethrow: {CareerPercentageFreethrow}, CareerPercentageFieldGoal: {CareerPercentageFieldGoal}, HeadShotUrl: {HeadShotUrl}, DateLastUpdated: {DateLastUpdated}";
    }
}