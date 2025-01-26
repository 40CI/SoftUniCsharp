using global::EDriveRent.IO.Contracts;
using System;

namespace EDriveRent.IO
{
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
