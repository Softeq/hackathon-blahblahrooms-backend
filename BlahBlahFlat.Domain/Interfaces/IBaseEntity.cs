namespace BlahBlahFlat.Domain.Interfaces
{
    /// <summary>
    /// Base for entities
    /// </summary>
    /// <typeparam name="TType">Type of Primary Key</typeparam>
    public interface IBaseEntity<TType>
    {
        /// <summary>
        /// Table Primary Key
        /// </summary>
        TType Id { get; set; }
    }
}
