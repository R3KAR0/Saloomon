using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.FollowUps.Complications
{
    public abstract class AGenericComplications : AEntity
    {
        public List<string> genericComplications { get; set; }

        public bool konservativeTherapy { get; set; }

        public bool noInterventions { get; set; }

        public bool OP { get; set; }

        public string clavienDindoClassification { get; set; }

        public string otherComplications { get; set; }
    }
}
