namespace ConsoleGo
{
    internal interface IMain
    {
        void Run();
#if (allFeatures)
        void Go(string name);
#endif
    }
}