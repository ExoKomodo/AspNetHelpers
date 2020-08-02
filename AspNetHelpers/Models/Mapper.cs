using System.Collections.Generic;
using System.Linq;

namespace AspNetHelpers.Models
{
    public abstract class Mapper<TId, TModel, TDto>
        where TModel : Model<TId>
        where TDto : Dto<TId>
    {
        #region Public

        #region Member Methods
        public abstract TDto ToDto(TModel model);
        public IEnumerable<TDto> ToDtos(IEnumerable<TModel> models) => models.Select(model => ToDto(model));
        public abstract TModel ToModel(TDto dto);
        public IEnumerable<TModel> ToModels(IEnumerable<TDto> dtos) => dtos.Select(dto => ToModel(dto));
        #endregion

        #endregion
    }
}
