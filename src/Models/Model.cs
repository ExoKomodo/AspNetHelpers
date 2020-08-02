using System.ComponentModel.DataAnnotations;

namespace AspNetHelpers.Models
{
    public abstract class Model<TId>
    {
        #region Public

        #region Fields
        [Key]
        public virtual TId Id { get; set; }
        #endregion

        #endregion
    }
}