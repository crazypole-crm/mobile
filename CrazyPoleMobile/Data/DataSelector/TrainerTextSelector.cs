using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Data.DataSelector
{
    internal class TrainerTextSelector : DataTemplateSelector
    {
        public DataTemplate OriginalTrainer { get; set; }
        public DataTemplate ChangedTrainer { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var isTrainerChanged = (bool)item;

            if (isTrainerChanged)
                return ChangedTrainer;

            return OriginalTrainer;
        }
    }
}
