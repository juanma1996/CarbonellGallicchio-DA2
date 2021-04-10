using Domain;
using System.Collections.Generic;

namespace Model.Out
{
    public class CategoryBasicInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is CategoryBasicInfoModel category)
            {
                result = this.Id == category.Id && this.Name.Equals(category.Name);
            }

            return result;
        }
    }
}