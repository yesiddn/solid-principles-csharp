namespace InterfaceSegregation
{
  public class Developer : IWorkTeamActivites, IDevelopActivities
  {
    public Developer()
    {
    }

    public void Plan()
    {
      throw new ArgumentException();
    }

    public void Comunicate()
    {
      throw new ArgumentException();
    }

    public void Develop()
    {
      Console.WriteLine("I'm developing the functionalities required");
    }
  }
}