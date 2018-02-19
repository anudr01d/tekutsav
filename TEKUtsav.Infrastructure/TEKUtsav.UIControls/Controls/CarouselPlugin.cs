using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.Controls
{
    public class CarouselPageTemplateList : List<DataTemplate>
    {
        public CarouselPageTemplateList() : base() { }
        public CarouselPageTemplateList(IEnumerable<DataTemplate> collection) : base(collection) { }
        public CarouselPageTemplateList(int capacity) : base(capacity) { }
    }
}
