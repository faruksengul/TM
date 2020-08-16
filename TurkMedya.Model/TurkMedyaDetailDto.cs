using System.Collections.Generic;

namespace TurkMedya.Model
{
    public class TurkMedyaDetailDto
    {
        public TurkMedyaAdsenseDto headerAd { get; set; }
        public TurkMedyaAdsenseDto footerAd { get; set; }
        public TurkMedyaItemDto newsDetail { get; set; }
        public TurkMedyaMultimediaDto multimedia { get; set; }
        public IList<TurkMedyaItemDto> itemList { get; set; }
        public TurkMedyaItemDto relatedNews { get; set; }
        public TurkMedyaItemDto video { get; set; }
        public TurkMedyaItemDto photoGallery { get; set; }
    }
}
