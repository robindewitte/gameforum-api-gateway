using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fictivus_API_gateway.DTO
{
    public class SearchInTopicDTO
    {
        #region fields
        #endregion

        #region constructors
        //empty constructor for JSON
        public SearchInTopicDTO()
        {

        }

        public SearchInTopicDTO(string searchTerm, string topicTitle)
        {
            SearchTerm = searchTerm;
            TopicTitle = topicTitle;
        }
        #endregion

        #region properties

        public string SearchTerm { get; set; }
        public string TopicTitle { get; set; }


        #endregion
    }
}
