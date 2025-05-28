using GramaLink.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GramaLink.Entities.Entity
{
    public class AppRole : CommonEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
