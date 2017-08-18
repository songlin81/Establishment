namespace Structure
{
    public static class Facade
    {
        static public IService CreateService(string sChoice)
        {
            IService objSelector;

            switch (sChoice)
            {
                case "foundation":
                    objSelector = new FoundationService();
                    break;
                default:
                    objSelector = new MockService();
                    break;
            }
            return objSelector;
        }
    }
}
