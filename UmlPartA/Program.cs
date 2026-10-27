
Console.OutputEncoding = System.Text.Encoding.UTF8;

var first = new LateFee("Первый", 4, 10);
var second = new LateFee("Второй", 1, 10);
var third = new LateFee("Третий", 0, 10);
var own = new LateFee("Свой", 6, 12);

FeePlan named = first;
IValue value = first;

var calc = new Calculator();

void Check(string title, int expected, int actual)
{
    Console.WriteLine(
        $"{title}: ожидается {expected}, получено {actual}");

    if (expected != actual)
        throw new Exception(title);
}

Console.WriteLine("Просрочка выдачи, штраф в рублях");
Console.WriteLine($"Имя через FeePlan: {named.Name}");

Check("Первый (через IValue)", 30, value.GetValue());
Check(second.Name, 0, second.GetValue());
Check(third.Name, 0, third.GetValue());
Check("Свой (6, 12)", 60, own.GetValue());

IValue[] items = { first, second };

Check("Всего (Первый + Второй)", 30, calc.Total(items));
Check("Повтор", 30, calc.Total(items));
Check("Пустой набор", 0, calc.Total(Array.Empty<IValue>()));

IValue[] mixed = { first, new ConstantValue() };
Check("Разные типы", 37, calc.Total(mixed));

IValue[] custom = { first, third, own, new ConstantValue() };
Check("Свой набор", 97, calc.Total(custom));

Console.WriteLine("Все проверки пройдены");
