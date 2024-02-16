// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// 这段代码的目的是将输入数据进行分组，使得每个组的和不超过目标值

// 输入数据
List<int> list = new() { 300, 998, 77, 1, 2, 33, 44, 5, 666, 188, 188, 210, 197, 194, 347, 443, 35, 18, 24, 119, 911, 224, 1, 125, 300, 50, 600 };
// 目标值
int target = 300;
// 当前总数
int currentSum = 0;

// 结果列表
List<List<int>> result = new();
// 当前分组
List<int> currentGroup = new();

foreach (int number in list)
{
    // 如果将当前的 number 加到当前组后，组内元素的和不超过目标值 target，那么执行条件为真的分支。
    if (currentSum + number <= target)
    {
        Console.WriteLine(number);
        currentSum += number;
        currentGroup.Add(number);
    }
    else
    {
        // 计算超过目标值的部分
        currentSum = currentSum + number - target;
        // 将未超过目标值的部分添加到当前组中
        if (number - currentSum != 0)
        {
            // 避免添加 0 
            currentGroup.Add(number - currentSum);
        }
        // 将当前组添加到结果列表中
        result.Add(new(currentGroup));

        // 循环处理超过目标值的部分
        while (currentSum >= target)
        {
            result.Add(new() { target });
            currentSum -= target;
        }

        if (currentSum != 0)
        {
            // 根据当前总和，创建新分组
            currentGroup = new() { currentSum };
        }
        else
        {
            // 当前总和为 0 时，清空该分组
            currentGroup.Clear();
        }
    }
}

// 避免添加空列表
if (currentGroup.Count != 0)
{
    result.Add(new(currentGroup));
}

// 打印结果
foreach (var item in result)
{
    Console.WriteLine("[" + string.Join(",", item) + "]");
}