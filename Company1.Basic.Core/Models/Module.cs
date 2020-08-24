using Company.Base.Core;

namespace Company.Basic.Core.Models
{
    public class Module : InoModelBase1, IModule
    {
        public Module()
        {
            Logo = "Bsc.";
            Name = "Basic";
            HomeModel = Home.Instance;
        }


        #region Properties

        public string Logo { get; private set; }
        public string Name { get; private set; }
        public InoModelBase1 HomeModel { get; private set; }

        #endregion
    }
}
