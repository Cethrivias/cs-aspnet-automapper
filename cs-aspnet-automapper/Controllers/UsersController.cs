using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cs_aspnet_automapper.dtos;
using cs_aspnet_automapper.models;
using Microsoft.AspNetCore.Mvc;

namespace cs_aspnet_automapper.Controllers
{
  [ApiController]
  [Route("users")]
  public class WeatherForecastController : ControllerBase
  {

    private IMapper _mapper;

    private static List<User> _users = new()
    {
      new User
      {
        Email = "test@test.com",
        Id = Guid.NewGuid(),
        FirstName = "John",
        LastName = "Doe",
      },
      new User
      {
        Email = "test1@test.com",
        Id = Guid.NewGuid(),
        FirstName = "Foo",
        LastName = "Bar",
      },
    };

    public WeatherForecastController(IMapper mapper)
    {
      _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<UserDto> Get()
    {
      return _mapper.Map<List<UserDto>>(_users);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public ActionResult<UserDto> GetById(Guid id)
    {
      var user = _users.FirstOrDefault(it => it.Id == id);

      return user is not null ? _mapper.Map<UserDto>(user) : NotFound();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public ActionResult<UserDto> UpdateById([FromRoute] Guid id, [FromBody] UserDto user)
    {
      var index = _users.FindIndex(it => it.Id == id);
      if (index == -1) {
        return NotFound();
      }

      _users[index] = _mapper.Map<User>(user);

      return _mapper.Map<UserDto>(_users[index]);
    }
  }
}