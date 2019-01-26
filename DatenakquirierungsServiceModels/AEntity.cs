using System;

namespace DatenakquirierungsServiceModels
{
    public abstract class AEntity
    {
        public long Id { get; set; }
        public long version { get; set; }
    }
}
