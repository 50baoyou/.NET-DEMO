using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace WPF_CMS.ArrachedProperties
{
    public class CalendarAttachedProperties
    {
        // 定义附加属性 RegisterBlackoutDates
        public static readonly DependencyProperty RegisterBlackoutDatesProperty =
            DependencyProperty.RegisterAttached(
                "RegisterBlackoutDates",
                typeof(ObservableCollection<DateTime>),
                typeof(CalendarAttachedProperties),
                new PropertyMetadata(null, OnRegisterBlackoutDatesChanged)
                );

        // 获取附加属性值
        public static ObservableCollection<DateTime> GetRegisterBlackoutDates(DependencyObject obj)
        {
            return (ObservableCollection<DateTime>)obj.GetValue(RegisterBlackoutDatesProperty);
        }

        // 设置附加属性值
        public static void SetRegisterBlackoutDates(DependencyObject obj, ObservableCollection<DateTime> value)
        {
            obj.SetValue(RegisterBlackoutDatesProperty, value);
        }

        // 当附加属性值更改时的回调
        private static void OnRegisterBlackoutDatesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is Calendar calendar)
            {
                // 注册新值的事件处理器
                if (e.NewValue is ObservableCollection<DateTime> collection)
                {
                    // 清空 BlackoutDates
                    calendar.BlackoutDates.Clear();

                    // 将 ObservableCollection 中的日期添加到 BlackoutDates
                    foreach (var date in collection)
                    {
                        calendar.BlackoutDates.Add(new CalendarDateRange(date));
                    }

                    // 监听 ObservableCollection 的 CollectionChanged 事件，以便在集合发生更改时更新 BlackoutDates
                    collection.CollectionChanged += (sender, args) =>
                    {
                        if (calendar.SelectedDate is not null)
                        {
                            calendar.SelectedDate = null;
                        }
                        if (sender is ObservableCollection<DateTime> dates
                        && args.Action == NotifyCollectionChangedAction.Add)
                        {
                            var date = dates.Last();
                            calendar.BlackoutDates.Add(new CalendarDateRange(date));
                        }
                        if (args.Action == NotifyCollectionChangedAction.Reset)
                        {
                            calendar.BlackoutDates.Clear();
                            // 向集合中添加 Today 之前的所有日期，s防止用户选择过去的日期。
                            calendar.BlackoutDates.AddDatesInPast();
                        }
                    };
                }
            }
        }
    }
}
