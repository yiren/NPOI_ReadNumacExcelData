using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi.Model.Vote
{
    class VoteOption
    {
        public Guid VoteOptionId { get; set; }
        public string VoteOptionName { get; set; }

        public string VoteEventName { get; set; }
        public int VoteEventId { get; set; }
    }
}
