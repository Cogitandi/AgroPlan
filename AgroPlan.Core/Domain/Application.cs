using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class Application
    {
        public Guid Id { get; set; }

        public Season Season { get; set; }
        public ApplicationKind ApplicationKind { get; set; }

        public IEnumerable<ParcelApplication> ParcelApplications { get; set; }
    }
}
