namespace csharp_visa
{
    internal class Kysymys
    {
        public Kysymys(string kys, string vast)
        {
            Kys = kys;
            Vast = vast;
        }

        public string Kys { get; }
        public string Vast { get; }
    }
}