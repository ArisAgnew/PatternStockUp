namespace MiscellaneousStuff.WeakReferenceConcept
{
    public record ByteData(int Size)
    {
        internal byte[] Data
        {
            get => new byte[Size * 1024];
            private init { }
        }

        internal string Name
        {
            get => Size.ToString();
            private init { }
        }
    }
}
