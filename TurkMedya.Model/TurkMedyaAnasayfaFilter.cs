using System;
using System.Collections.Generic;

namespace TurkMedya.Model
{
    public class TurkMedyaAnasayfaFilter
    {
        //Request
        public string SearchString { get; set; }
        public string Category { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }


        //Response
        public int? TotalCount { get; set; }
        public int PageCount
        {
            get
            {
                var pageSize = (PageSize ?? 5);
                return TotalCount > 0 ? TotalCount.GetValueOrDefault() / pageSize : 0;
            }
        }
        public IList<TurkMedyaItemDto> List { get; set; }
        public DateTime ExecuteDate { get; set; }
    }
}
