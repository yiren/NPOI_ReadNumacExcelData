using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi.Model.Vote
{
    class VoteEvent
    {
        public int VoteEventId { get; set; }

        public string VoteEventName { get; set; }

        public string VoteDeadline{ get; set; }

        public bool IsEventDue { get; set; }

        public ICollection<VoteRecord> VoteRecords { get; set; }
    }
}
