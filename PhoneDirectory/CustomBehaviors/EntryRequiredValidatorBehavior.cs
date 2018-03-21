using Xamarin.Forms;

namespace PhoneDirectory.Core.CustomBehaviors
{
    public class EntryRequiredValidatorBehavior : Behavior<Entry>
    {
        public string MessageLabel { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;
            bool isValid = !string.IsNullOrEmpty(entry.Text);
            Label errorLabel = (entry).FindByName<Label>(MessageLabel);
            errorLabel.Text = isValid ? "" : "This field is required";
            errorLabel.IsVisible = !isValid;
        }
    }
}
