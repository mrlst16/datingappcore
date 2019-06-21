using CommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Dto.Matching
{
    public class SwipeDTO : DtoBase
    {
        public Guid UserFromID { get; set; }
        public Guid UserToID { get; set; }
        public bool IsLike { get; set; }
    }
}
