using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace npoi.Model.Vote
{
    class VoteRecord
    {
        public Guid VoteRecordId { get; set; }

        public string VoterName { get; set; }

        public string VoteEventName { get; set; }

        public string SelectedOptionName { get; set; }

        public Guid SelectedOptionId { get; set; }
    }
}
