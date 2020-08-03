using AspNetHelpers.Dtos;
using AspNetHelpers.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AspNetHelpers.Mappers
{
    public abstract class Mapper<TId, TModel, TDto>
        where TModel : Model<TId>
        where TDto : Dto<TId>
    {
        #region Public

        #region Member Methods
        public TDto ToDto(TModel model)
        {
            var dtoType = typeof(TDto);
            var dtoProperties = dtoType.GetProperties();
            var modelProperties = model.GetType().GetProperties();

            var dto = (TDto)Activator.CreateInstance(dtoType);
            foreach (var modelProperty in modelProperties)
            {
                var dtoProperty = dtoType.GetProperty(modelProperty.Name);
                if (dtoProperty == null)
                {
                    continue;
                }
                dtoProperty.SetValue(dto, modelProperty.GetValue(model));
            }

            return dto;
        }

        public IEnumerable<TDto> ToDtos(IEnumerable<TModel> models) => models.Select(model => ToDto(model));
        
        public TModel ToModel(TDto dto)
        {
            var modelType = typeof(TModel);
            var modelProperties = modelType.GetProperties();
            var dtoProperties = dto.GetType().GetProperties();

            var model = (TModel)Activator.CreateInstance(modelType);
            foreach (var dtoProperty in dtoProperties)
            {
                var modelProperty = modelType.GetProperty(dtoProperty.Name);
                if (modelProperty == null)
                {
                    continue;
                }
                modelProperty.SetValue(model, dtoProperty.GetValue(dto));
            }

            return model;
        }
        
        public IEnumerable<TModel> ToModels(IEnumerable<TDto> dtos) => dtos.Select(dto => ToModel(dto));
        #endregion

        #endregion
    }
}
