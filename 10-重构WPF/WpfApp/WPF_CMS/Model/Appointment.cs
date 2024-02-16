using System;
using System.Collections.Generic;

namespace WPF_CMS.Model;

public partial class Appointment
{
    public int Id { get; set; }

    public DateTime Time { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!; // 非空后缀
    // 表示此属性在初始化时可以被显式地设置为 null，但编译器会认为这个值在后续使用时不应该为 null。
}
