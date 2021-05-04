using Domain;
using System.Collections.Generic;

namespace Model.Out
{
    public class CategoryBasicInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AudioContentBasicInfoModel> AudioContents { get; set; }
    }
}