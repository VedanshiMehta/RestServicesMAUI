using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Selector
{
    class AcitiviyCompletedSelector : DataTemplateSelector
    {
        public DataTemplate ActivityCompleted {  get; set; }
        public DataTemplate ActivityNotCompleted { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var acitvity = (GetActivitiesResponseModel) item;
            return (acitvity.Completed) ? ActivityCompleted : ActivityNotCompleted;
        }
    }
}
