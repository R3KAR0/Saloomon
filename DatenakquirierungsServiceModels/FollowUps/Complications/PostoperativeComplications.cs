using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.FollowUps.Complications
{
    public class PostoperativeComplications : AGenericComplications
    {
        public List<PostoperativeComplications> postoperativeComplicationsList { get; set; }
    }
}
