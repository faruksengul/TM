using System;

namespace TurkMedya.Model
{
    public class TurkMedyaItemDto
    {
        public bool? hasPhotoGallery { get; set; }
        public bool? hasVideo { get; set; }
        public bool? titleVisible { get; set; }
        public string fLike { get; set; }
        public string publishDate { get; set; }
        public DateTime? publishDateTime { get { return (string.IsNullOrWhiteSpace(publishDate) || publishDate=="\"") ? (DateTime?)null : DateTime.ParseExact(publishDate, "dd.MM.yyyy HH:mm:ss", null); } }
        public string shortText { get; set; }
        public string fullPath { get; set; }
        public string videoUrl { get; set; }
        public string externalUrl { get; set; }
        public string columnistName { get; set; }
        public string itemId { get; set; }
        //public int? itemId { get; set; }
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string itemType { get; set; }
        public TurkMedyaCategoryDto category { get; set; }
    }
}