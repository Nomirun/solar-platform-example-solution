namespace Accounts.Models
{
    /// <summary>
    /// Account model
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Person first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Person last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// List of solar inverters for person
        /// </summary>
        public List<long> SolarInverterIds { get; set; }
    }
}