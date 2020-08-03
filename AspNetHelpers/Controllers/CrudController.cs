using AspNetHelpers.Database;
using AspNetHelpers.Dtos;
using AspNetHelpers.Mappers;
using AspNetHelpers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace AspNetHelpers.Controllers
{
    [Route("api/[controller]")]
    public abstract class CrudController<TId, TModel, TDto> : Controller
        where TModel : Model<TId>
        where TDto : Dto<TId>
    {
        #region Public

        #region Constructors
        protected CrudController(
            Mapper<TId, TModel, TDto> mapper,
            EntityRepository<TId, TModel> repository
        )
        {
            _mapper = mapper;
            _repository = repository;
        }
        #endregion

        #region Member Methods
        [HttpPost]
        public ActionResult<TDto> Create([FromBody] TDto dto)
        {
            try
            {
                return Ok(
                    _mapper.ToDto(
                        _repository.Create(
                            _mapper.ToModel(dto)
                        )
                    )
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TDto> GetById(TId id)
        {
            try
            {
                var model = _repository.Get(id);
                if (model is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.ToDto(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<TDto>> GetAll()
        {
            try
            {
                var models = _repository.GetAll();
                return Ok(_mapper.ToDtos(models));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<TDto> Update(TId id, [FromBody] TDto dto)
        {
            try
            {
                var model = _repository.Update(
                    id,
                    _mapper.ToModel(dto)
                );
                if (model is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.ToDto(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<TDto> Delete(TId id)
        {
            try
            {
                var model = _repository.Delete(id);
                if (model is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.ToDto(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #endregion

        #region Protected
        
        #region Fields
        protected Mapper<TId, TModel, TDto> _mapper;
        protected EntityRepository<TId, TModel> _repository;
        #endregion

        #endregion
    }
}