using System;
using Xamarin.Forms;

namespace PhoneDirectory.Core.CustomControls
{
    public class NullableDatePicker : DatePicker
    {
        private string _format = null;
        public static readonly BindableProperty _nullableDateProperty = BindableProperty.Create(nameof(NullableDate),
                                                                                                typeof(DateTime?),
                                                                                                typeof(NullableDatePicker),
                                                                                                null);
        public DateTime? NullableDate
        {
            get { return (DateTime?)GetValue(_nullableDateProperty); }
            set { SetValue(_nullableDateProperty, value); UpdateDate(); }
        }

        private void UpdateDate()
        {
            if (NullableDate.HasValue) { if (null != _format) Format = _format; Date = NullableDate.Value; }
            else { _format = Format; Format = "pick ..."; }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateDate();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Date") NullableDate = Date;
        }
    }
}
