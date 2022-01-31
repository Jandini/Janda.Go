namespace ConsoleGo
{
    internal interface IMain
    {
        void Run();
#if (all)
        void Go(string name);
#endif
    }
}