namespace Shared;

public class Todo: IEntity {
  public string title { get; set; }
  public string description { get; set; }
  public bool done { get; set; } = false;
  public Guid id { get; set; } = Guid.NewGuid();
}

interface IEntity {
  Guid id { get; set; }
}