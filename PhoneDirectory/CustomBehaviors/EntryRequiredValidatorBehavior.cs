using System;
using Xamarin.Forms;

namespace PhoneDirectory.Core.CustomBehaviors
{
    public class EntryRequiredValidatorBehavior : Behavior<Entry>
    {
        public string MessageLabel { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            bindable.SizeChanged += OnSizeChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            bindable.SizeChanged -= OnSizeChanged;
            base.OnDetachingFrom(bindable);
        }

		private void OnSizeChanged(object sender, EventArgs e)
        {
            var entry = (Entry)sender;
            bool isValid = !string.IsNullOrEmpty(entry.Text);
            Label errorLabel = (entry).FindByName<Label>(MessageLabel);
            errorLabel.IsVisible = !isValid;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;
            bool isValid = !string.IsNullOrEmpty(entry.Text);
            Label errorLabel = (entry).FindByName<Label>(MessageLabel);
            errorLabel.IsVisible = !isValid;
        }
    }
}
