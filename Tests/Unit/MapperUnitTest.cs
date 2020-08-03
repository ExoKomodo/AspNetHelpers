using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Dtos;
using Tests.Mappers;
using Tests.Models;
using Xunit;

namespace Tests.Unit
{
    public class MapperUnitTest
    {
        public MapperUnitTest()
        {
            _mapper = new SimpleMapper();

            _model = new SimpleModel
            {
                Id = Guid.NewGuid(),
                Name = "Some Model",
                Number = 1,
                FloatingNumber = 3.14f,
                SensitiveInfo = "Something sensitive",
            };
            _models = new List<SimpleModel>
            {
                _model
            };

            _dto = new SimpleDto
            {
                Id = Guid.NewGuid(),
                Name = "Some Dto",
                Number = 2,
                FloatingNumber = 6.28f,
            };
            _dtos = new List<SimpleDto>
            {
                _dto
            };
        }

        private SimpleDto _dto;
        private IEnumerable<SimpleDto> _dtos;
        private SimpleMapper _mapper;
        private SimpleModel _model;
        private IEnumerable<SimpleModel> _models;

        [Fact]
        public void TestToDtoMapsCorrectly()
        {
            var dto = _mapper.ToDto(_model);
            AssertMappedEquality(_model, dto);
        }

        [Fact]
        public void TestToDtosMapsAllModels()
        {
            var dtos = _mapper.ToDtos(_models);
            Assert.All(Enumerable.Zip(_models, dtos), (pair) => AssertMappedEquality(pair.First, pair.Second));
        }

        [Fact]
        public void TestToModelMapsCorrectly()
        {
            var model = _mapper.ToModel(_dto);
            Assert.Equal(model.Id, _dto.Id);
            Assert.Equal(model.Name, _dto.Name);
            Assert.Equal(model.Number, _dto.Number);
            Assert.Equal(model.FloatingNumber, _dto.FloatingNumber);
        }

        [Fact]
        public void TestToModelsMapsAllDtos()
        {
            var models = _mapper.ToModels(_dtos);
            Assert.All(Enumerable.Zip(models, _dtos), (pair) => AssertMappedEquality(pair.First, pair.Second));
        }

        private void AssertMappedEquality(SimpleModel model, SimpleDto dto)
        {
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.Name, model.Name);
            Assert.Equal(dto.Number, model.Number);
            Assert.Equal(dto.FloatingNumber, model.FloatingNumber);
        }
    }
}
