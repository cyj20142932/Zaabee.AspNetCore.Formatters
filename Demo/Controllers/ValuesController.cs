﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<TestDto> Post([FromBody] IEnumerable<TestDto> dtos)
        {
            return dtos;
        }

        [HttpGet]
        [HttpPost]
        public IEnumerable<TestDto> Test(int quantity)
        {
            return CreateDtos(quantity);
        }

        [HttpPost]
        private static IEnumerable<TestDto> CreateDtos(int quantity)
        {
            return Enumerable.Range(0, quantity <= 0 ? 10 : quantity).Select(p => new TestDto
            {
                Id = Guid.NewGuid(),
                CreateTime = DateTime.Now,
                Enum = TestEnum.Apple,
                Name = Guid.NewGuid().ToString()
            });
        }
    }
}