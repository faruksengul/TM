using System.Collections;
using System.Collections.Generic;

namespace TurkMedya.Model
{
    public class TurkMedyaMultimediaDto
    {
        public string sectionType { get; set; }
        public string repeatType { get; set; }
        public int? itemCountInRow { get; set; }
        public bool? lazyLoadingEnabled { get; set; }
        public bool? titleVisible { get; set; }
        public string title { get; set; }
        public string titleColor { get; set; }
        public string titleBgColor { get; set; }
        public string sectionBgColor { get; set; }

        public IList<TurkMedyaItemDto> itemList { get; set; }
    }
}
