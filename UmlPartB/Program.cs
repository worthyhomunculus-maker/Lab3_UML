
var person = new Librarian("Анна");

var group1 = new Library();
var group2 = new Library();

group1.Add(person);
group1.Add(person);
group2.Add(person);

var first = new LoanBook();
var second = new LoanBook();

first.Add(person, 2);
first.Add(person, 7);

Console.WriteLine($"Участник: {person.Name}");
Console.WriteLine($"Первый журнал: {first.Result()}");
Console.WriteLine($"Второй журнал: {second.Result()}");

second.Add(person, 5);

Console.WriteLine($"После добавления: {second.Result()}");
Console.WriteLine($"Первый без изменений: {first.Result()}");
