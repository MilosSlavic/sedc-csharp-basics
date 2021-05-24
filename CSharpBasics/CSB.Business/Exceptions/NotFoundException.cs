using System;

namespace CSB.Business.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string resourceName)
        {
            ResourceName = resourceName;
        }

        public string ResourceName { get; }
    }
}
