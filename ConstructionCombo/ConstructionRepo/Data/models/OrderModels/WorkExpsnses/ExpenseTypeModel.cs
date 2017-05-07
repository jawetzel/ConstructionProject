using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionRepo.Data.models.OrderModels.WorkExpsnses
{
    public class ExpenseTypeModel : BaseDataModel
    {
        public string Description { get; set; }

        public ICollection<ExpenseReportModel> ExpenseReports { get; set; }

    }
}
