namespace InterfaceSegregation
{
  public class ScrumMaster : IWorkTeamActivites, IDesignActivities
  {
    public ScrumMaster()
    {
    }

    public void Plan()
    {
      Console.WriteLine("I'm planning user stories");
    }

    public void Comunicate()
    {
      Console.WriteLine("I'm talking to the team user");
    }

    public void Design()
    {
      Console.WriteLine("I'm designing new futures");
    }
  }
}