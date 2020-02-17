using System;

namespace CarServise.Models.ForumViewModels
{
    public class ForumDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public string Val { get; set; }
        public string Pat { get; set; }
        public string ImgUrl { get; set; }
        public int ImgCount { get; set; }
        public string FlUrl { get; set; }
        public string VidUrl { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public string Com { get; set; }
        public string FIO { get; set; }
    }
}
