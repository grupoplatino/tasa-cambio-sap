namespace TasaCambioJob
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                new RateJob().Execute();
                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}
