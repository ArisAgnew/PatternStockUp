namespace BehavioralDesignPatterns.Observer.ObservableCollection
{
    internal class User
    {
        public string Name { get; set; }
    }

    internal class Launcher
    {
        static void Main(string[] args)
        {
            OCollection<User> obs = new OCollection<User>();

            obs.Collection.CollectionChanged += OCollection<User>.CollectionChanged_ToAdd;
            obs.Collection.CollectionChanged += OCollection<User>.CollectionChanged_ToRemove;
            obs.Collection.CollectionChanged += OCollection<User>.CollectionChanged_ToReallocate;

            var specimen = new User { Name = "Quentin" };

            obs.Allocate(new User { Name = "Olaf" })
                .Allocate(new User { Name = "Jean" })
                .Allocate(specimen);

            obs.Remove(specimen); //it works out that way
            obs.RemoveAt(1);
            obs.Collection[0] = new User { Name = "Hamilton" };
            obs.Insert(0, new User { Name = "Hercules" });
        }
    }
}
