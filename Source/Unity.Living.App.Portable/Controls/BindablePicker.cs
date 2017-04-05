using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Controls
{
    public class BindablePicker : Picker
    {
        public BindablePicker()
        {
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }


        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(object), typeof(BindablePicker), null, BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(BindablePicker.OnSelectedItemChanged), null, null, null);
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(BindablePicker), null, BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(BindablePicker.OnItemsSourceChanged), null, null, null);
        public static readonly BindableProperty DisplayPropertyProperty = BindableProperty.Create("DisplayProperty", typeof(string), typeof(BindablePicker), null, BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(BindablePicker.OnDisplayPropertyChanged), null, null, null);

        public IList ItemsSource
        {
            get { return (IList)base.GetValue(BindablePicker.ItemsSourceProperty); }
            set { base.SetValue(BindablePicker.ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return base.GetValue(BindablePicker.SelectedItemProperty); }
            set
            {
                base.SetValue(BindablePicker.SelectedItemProperty, value);
                if (ItemsSource.Contains(SelectedItem))
                {
                    SelectedIndex = ItemsSource.IndexOf(SelectedItem);
                }
                else
                {
                    SelectedIndex = -1;
                }
            }
        }

        public string DisplayProperty
        {
            get { return (string)base.GetValue(BindablePicker.DisplayPropertyProperty); }
            set { base.SetValue(BindablePicker.DisplayPropertyProperty, value); }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedItem = ItemsSource[SelectedIndex];
        }


        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BindablePicker picker = (BindablePicker)bindable;
            picker.SelectedItem = newValue;
            if (picker.ItemsSource != null && picker.SelectedItem != null)
            {
                int count = 0;
                foreach (object obj in picker.ItemsSource)
                {
                    if (obj == picker.SelectedItem)
                    {
                        picker.SelectedIndex = count;
                        break;
                    }
                    count++;
                }
            }
        }

        private static void OnDisplayPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BindablePicker picker = (BindablePicker)bindable;
            picker.DisplayProperty = (string)newValue;
            loadItemsAndSetSelected(bindable);

        }
        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (BindablePicker)bindable;
            picker.ItemsSource = (IList)newValue;

            var oc = newValue as INotifyCollectionChanged;

            if (oc != null && !PickerLookup.ContainsKey(oc))
            {
                oc.CollectionChanged += Oc_CollectionChanged;
                PickerLookup.Add(oc, new WeakReference(picker));
            }

            loadItemsAndSetSelected(bindable);
        }

        private static readonly Dictionary<INotifyCollectionChanged, WeakReference> PickerLookup = new Dictionary<INotifyCollectionChanged, WeakReference>();

        private static void Oc_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var oc = (INotifyCollectionChanged)sender;

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var picker = (BindablePicker)PickerLookup[oc].Target;

                foreach (var newItem in e.NewItems)
                {
                    var value = string.Empty;
                    if (picker.DisplayProperty != null)
                    {
                        var prop = newItem.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, picker.DisplayProperty, StringComparison.OrdinalIgnoreCase));

                        if (prop != null)
                            value = prop.GetValue(newItem).ToString();
                    }
                    else
                    {
                        value = newItem.ToString();
                    }

                    picker.Items.Add(value);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var picker = (BindablePicker)PickerLookup[oc].Target;

                foreach (var newItem in e.OldItems)
                {
                    var value = string.Empty;
                    if (picker.DisplayProperty != null)
                    {
                        var prop = newItem.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, picker.DisplayProperty, StringComparison.OrdinalIgnoreCase));

                        if (prop != null)
                            value = prop.GetValue(newItem).ToString();
                    }
                    else
                    {
                        value = newItem.ToString();
                    }

                    picker.Items.Remove(value);
                }
            }
        }

        static void loadItemsAndSetSelected(BindableObject bindable)
        {

            BindablePicker picker = (BindablePicker)bindable;
            if (picker.ItemsSource as IEnumerable != null)
            {
                int count = 0;
                foreach (object obj in (IEnumerable)picker.ItemsSource)
                {
                    string value = string.Empty;
                    if (picker.DisplayProperty != null)
                    {
                        var prop = obj.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, picker.DisplayProperty, StringComparison.OrdinalIgnoreCase));
                        if (prop != null)
                        {
                            value = prop.GetValue(obj).ToString();
                        }
                    }
                    else
                    {
                        value = obj.ToString();
                    }
                    picker.Items.Add(value);
                    if (picker.SelectedItem != null)
                    {
                        if (picker.SelectedItem == obj)
                        {
                            picker.SelectedIndex = count;
                        }
                    }
                    count++;
                }
            }
        }
    }
}

