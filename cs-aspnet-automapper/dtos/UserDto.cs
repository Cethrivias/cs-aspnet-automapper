using System;

namespace cs_aspnet_automapper.dtos
{
  public class UserDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
  }
}