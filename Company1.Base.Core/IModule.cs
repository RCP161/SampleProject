namespace Company.Base.Core
{
    public interface IModule
    {
        string Logo { get; }
        string Name { get; }

        InoModelBase1 HomeModel { get; }
    }
}
