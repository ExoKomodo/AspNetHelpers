namespace AspNetHelpers.Models
{
    public abstract class Dto<TId>
    {
        #region Public
        
        #region Fields
        public virtual TId Id { get; set; }
        #endregion

        #endregion
    }
}