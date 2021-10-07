using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fictivus_API_gateway.DTO
{
    public class SearchInTopicDTO
    {
        #region fields
        private string searchTerm;
        private string topicTitle;
        #endregion

        #region constructors
        //empty constructor for JSON
        public SearchInTopicDTO()
        {

        }

        public SearchInTopicDTO(string searchTerm, string topicTitle)
        {
            this.SearchTerm = searchTerm;
            this.TopicTitle = topicTitle;
        }
        #endregion

        #region properties

        public string SearchTerm { get => searchTerm; set => searchTerm = value; }
        public string TopicTitle { get => topicTitle; set => topicTitle = value; }


        #endregion
    }
}
