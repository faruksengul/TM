using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TurkMedya.Core;
using TurkMedya.Core.Response;
using TurkMedya.Model;

namespace TurkMedya.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TurkMedyaController : ControllerBase
    {
        private readonly ILogger<TurkMedyaController> _logger;
        private readonly TurkMedyaHttpDataCollector _turkMedyaHttpDataCollector;

        public TurkMedyaController(ILogger<TurkMedyaController> logger, TurkMedyaHttpDataCollector turkMedyaHttpDataCollector)
        {
            _logger = logger;
            _turkMedyaHttpDataCollector = turkMedyaHttpDataCollector;
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "TurkMedya")]
        public async Task<TurkMedyaAnasayfaFilter> List([FromQuery] TurkMedyaAnasayfaFilter filter)
        {
            var result = await _turkMedyaHttpDataCollector.GetAnasayfa();
            var filteredList = new List<TurkMedyaItemDto>();
            foreach (var data in result.data.Where(x => x.sectionType == "NEWS"))
            {
                foreach (var item in data.itemList)
                {
                    if (!string.IsNullOrWhiteSpace(filter.Category) && item.category != null && item.category.slug != filter.Category)
                    {
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(filter.SearchString) && item.title != null && !item.title.ToLower().Contains(filter.SearchString.ToLower()))
                        continue;

                    filteredList.Add(item);
                }
            }
            filter.TotalCount = filteredList.Count;
            var pageSize = filter.PageSize ?? 5;
            filter.List = filteredList
                .OrderByDescending(x => x.publishDateTime)
                .Skip(((filter.PageNumber.HasValue ? filter.PageNumber.Value : 1) * pageSize) - pageSize).Take(pageSize)
                .ToList();
            filter.ExecuteDate = DateTime.Now;
            return filter;
        }
        [HttpGet]
        [ResponseCache(CacheProfileName = "TurkMedya")]
        public async Task<DetayTurkMedyaResponse> Detail()
        {
            var result = await _turkMedyaHttpDataCollector.GetDetay();
            return result;
        }
    }
}
