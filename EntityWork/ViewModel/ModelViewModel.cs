using System.Collections.Generic;
using System.Linq;

namespace EntityWork.ViewModel
{
    public class ModelViewModel
    {
        ModelContext _db = new ModelContext();

        public ModelViewModel()
        {
            var query = (   from m in _db.Models
                            join vf in _db.ModelFilterVariants
                            on m.ModelId equals vf.ModelId
                            where m.ModelId == "FH 64R B3HPM01" && 1 == 1
                            orderby vf.VariantId
                            select new { modelId = m.ModelId, variantId=vf.VariantId}
                        )
                        .ToList()
                        .Select(r => new ModelView()
                        {
                            ModelId = r.modelId,
                            VariantId = r.variantId
                        }).ToList();

            Model = query;
        }

        public IList<ModelView> Model { get; set; }
    }
}
