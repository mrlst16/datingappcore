using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo.Members;
using Microsoft.AspNetCore.Http;

namespace DatingAppCore.BLL.Requests
{
    public class SetPhotosRequest
    {
        public Guid UserID { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
